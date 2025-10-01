namespace EmpleadosMorados.View
{
    partial class Forma1
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            btnDeleteEmpleado = new FontAwesome.Sharp.IconButton();
            btnUpdateEmpleado = new FontAwesome.Sharp.IconButton();
            btnReadEmpleado = new FontAwesome.Sharp.IconButton();
            btnCreateEmpleado = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 30F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(205, 111);
            label1.Name = "label1";
            label1.Size = new Size(736, 180);
            label1.TabIndex = 5;
            label1.Text = "BIENVENIDOS AL \r\nSISTEMA DE \r\nGESTIÓN DE EMPLEADOS\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoLogin;
            pictureBox1.Location = new Point(414, 323);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(286, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(48, 51, 59);
            panel1.Controls.Add(btnDeleteEmpleado);
            panel1.Controls.Add(btnUpdateEmpleado);
            panel1.Controls.Add(btnReadEmpleado);
            panel1.Controls.Add(btnCreateEmpleado);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1233, 64);
            panel1.TabIndex = 7;
            // 
            // btnDeleteEmpleado
            // 
            btnDeleteEmpleado.BackColor = Color.FromArgb(48, 51, 59);
            btnDeleteEmpleado.Cursor = Cursors.Hand;
            btnDeleteEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnDeleteEmpleado.FlatStyle = FlatStyle.Flat;
            btnDeleteEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnDeleteEmpleado.ForeColor = Color.White;
            btnDeleteEmpleado.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            btnDeleteEmpleado.IconColor = Color.BlueViolet;
            btnDeleteEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteEmpleado.IconSize = 32;
            btnDeleteEmpleado.Location = new Point(640, 3);
            btnDeleteEmpleado.Name = "btnDeleteEmpleado";
            btnDeleteEmpleado.Size = new Size(250, 67);
            btnDeleteEmpleado.TabIndex = 3;
            btnDeleteEmpleado.Text = "Eliminar Empleado";
            btnDeleteEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteEmpleado.UseVisualStyleBackColor = false;
            btnDeleteEmpleado.Click += btnDeleteEmpleado_Click;
            // 
            // btnUpdateEmpleado
            // 
            btnUpdateEmpleado.BackColor = Color.FromArgb(48, 51, 59);
            btnUpdateEmpleado.Cursor = Cursors.Hand;
            btnUpdateEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnUpdateEmpleado.FlatStyle = FlatStyle.Flat;
            btnUpdateEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnUpdateEmpleado.ForeColor = Color.White;
            btnUpdateEmpleado.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnUpdateEmpleado.IconColor = Color.BlueViolet;
            btnUpdateEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUpdateEmpleado.IconSize = 32;
            btnUpdateEmpleado.Location = new Point(414, 2);
            btnUpdateEmpleado.Name = "btnUpdateEmpleado";
            btnUpdateEmpleado.Size = new Size(220, 67);
            btnUpdateEmpleado.TabIndex = 2;
            btnUpdateEmpleado.Text = "Actualizar Empleado";
            btnUpdateEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdateEmpleado.UseVisualStyleBackColor = false;
            btnUpdateEmpleado.Click += btnUpdateEmpleado_Click_1;
            // 
            // btnReadEmpleado
            // 
            btnReadEmpleado.BackColor = Color.FromArgb(48, 51, 59);
            btnReadEmpleado.Cursor = Cursors.Hand;
            btnReadEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnReadEmpleado.FlatStyle = FlatStyle.Flat;
            btnReadEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnReadEmpleado.ForeColor = Color.White;
            btnReadEmpleado.IconChar = FontAwesome.Sharp.IconChar.UsersLine;
            btnReadEmpleado.IconColor = Color.BlueViolet;
            btnReadEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReadEmpleado.IconSize = 32;
            btnReadEmpleado.Location = new Point(205, 0);
            btnReadEmpleado.Name = "btnReadEmpleado";
            btnReadEmpleado.Size = new Size(203, 70);
            btnReadEmpleado.TabIndex = 1;
            btnReadEmpleado.Text = "ListaEmpleado";
            btnReadEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReadEmpleado.UseVisualStyleBackColor = false;
            btnReadEmpleado.Click += btnReadEmpleado_Click;
            // 
            // btnCreateEmpleado
            // 
            btnCreateEmpleado.BackColor = Color.FromArgb(48, 51, 59);
            btnCreateEmpleado.Cursor = Cursors.Hand;
            btnCreateEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnCreateEmpleado.FlatStyle = FlatStyle.Flat;
            btnCreateEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnCreateEmpleado.ForeColor = Color.White;
            btnCreateEmpleado.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnCreateEmpleado.IconColor = Color.BlueViolet;
            btnCreateEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCreateEmpleado.IconSize = 32;
            btnCreateEmpleado.Location = new Point(21, 3);
            btnCreateEmpleado.Name = "btnCreateEmpleado";
            btnCreateEmpleado.Size = new Size(178, 67);
            btnCreateEmpleado.TabIndex = 0;
            btnCreateEmpleado.Text = "Alta Empleado";
            btnCreateEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreateEmpleado.UseVisualStyleBackColor = false;
            btnCreateEmpleado.Click += btnCreateEmpleado_Click_1;
            // 
            // Forma1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1233, 769);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Forma1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Forma1";
            FormClosed += Forma1_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnDeleteEmpleado;
        private FontAwesome.Sharp.IconButton btnUpdateEmpleado;
        private FontAwesome.Sharp.IconButton btnReadEmpleado;
        private FontAwesome.Sharp.IconButton btnCreateEmpleado;
    }
}