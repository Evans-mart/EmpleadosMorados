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
            BotonBuscar = new Button();
            dgvusuarios = new DataGridView();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
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
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(1262, 77);
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
            btnDeleteEmpleado.Location = new Point(598, 3);
            btnDeleteEmpleado.Name = "btnDeleteEmpleado";
            btnDeleteEmpleado.Size = new Size(221, 71);
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
            btnUpdateEmpleado.Location = new Point(381, 3);
            btnUpdateEmpleado.Name = "btnUpdateEmpleado";
            btnUpdateEmpleado.Size = new Size(211, 71);
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
            btnReadEmpleado.Location = new Point(181, 3);
            btnReadEmpleado.Name = "btnReadEmpleado";
            btnReadEmpleado.Size = new Size(194, 71);
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
            btnCreateEmpleado.Location = new Point(0, 3);
            btnCreateEmpleado.Name = "btnCreateEmpleado";
            btnCreateEmpleado.Size = new Size(186, 71);
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
            label1.Location = new Point(11, 91);
            label1.Name = "label1";
            label1.Size = new Size(298, 35);
            label1.TabIndex = 4;
            label1.Text = "Consulta de Empleados";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = SystemColors.ButtonFace;
            lblNombre.Location = new Point(19, 171);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(71, 20);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            lblNombre.Click += lblNombre_Click;
            // 
            // textnombre
            // 
            textnombre.BackColor = Color.White;
            textnombre.Location = new Point(96, 168);
            textnombre.Margin = new Padding(3, 4, 3, 4);
            textnombre.Name = "textnombre";
            textnombre.Size = new Size(172, 27);
            textnombre.TabIndex = 6;
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstatus.ForeColor = SystemColors.ButtonFace;
            lblEstatus.Location = new Point(590, 171);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(64, 20);
            lblEstatus.TabIndex = 9;
            lblEstatus.Text = "Estatus:";
            lblEstatus.Click += label3_Click;
            // 
            // lblDpto
            // 
            lblDpto.AutoSize = true;
            lblDpto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDpto.ForeColor = SystemColors.ButtonFace;
            lblDpto.Location = new Point(797, 171);
            lblDpto.Name = "lblDpto";
            lblDpto.Size = new Size(115, 20);
            lblDpto.TabIndex = 11;
            lblDpto.Text = "Departamento:";
            // 
            // comboDepto
            // 
            comboDepto.FormattingEnabled = true;
            comboDepto.Location = new Point(918, 167);
            comboDepto.Margin = new Padding(3, 4, 3, 4);
            comboDepto.Name = "comboDepto";
            comboDepto.Size = new Size(191, 28);
            comboDepto.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(660, 168);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(131, 28);
            comboBox1.TabIndex = 13;
            // 
            // BotonBuscar
            // 
            BotonBuscar.Location = new Point(1127, 165);
            BotonBuscar.Margin = new Padding(3, 4, 3, 4);
            BotonBuscar.Name = "BotonBuscar";
            BotonBuscar.Size = new Size(86, 31);
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
            dgvusuarios.Location = new Point(19, 234);
            dgvusuarios.Margin = new Padding(3, 4, 3, 4);
            dgvusuarios.Name = "dgvusuarios";
            dgvusuarios.ReadOnly = true;
            dgvusuarios.RowHeadersWidth = 51;
            dgvusuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvusuarios.Size = new Size(1203, 435);
            dgvusuarios.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(274, 171);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 18;
            label2.Text = "Apellido Paterno:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(400, 169);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 27);
            textBox1.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Corbel", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(19, 126);
            label3.Name = "label3";
            label3.Size = new Size(549, 24);
            label3.TabIndex = 20;
            label3.Text = "Visualiza, filtra y exporta la información de todos los empleados.";
            // 
            // frmListaEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1262, 769);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(dgvusuarios);
            Controls.Add(BotonBuscar);
            Controls.Add(comboBox1);
            Controls.Add(comboDepto);
            Controls.Add(lblDpto);
            Controls.Add(lblEstatus);
            Controls.Add(textnombre);
            Controls.Add(lblNombre);
            Controls.Add(label1);
            Controls.Add(panelBar);
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
        private Button BotonBuscar;
        private DataGridView dgvusuarios;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
    }
}