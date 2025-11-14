namespace EmpleadosMorados.View
{
    partial class frmListaEmpleado
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
            panelBar = new Panel();
            btnDeleteEmpleado = new FontAwesome.Sharp.IconButton();
            btnUpdateEmpleado = new FontAwesome.Sharp.IconButton();
            btnReadEmpleado = new FontAwesome.Sharp.IconButton();
            btnCreateEmpleado = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            lblNombre = new Label();
            textnombre = new TextBox();
            lblEstatus = new Label();
            lblDpto = new Label();
            comboDepto = new ComboBox();
            comboBox1 = new ComboBox();
            lblusuario = new Label();
            txtUsuario = new TextBox();
            BotonBuscar = new Button();
            dgvusuarios = new DataGridView();
            panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvusuarios).BeginInit();
            SuspendLayout();
            // 
            // panelBar
            // 
            panelBar.BackColor = Color.FromArgb(48, 51, 59);
            panelBar.Controls.Add(btnDeleteEmpleado);
            panelBar.Controls.Add(btnUpdateEmpleado);
            panelBar.Controls.Add(btnReadEmpleado);
            panelBar.Controls.Add(btnCreateEmpleado);
            panelBar.Dock = DockStyle.Top;
            panelBar.Location = new Point(0, 0);
            panelBar.Margin = new Padding(3, 2, 3, 2);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1104, 58);
            panelBar.TabIndex = 3;
            // 
            // btnDeleteEmpleado
            // 
            btnDeleteEmpleado.Cursor = Cursors.Hand;
            btnDeleteEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnDeleteEmpleado.FlatStyle = FlatStyle.Flat;
            btnDeleteEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnDeleteEmpleado.ForeColor = Color.White;
            btnDeleteEmpleado.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            btnDeleteEmpleado.IconColor = Color.BlueViolet;
            btnDeleteEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeleteEmpleado.IconSize = 32;
            btnDeleteEmpleado.Location = new Point(523, 2);
            btnDeleteEmpleado.Margin = new Padding(3, 2, 3, 2);
            btnDeleteEmpleado.Name = "btnDeleteEmpleado";
            btnDeleteEmpleado.Size = new Size(193, 53);
            btnDeleteEmpleado.TabIndex = 4;
            btnDeleteEmpleado.Text = "Eliminar Empleado";
            btnDeleteEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDeleteEmpleado.UseVisualStyleBackColor = false;
            btnDeleteEmpleado.Click += btnDeleteEmpleado_Click;
            // 
            // btnUpdateEmpleado
            // 
            btnUpdateEmpleado.Cursor = Cursors.Hand;
            btnUpdateEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnUpdateEmpleado.FlatStyle = FlatStyle.Flat;
            btnUpdateEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnUpdateEmpleado.ForeColor = Color.White;
            btnUpdateEmpleado.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnUpdateEmpleado.IconColor = Color.BlueViolet;
            btnUpdateEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUpdateEmpleado.IconSize = 32;
            btnUpdateEmpleado.Location = new Point(333, 2);
            btnUpdateEmpleado.Margin = new Padding(3, 2, 3, 2);
            btnUpdateEmpleado.Name = "btnUpdateEmpleado";
            btnUpdateEmpleado.Size = new Size(185, 53);
            btnUpdateEmpleado.TabIndex = 3;
            btnUpdateEmpleado.Text = "Actualizar Empleado";
            btnUpdateEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUpdateEmpleado.UseVisualStyleBackColor = false;
            btnUpdateEmpleado.Click += btnUpdateEmpleado_Click;
            // 
            // btnReadEmpleado
            // 
            btnReadEmpleado.Cursor = Cursors.Hand;
            btnReadEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnReadEmpleado.FlatStyle = FlatStyle.Flat;
            btnReadEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnReadEmpleado.ForeColor = Color.White;
            btnReadEmpleado.IconChar = FontAwesome.Sharp.IconChar.UsersLine;
            btnReadEmpleado.IconColor = Color.BlueViolet;
            btnReadEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReadEmpleado.IconSize = 32;
            btnReadEmpleado.Location = new Point(158, 2);
            btnReadEmpleado.Margin = new Padding(3, 2, 3, 2);
            btnReadEmpleado.Name = "btnReadEmpleado";
            btnReadEmpleado.Size = new Size(170, 53);
            btnReadEmpleado.TabIndex = 2;
            btnReadEmpleado.Text = "Listado Empleados";
            btnReadEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReadEmpleado.UseVisualStyleBackColor = false;
            btnReadEmpleado.Click += btnReadEmpleado_Click;
            // 
            // btnCreateEmpleado
            // 
            btnCreateEmpleado.Cursor = Cursors.Hand;
            btnCreateEmpleado.FlatAppearance.BorderColor = Color.FromArgb(48, 51, 59);
            btnCreateEmpleado.FlatStyle = FlatStyle.Flat;
            btnCreateEmpleado.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnCreateEmpleado.ForeColor = Color.White;
            btnCreateEmpleado.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnCreateEmpleado.IconColor = Color.BlueViolet;
            btnCreateEmpleado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCreateEmpleado.IconSize = 32;
            btnCreateEmpleado.Location = new Point(0, 2);
            btnCreateEmpleado.Margin = new Padding(3, 2, 3, 2);
            btnCreateEmpleado.Name = "btnCreateEmpleado";
            btnCreateEmpleado.Size = new Size(163, 53);
            btnCreateEmpleado.TabIndex = 1;
            btnCreateEmpleado.Text = "Alta Empleado";
            btnCreateEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreateEmpleado.UseVisualStyleBackColor = false;
            btnCreateEmpleado.Click += btnCreateEmpleado_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(12, 215, 253);
            label1.Location = new Point(10, 68);
            label1.Name = "label1";
            label1.Size = new Size(233, 27);
            label1.TabIndex = 4;
            label1.Text = "Consulta de Empleados";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = SystemColors.ButtonFace;
            lblNombre.Location = new Point(220, 123);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(61, 20);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            lblNombre.Click += lblNombre_Click;
            // 
            // textnombre
            // 
            textnombre.BackColor = SystemColors.ControlDarkDark;
            textnombre.Location = new Point(277, 123);
            textnombre.Name = "textnombre";
            textnombre.Size = new Size(215, 23);
            textnombre.TabIndex = 6;
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstatus.ForeColor = SystemColors.ButtonFace;
            lblEstatus.Location = new Point(504, 127);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(56, 20);
            lblEstatus.TabIndex = 9;
            lblEstatus.Text = "Estatus:";
            lblEstatus.Click += label3_Click;
            // 
            // lblDpto
            // 
            lblDpto.AutoSize = true;
            lblDpto.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDpto.ForeColor = SystemColors.ButtonFace;
            lblDpto.Location = new Point(697, 127);
            lblDpto.Name = "lblDpto";
            lblDpto.Size = new Size(96, 20);
            lblDpto.TabIndex = 11;
            lblDpto.Text = "Departamento:";
            // 
            // comboDepto
            // 
            comboDepto.FormattingEnabled = true;
            comboDepto.Location = new Point(799, 128);
            comboDepto.Name = "comboDepto";
            comboDepto.Size = new Size(168, 23);
            comboDepto.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(566, 126);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(115, 23);
            comboBox1.TabIndex = 13;
            // 
            // lblusuario
            // 
            lblusuario.AutoSize = true;
            lblusuario.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblusuario.ForeColor = SystemColors.ButtonFace;
            lblusuario.Location = new Point(17, 123);
            lblusuario.Name = "lblusuario";
            lblusuario.Size = new Size(127, 20);
            lblusuario.TabIndex = 14;
            lblusuario.Text = "Número de usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = SystemColors.ControlDarkDark;
            txtUsuario.Location = new Point(150, 123);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(64, 23);
            txtUsuario.TabIndex = 15;
            // 
            // BotonBuscar
            // 
            BotonBuscar.Location = new Point(995, 127);
            BotonBuscar.Name = "BotonBuscar";
            BotonBuscar.Size = new Size(75, 23);
            BotonBuscar.TabIndex = 16;
            BotonBuscar.Text = "Buscar";
            BotonBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvusuarios
            // 
            dgvusuarios.AllowUserToAddRows = false;
            dgvusuarios.AllowUserToDeleteRows = false;
            dgvusuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvusuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvusuarios.Location = new Point(17, 178);
            dgvusuarios.Name = "dgvusuarios";
            dgvusuarios.ReadOnly = true;
            dgvusuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvusuarios.Size = new Size(1053, 326);
            dgvusuarios.TabIndex = 17;
            // 
            // frmListaEmpleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1104, 577);
            Controls.Add(dgvusuarios);
            Controls.Add(BotonBuscar);
            Controls.Add(txtUsuario);
            Controls.Add(lblusuario);
            Controls.Add(comboBox1);
            Controls.Add(comboDepto);
            Controls.Add(lblDpto);
            Controls.Add(lblEstatus);
            Controls.Add(textnombre);
            Controls.Add(lblNombre);
            Controls.Add(label1);
            Controls.Add(panelBar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmListaEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de empleados";
            FormClosed += frmListaEmpleado_FormClosed;
            Load += frmListaEmpleado_Load;
            panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvusuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelBar;
        private FontAwesome.Sharp.IconButton btnDeleteEmpleado;
        private FontAwesome.Sharp.IconButton btnUpdateEmpleado;
        private FontAwesome.Sharp.IconButton btnReadEmpleado;
        private FontAwesome.Sharp.IconButton btnCreateEmpleado;
        private Label label1;
        private Label lblNombre;
        private TextBox textnombre;
        private Label lblEstatus;
        private Label lblDpto;
        private ComboBox comboDepto;
        private ComboBox comboBox1;
        private Label lblusuario;
        private TextBox txtUsuario;
        private Button BotonBuscar;
        private DataGridView dgvusuarios;
    }
}