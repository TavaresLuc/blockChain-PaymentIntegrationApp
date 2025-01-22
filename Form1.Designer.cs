namespace cryptoPayment
{
    partial class Form1
    {
        private System.Windows.Forms.RichTextBox txtResultado;
        private System.Windows.Forms.Button btnCriarTransacao;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.PictureBox picQRCode;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picQRCode = new PictureBox();
            txtResultado = new RichTextBox();
            btnCriarTransacao = new Button();
            txtLabel = new TextBox();
            txtTitulo = new RichTextBox();
            pictureBox3 = new PictureBox();
            TotalAPagar = new Label();
            txtValorBase = new RichTextBox();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            comboBoxMoedas = new ComboBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            label6 = new Label();
            comboBoxNetworks = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // picQRCode
            // 
            picQRCode.BackColor = Color.WhiteSmoke;
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.Location = new Point(82, 200);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(225, 195);
            picQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            picQRCode.TabIndex = 0;
            picQRCode.TabStop = false;
            // 
            // txtResultado
            // 
            txtResultado.ForeColor = SystemColors.MenuHighlight;
            txtResultado.Location = new Point(461, 423);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(312, 40);
            txtResultado.TabIndex = 4;
            txtResultado.Text = "";
            // 
            // btnCriarTransacao
            // 
            btnCriarTransacao.Cursor = Cursors.Hand;
            btnCriarTransacao.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCriarTransacao.Image = Properties.Resources.qr_code;
            btnCriarTransacao.ImageAlign = ContentAlignment.MiddleLeft;
            btnCriarTransacao.Location = new Point(82, 412);
            btnCriarTransacao.Name = "btnCriarTransacao";
            btnCriarTransacao.Padding = new Padding(10, 0, 0, 0);
            btnCriarTransacao.Size = new Size(225, 51);
            btnCriarTransacao.TabIndex = 5;
            btnCriarTransacao.Text = "Gerar QR Code";
            btnCriarTransacao.UseVisualStyleBackColor = true;
            btnCriarTransacao.Click += btnCriarTransacao_Click;
            // 
            // txtLabel
            // 
            txtLabel.Location = new Point(462, 220);
            txtLabel.Name = "txtLabel";
            txtLabel.PlaceholderText = "Descrição do Pagamento";
            txtLabel.Size = new Size(312, 23);
            txtLabel.TabIndex = 1;
            // 
            // txtTitulo
            // 
            txtTitulo.AccessibleRole = AccessibleRole.None;
            txtTitulo.BackColor = SystemColors.ControlLight;
            txtTitulo.Font = new Font("Segoe UI", 15.6F, FontStyle.Bold);
            txtTitulo.ImeMode = ImeMode.Disable;
            txtTitulo.Location = new Point(6, 5);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(811, 40);
            txtTitulo.TabIndex = 9;
            txtTitulo.TabStop = false;
            txtTitulo.Text = "         Pagamento em CriptoMoeda";
            txtTitulo.TextChanged += txtValorTopo_TextChanged_1;
            // 
            // pictureBox3
            // 
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(777, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(27, 26);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // TotalAPagar
            // 
            TotalAPagar.AutoSize = true;
            TotalAPagar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalAPagar.Location = new Point(27, 73);
            TotalAPagar.Name = "TotalAPagar";
            TotalAPagar.Size = new Size(114, 21);
            TotalAPagar.TabIndex = 12;
            TotalAPagar.Text = "Total a Pagar:";
            // 
            // txtValorBase
            // 
            txtValorBase.BackColor = SystemColors.ControlLight;
            txtValorBase.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtValorBase.Location = new Point(27, 97);
            txtValorBase.Name = "txtValorBase";
            txtValorBase.RightToLeft = RightToLeft.Yes;
            txtValorBase.Size = new Size(748, 40);
            txtValorBase.TabIndex = 13;
            txtValorBase.TabStop = false;
            txtValorBase.Text = "";
            txtValorBase.TextChanged += richTextBox1_TextChanged;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(27, 174);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(747, 10);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 14;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 150);
            label1.Name = "label1";
            label1.Size = new Size(396, 17);
            label1.TabIndex = 15;
            label1.Text = "Aponte a Câmera para o Código QR para efetuar o pagamento:";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(462, 200);
            label2.Name = "label2";
            label2.Size = new Size(165, 17);
            label2.TabIndex = 16;
            label2.Text = "Descrição do Pagamento:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLight;
            pictureBox1.Image = Properties.Resources.icone32;
            pictureBox1.Location = new Point(15, 9);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(30, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(384, 192);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(3, 239);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(462, 403);
            label3.Name = "label3";
            label3.Size = new Size(131, 17);
            label3.TabIndex = 18;
            label3.Text = "Link de Pagamento:";
            // 
            // comboBoxMoedas
            // 
            comboBoxMoedas.FormattingEnabled = true;
            comboBoxMoedas.Location = new Point(462, 321);
            comboBoxMoedas.Name = "comboBoxMoedas";
            comboBoxMoedas.Size = new Size(313, 23);
            comboBoxMoedas.TabIndex = 3;
            comboBoxMoedas.SelectedIndexChanged += comboBoxMoedas_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(462, 301);
            label4.Name = "label4";
            label4.Size = new Size(54, 17);
            label4.TabIndex = 20;
            label4.Text = "Moeda:";
            label4.Click += label4_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(462, 275);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(312, 23);
            txtEmail.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(462, 255);
            label5.Name = "label5";
            label5.Size = new Size(51, 17);
            label5.TabIndex = 24;
            label5.Text = "E-mail:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(461, 352);
            label6.Name = "label6";
            label6.Size = new Size(42, 17);
            label6.TabIndex = 26;
            label6.Text = "Rede:";
            // 
            // comboBoxNetworks
            // 
            comboBoxNetworks.FormattingEnabled = true;
            comboBoxNetworks.Location = new Point(461, 372);
            comboBoxNetworks.Name = "comboBoxNetworks";
            comboBoxNetworks.Size = new Size(313, 23);
            comboBoxNetworks.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(822, 475);
            Controls.Add(label6);
            Controls.Add(comboBoxNetworks);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(comboBoxMoedas);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox4);
            Controls.Add(txtValorBase);
            Controls.Add(TotalAPagar);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(txtTitulo);
            Controls.Add(picQRCode);
            Controls.Add(txtResultado);
            Controls.Add(btnCriarTransacao);
            Controls.Add(txtLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagamento com Criptomoedas";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox3;
        private Label TotalAPagar;
        protected internal RichTextBox txtValorBase;
        private PictureBox pictureBox4;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label3;
        private ComboBox comboBoxMoedas;
        private Label label4;
        protected RichTextBox txtTitulo;
        private TextBox txtEmail;
        private Label label5;
        private Label label6;
        private ComboBox comboBoxNetworks;
    }
}
