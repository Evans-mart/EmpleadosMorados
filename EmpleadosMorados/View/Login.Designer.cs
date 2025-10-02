namespace EmpleadosMorados.View
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelMagenta = new Panel();
            label1 = new Label();
            LogoMorado = new PictureBox();
            fontDialog1 = new FontDialog();
            label2 = new Label();
            lblLogin = new Label();
            lblCorreo = new Label();
            lblContraseña = new Label();
            txtCorreo = new TextBox();
            txtContraseña = new TextBox();
            button1 = new Button();
            panelNegro = new Panel();
            panelMagenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoMorado).BeginInit();
            panelNegro.SuspendLayout();
            SuspendLayout();
            // 
            // panelMagenta
            // 
            panelMagenta.BackColor = Color.DarkMagenta;
            panelMagenta.Controls.Add(label1);
            panelMagenta.Controls.Add(LogoMorado);
            panelMagenta.ForeColor = SystemColors.ControlDark;
            panelMagenta.Location = new Point(246, 158);
            panelMagenta.Name = "panelMagenta";
            panelMagenta.Size = new Size(341, 455);
            panelMagenta.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("Century Gothic", 16F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(86, 294);
            label1.Name = "label1";
            label1.Size = new Size(176, 75);
            label1.TabIndex = 1;
            label1.Text = "Gestión de empleados";
            // 
            // LogoMorado
            // 
            LogoMorado.Image = Properties.Resources.LogoLogin;
            LogoMorado.Location = new Point(60, 104);
            LogoMorado.Name = "LogoMorado";
            LogoMorado.Size = new Size(222, 160);
            LogoMorado.SizeMode = PictureBoxSizeMode.Zoom;
            LogoMorado.TabIndex = 0;
            LogoMorado.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 77);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Century Gothic", 32.2F, FontStyle.Bold);
            lblLogin.ForeColor = SystemColors.Window;
            lblLogin.Location = new Point(164, 77);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(211, 79);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "LOGIN";
            // 
            // lblCorreo
            // 
            lblCorreo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblCorreo.ForeColor = SystemColors.Window;
            lblCorreo.Location = new Point(69, 177);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(129, 37);
            lblCorreo.TabIndex = 2;
            lblCorreo.Text = "Correo :";
            // 
            // lblContraseña
            // 
            lblContraseña.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblContraseña.ForeColor = SystemColors.Window;
            lblContraseña.Location = new Point(23, 227);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(189, 37);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "Contraseña :";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(164, 177);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(268, 27);
            txtCorreo.TabIndex = 5;
            txtCorreo.Text = "admin@gmail.com";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(164, 227);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(268, 27);
            txtContraseña.TabIndex = 6;
            txtContraseña.Text = "admin123";
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(164, 308);
            button1.Name = "button1";
            button1.Size = new Size(182, 34);
            button1.TabIndex = 14;
            button1.Text = "Acceder";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panelNegro
            // 
            panelNegro.BackColor = SystemColors.ActiveCaptionText;
            panelNegro.Controls.Add(button1);
            panelNegro.Controls.Add(txtContraseña);
            panelNegro.Controls.Add(txtCorreo);
            panelNegro.Controls.Add(lblContraseña);
            panelNegro.Controls.Add(lblCorreo);
            panelNegro.Controls.Add(lblLogin);
            panelNegro.Controls.Add(label2);
            panelNegro.Location = new Point(580, 158);
            panelNegro.Name = "panelNegro";
            panelNegro.Size = new Size(474, 455);
            panelNegro.TabIndex = 1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(15, 15, 15);
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(1280, 816);
            Controls.Add(panelNegro);
            Controls.Add(panelMagenta);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosed += Login_FormClosed;
            Load += Login_Load;
            panelMagenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoMorado).EndInit();
            panelNegro.ResumeLayout(false);
            panelNegro.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMagenta;
        private PictureBox LogoMorado;
        private Label label1;
        private FontDialog fontDialog1;
        private Label label2;
        private Label lblLogin;
        private Label lblCorreo;
        private Label lblContraseña;
        private TextBox txtCorreo;
        private TextBox txtContraseña;
        private Button button1;
        private Panel panelNegro;
    }
}