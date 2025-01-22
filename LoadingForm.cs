namespace cryptoPayment
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();

            // Configurações básicas do formulário
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Width = 200;
            this.Height = 100;

            // Calcula a posição para centralizar horizontalmente e alinhar na parte inferior da tela
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(
                (screenWidth - this.Width) / 2, // Centraliza horizontalmente
                screenHeight - this.Height - 50 // Posiciona na parte inferior com margem de 50 pixels
            );

            // Adiciona um painel para organizar os elementos
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(panel);

            // Label para exibir a mensagem de carregamento
            Label lblLoading = new Label
            {
                Text = "Carregando, por favor aguarde...",
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                Height = 50
            };
            panel.Controls.Add(lblLoading);

            // Adiciona uma barra de progresso
            ProgressBar progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee, // Estilo contínuo
                Dock = DockStyle.Bottom,
                Height = 20
            };
            panel.Controls.Add(progressBar);
        }
    }
}
