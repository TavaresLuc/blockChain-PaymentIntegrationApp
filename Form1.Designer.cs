namespace cryptoPayment
{
    partial class Form1
    {
        private System.Windows.Forms.TextBox txtValorBase;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RichTextBox txtResultado;
        private System.Windows.Forms.Button btnCriarTransacao;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.PictureBox picQRCode;

        private void InitializeComponent()
        {
            picQRCode = new PictureBox();
            txtValorBase = new TextBox();
            txtEmail = new TextBox();
            txtResultado = new RichTextBox();
            btnCriarTransacao = new Button();
            txtLabel = new TextBox();
            ((System.ComponentModel.ISupportInitialize)picQRCode).BeginInit();
            SuspendLayout();
            // 
            // picQRCode
            // 
            picQRCode.BorderStyle = BorderStyle.FixedSingle;
            picQRCode.Location = new Point(331, 289);
            picQRCode.Name = "picQRCode";
            picQRCode.Size = new Size(161, 160);
            picQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            picQRCode.TabIndex = 0;
            picQRCode.TabStop = false;
            // 
            // txtValorBase
            // 
            txtValorBase.Location = new Point(289, 73);
            txtValorBase.Name = "txtValorBase";
            txtValorBase.PlaceholderText = "Valor";
            txtValorBase.Size = new Size(231, 23);
            txtValorBase.TabIndex = 0;
            txtValorBase.TextAlign = HorizontalAlignment.Center;
            txtValorBase.TextChanged += txtValorBase_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(255, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail do Cliente";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(255, 160);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(300, 40);
            txtResultado.TabIndex = 3;
            txtResultado.Text = "";
            // 
            // btnCriarTransacao
            // 
            btnCriarTransacao.Location = new Point(289, 206);
            btnCriarTransacao.Name = "btnCriarTransacao";
            btnCriarTransacao.Size = new Size(231, 77);
            btnCriarTransacao.TabIndex = 4;
            btnCriarTransacao.Text = "Gerar QR Code";
            btnCriarTransacao.UseVisualStyleBackColor = true;
            btnCriarTransacao.Click += btnCriarTransacao_Click;
            // 
            // txtLabel
            // 
            txtLabel.Location = new Point(255, 102);
            txtLabel.Name = "txtLabel";
            txtLabel.PlaceholderText = "Descrição do Pagamento";
            txtLabel.Size = new Size(300, 23);
            txtLabel.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 475);
            Controls.Add(picQRCode);
            Controls.Add(txtValorBase);
            Controls.Add(txtEmail);
            Controls.Add(txtResultado);
            Controls.Add(btnCriarTransacao);
            Controls.Add(txtLabel);
            Name = "Form1";
            Text = "Pagamento com Criptomoedas";
            ((System.ComponentModel.ISupportInitialize)picQRCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
