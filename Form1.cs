using Newtonsoft.Json;
using cryptoPayment.Data;
using cryptoPayment.Models;
using QRCoder;
using cryptoPayment.Services;
using System.Diagnostics;
using System;

namespace cryptoPayment
{
    public partial class Form1 : Form
    {
        private readonly KamoneyApi _kamoneyApi;

        public Form1(string email, string descricao, string valor)
        {
            InitializeComponent();

            txtLabel.Text = descricao;
            txtValorBase.Text = valor;
            txtValorBase.Text = valor;

            this.KeyPreview = true;

            this.KeyDown += Form1_KeyDown;
            // Usando Bearer Token
            _kamoneyApi = new KamoneyApi("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpYXQiOjE3Mzc0MTM0ODMsImp0aSI6IkpaMWJIM0tKYmNZaFlqOU9mQmxua3FSVUZoNnkxVDNrSkp3ODh4Z3hNM3MiLCJ0b2tlbl9pZCI6MTM4Nzg3fQ.w7mjYmrzUPusE0dFLwABkiAsfzysD0YY3W9CFdlFC9c");

            LoadCurrenciesAsync();

        }

        private Dictionary<string, Image> _imageCache = new Dictionary<string, Image>();


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se Ctrl + Espaço foram pressionados
            if (e.Control && e.KeyCode == Keys.Space)
            {
                // Abre o modal
                using (var modal = new ModalForm())
                {
                    modal.ShowDialog(); // Exibe o modal
                }

                // Marca o evento como tratado
                e.Handled = true;
            }
        }



        private async void LoadCurrenciesAsync()
        {
            try
            {
                var response = await _kamoneyApi.GetCurrenciesAsync();
                dynamic currencies = JsonConvert.DeserializeObject(response);

                if (currencies.success == true)
                {
                    comboBoxMoedas.Items.Clear();
                    foreach (var currency in currencies.data)
                    {
                        string name = currency.name.ToString();
                        string asset = currency.asset.ToString();
                        string imageUrl = currency.image.ToString();
                        bool maintenance = currency.maintenance;

                        comboBoxMoedas.Items.Add(new CurrencyItem
                        {
                            Name = name,
                            Asset = asset,
                            ImageUrl = imageUrl,
                            Maintenance = maintenance
                        });
                    }

                    comboBoxMoedas.DrawMode = DrawMode.OwnerDrawFixed; // Ativa o desenho customizado
                    comboBoxMoedas.DrawItem += comboBoxMoedas_DrawItem; // Vincula o evento de desenho

                    if (comboBoxMoedas.Items.Count > 0)
                    {
                        comboBoxMoedas.SelectedIndex = 0; // Seleciona o primeiro item
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar moedas: {ex.Message}");
            }
        }


        private void comboBoxMoedas_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // Obtém o item da ComboBox
            var currencyItem = (CurrencyItem)comboBoxMoedas.Items[e.Index];

            // Carrega ou obtém a imagem do cache
            Image img;
            if (_imageCache.ContainsKey(currencyItem.ImageUrl))
            {
                img = _imageCache[currencyItem.ImageUrl];
            }
            else
            {
                try
                {
                    using (var client = new System.Net.WebClient())
                    {
                        byte[] data = client.DownloadData(currencyItem.ImageUrl);
                        using (var ms = new System.IO.MemoryStream(data))
                        {
                            img = Image.FromStream(ms);
                        }
                    }

                    // Armazena no cache
                    _imageCache[currencyItem.ImageUrl] = img;
                }
                catch
                {
                    img = Properties.Resources.icone32; // Usa uma imagem padrão em caso de erro
                }
            }

            // Define o tamanho da imagem
            int imgSize = 16;
            Rectangle imgRect = new Rectangle(e.Bounds.Left, e.Bounds.Top + (e.Bounds.Height - imgSize) / 2, imgSize, imgSize);

            // Desenha a imagem
            e.Graphics.DrawImage(img, imgRect);

            // Ajusta o texto para incluir "(em manutenção)" se necessário
            string displayText = currencyItem.Maintenance ? $"{currencyItem.Name} (em manutenção)" : currencyItem.Name;

            // Desenha o texto ao lado da imagem
            Rectangle textRect = new Rectangle(e.Bounds.Left + imgSize + 5, e.Bounds.Top, e.Bounds.Width - imgSize - 5, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, displayText, comboBoxMoedas.Font, textRect, e.ForeColor, TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }


        private Image ResizeImage(Image img, int width, int height)
        {
            var resizedImage = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(img, 0, 0, width, height);
            }
            return resizedImage;
        }




        private async void btnCriarTransacao_Click(object sender, EventArgs e)
        {
            try
            {

                // Valida o valor inserido
                if (!double.TryParse(txtValorBase.Text, out double amount) || amount <= 0)
                {
                    MessageBox.Show("Insira um valor válido e maior que zero.");
                    return;
                }

                // Valida o e-mail
                string email = txtEmail.Text.Trim();
                if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                {
                    MessageBox.Show("Insira um e-mail válido.");
                    return;
                }

                if (comboBoxMoedas.SelectedItem is not CurrencyItem selectedCurrency ||
                    comboBoxNetworks.SelectedItem is not NetworkInfo selectedNetwork)
                {
                    MessageBox.Show("Selecione uma moeda e uma rede válidas.");
                    return;
                }

                string asset = selectedCurrency.Asset;
                string network = selectedNetwork.Symbol; // Use Symbol como valor de network


                if (string.IsNullOrEmpty(asset) || string.IsNullOrEmpty(network))
                {
                    MessageBox.Show("Certifique-se de selecionar um ativo e uma rede válidos.");
                    return;
                }

                var responseJson = await _kamoneyApi.CreateMerchantSale(asset, network, amount, email);
                dynamic response = JsonConvert.DeserializeObject(responseJson);

                if (response.success == true)
                {
                    string uri = response.data.uri.ToString();
                    txtResultado.Text = uri;

                    GerarQRCode(uri); // Gera o QR Code com o URI

                    var transacao = new TransacoesCrypto
                    {
                        TokenTransaction = response.data.id.ToString(),
                        Cryptocurrency = response.data.title,
                        ValCrypto = response.data.amount,
                        Address = response.data.address,
                        DateCreated = DateTime.Now,
                        Status = response.data.status.name.ToString()
                    };


                    Debug.WriteLine($"Resposta da API: {responseJson}");
                }
                else
                {
                    Debug.WriteLine($"Erro da API: {response.error}");
                    MessageBox.Show($"Erro ao criar a venda: {response.error}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exceção: {ex.Message}");
                MessageBox.Show($"Erro ao criar a venda: {ex.Message}");
            }
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        private void GerarQRCode(string uri)
        {
            try
            {
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(uri, QRCodeGenerator.ECCLevel.Q);
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        Bitmap qrCodeImage = qrCode.GetGraphic(20); // Tamanho do QR Code
                        picQRCode.Image = qrCodeImage; // Exibe o QR Code em um PictureBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o QR Code: {ex.Message}");
            }
        }




        private void txtValorBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValorTopo_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void txtValorTopo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private async void comboBoxMoedas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMoedas.SelectedItem is CurrencyItem selectedCurrency)
            {
                string asset = selectedCurrency.Asset;

                // Atualiza as redes disponíveis para a moeda selecionada
                await AtualizarRedesAsync(asset);
            }
        }

        private void comboBoxNetworks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxNetworks.SelectedItem is NetworkInfo selectedNetwork)
            {
                string selectedProtocol = selectedNetwork.Protocol; // Obtém o protocolo da rede selecionada
                Debug.WriteLine($"Rede selecionada: {selectedNetwork.Name}, Protocolo: {selectedProtocol}");
            }
        }


        private async Task AtualizarRedesAsync(string asset)
        {
            try
            {
                var networks = await _kamoneyApi.GetCurrencyNetworksAsync(asset);

                comboBoxNetworks.Items.Clear(); // Limpa os itens existentes no ComboBox

                // Adiciona as redes no ComboBox
                foreach (var network in networks)
                {
                    if (network.Enabled)
                    {
                        comboBoxNetworks.Items.Add(network); // Adiciona o objeto NetworkInfo diretamente
                    }
                }

                // Define a propriedade a ser exibida no ComboBox
                comboBoxNetworks.DisplayMember = "Name"; // Exibe o nome da rede
                comboBoxNetworks.ValueMember = "Symbol"; // Usa o símbolo como valor de network

                if (comboBoxNetworks.Items.Count > 0)
                {
                    comboBoxNetworks.SelectedIndex = 0; // Seleciona o primeiro item
                }
                else
                {
                    MessageBox.Show("Nenhuma rede habilitada disponível para esta moeda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar redes: {ex.Message}");
            }
        }



    }
}

