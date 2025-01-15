using cryptoPayment.Services;
using cryptoPayment.Models;
using Newtonsoft.Json;
using cryptoPayment.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Drawing;
using QRCoder;

namespace cryptoPayment;

public partial class Form1 : Form
{
    private readonly KamoneyApi _kamoneyApi;

    public Form1(string email, string descricao, string valor)
    {
        InitializeComponent();
        // Substitua pelas chaves reais da sua empresa
        txtEmail.Text = email;
        txtLabel.Text = descricao;
        txtValorBase.Text = valor;
        _kamoneyApi = new KamoneyApi("6d7766c1a17ec519483a1d56009894f9", "3e1e38e9ec8e29f8d8dafc26d93c5ec0");
    }

    private async void btnCriarTransacao_Click(object sender, EventArgs e)
    {
        // Validação de entrada
        double valBase;
        if (!double.TryParse(txtValorBase.Text, out valBase))
        {
            MessageBox.Show("Insira um valorválido.");
            return;
        }

        string label = txtLabel.Text;
        if (string.IsNullOrEmpty(label))
        {
            MessageBox.Show("Insira uma descrição para o pagamento.");
            return;
        }

        try
        {
            // Chamada à API Kamoney para criar um link de pagamento
            var responseJson = await _kamoneyApi.CreatePaymentLink(label, valBase);

            // Parse da resposta
            dynamic response = JsonConvert.DeserializeObject(responseJson);
            string link = $"https://google.com.br/{txtValorBase.Text}/{txtLabel.Text}";
            txtResultado.Text = link;
            GerarQRCode(link);

         /*   if (response.success == true)
            {
                // Exibe o link de pagamento gerado
                txtResultado.Text = $"Link criado com sucesso!\nLink: {response.data.link}";

                // Salva no banco de dados
                var transacao = new TransacoesCrypto
                {
                    TokenTransaction = response.data.id.ToString(),
                    Cryptocurrency = "BRL",
                    ValCrypto = valBase,
                    Address = response.data.link,
                    DateCreated = DateTime.Now,
                    Status = "registrado"
                };

                using (var context = new AppDbContext())
                {
                    context.Transacoes.Add(transacao);
                    await context.SaveChangesAsync();
                } 

                MessageBox.Show("Transação salva no banco com sucesso.");
             }
            else
            {
                txtResultado.Text = $"Erro ao criar o link: {response.error}";
        } */
    }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao comunicar com a API Kamoney: {ex.Message}");
        }
    }

    private void cmbCriptomoeda_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Este método pode ser implementado caso necessário para lidar com mudanças na seleção de criptomoedas.
    }

    private void txtValorBase_TextChanged(object sender, EventArgs e)
    {

    }


    private void GerarQRCode(string link)
    {
        try
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(link, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20); // Tamanho e densidade do QR Code
                    picQRCode.Image = qrCodeImage;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao gerar o QR Code: {ex.Message}");
        }
}

}
