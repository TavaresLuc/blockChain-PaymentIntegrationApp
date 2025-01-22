
namespace cryptoPayment;
public partial class ModalForm : Form
{
    public ModalForm()
    {
        InitializeComponent();
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {

        this.Close();

    }

    private void btnCriarTransacao_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Conexão realizada com Sucesso!");
    }
}
