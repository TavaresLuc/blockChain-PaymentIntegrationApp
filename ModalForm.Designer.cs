namespace cryptoPayment
{
    partial class ModalForm
    {

        private System.ComponentModel.IContainer components = null;


        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModalForm));
            btnTestarConexao = new Button();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            txtPublic = new TextBox();
            label1 = new Label();
            txtSecret = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // btnTestarConexao
            // 
            btnTestarConexao.Cursor = Cursors.Hand;
            btnTestarConexao.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTestarConexao.Image = Properties.Resources.testar;
            btnTestarConexao.ImageAlign = ContentAlignment.MiddleLeft;
            btnTestarConexao.Location = new Point(186, 199);
            btnTestarConexao.Name = "btnTestarConexao";
            btnTestarConexao.Padding = new Padding(10, 0, 4, 0);
            btnTestarConexao.Size = new Size(152, 34);
            btnTestarConexao.TabIndex = 5;
            btnTestarConexao.Text = "Testar Conexão";
            btnTestarConexao.TextAlign = ContentAlignment.MiddleRight;
            btnTestarConexao.UseVisualStyleBackColor = true;
            btnTestarConexao.Click += btnCriarTransacao_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(506, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(27, 26);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(110, 80);
            label2.Name = "label2";
            label2.Size = new Size(312, 17);
            label2.TabIndex = 18;
            label2.Text = "Public Key:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtPublic
            // 
            txtPublic.Location = new Point(110, 100);
            txtPublic.Name = "txtPublic";
            txtPublic.PlaceholderText = "Pubblic Key";
            txtPublic.Size = new Size(314, 23);
            txtPublic.TabIndex = 17;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(112, 137);
            label1.Name = "label1";
            label1.Size = new Size(312, 17);
            label1.TabIndex = 20;
            label1.Text = "Secret Key:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtSecret
            // 
            txtSecret.Location = new Point(112, 157);
            txtSecret.Name = "txtSecret";
            txtSecret.PlaceholderText = "Secret Key";
            txtSecret.Size = new Size(312, 23);
            txtSecret.TabIndex = 19;
            // 
            // ModalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(536, 277);
            Controls.Add(label1);
            Controls.Add(txtSecret);
            Controls.Add(label2);
            Controls.Add(txtPublic);
            Controls.Add(pictureBox3);
            Controls.Add(btnTestarConexao);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ModalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModalForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestarConexao;
        private PictureBox pictureBox3;
        private Label label2;
        private TextBox txtPublic;
        private Label label1;
        private TextBox txtSecret;
    }
}
