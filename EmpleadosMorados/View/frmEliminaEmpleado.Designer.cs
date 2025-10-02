using System.Drawing;
using System.Windows.Forms;

namespace EmpleadosMorados.View
{
    partial class frmEliminaEmpleado
    {
        private System.ComponentModel.IContainer components = null;

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
            panelBar = new Panel();
            btnDeleteEmpleado = new FontAwesome.Sharp.IconButton();
            btnUpdateEmpleado = new FontAwesome.Sharp.IconButton();
            btnReadEmpleado = new FontAwesome.Sharp.IconButton();
            btnCreateEmpleado = new FontAwesome.Sharp.IconButton();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            lblNombreBusqueda = new Label();
            txtNombreBusqueda = new TextBox();
            lblApellidoBusqueda = new Label();
            txtApellidoBusqueda = new TextBox();
            btnBuscar = new Button();
            dgvResultados = new DataGridView();
            btnConfirmarBorrar = new Button();
            btnBaja = new Button();
            panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
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
            panelBar.Size = new Size(1262, 75);
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
            btnDeleteEmpleado.Size = new Size(221, 69);
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
            btnUpdateEmpleado.Size = new Size(211, 69);
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
            btnReadEmpleado.Size = new Size(194, 69);
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
            btnCreateEmpleado.Location = new Point(12, 3);
            btnCreateEmpleado.Name = "btnCreateEmpleado";
            btnCreateEmpleado.Size = new Size(174, 69);
            btnCreateEmpleado.TabIndex = 1;
            btnCreateEmpleado.Text = "Alta Empleado";
            btnCreateEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreateEmpleado.UseVisualStyleBackColor = false;
            btnCreateEmpleado.Click += btnCreateEmpleado_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(12, 215, 253);
            lblTitulo.Location = new Point(25, 100);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(244, 35);
            lblTitulo.TabIndex = 18;
            lblTitulo.Text = "Eliminar Empleado";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.ForeColor = Color.White;
            lblDescripcion.Location = new Point(28, 145);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(602, 24);
            lblDescripcion.TabIndex = 17;
            lblDescripcion.Text = "Ingresa el nombre y apellido del empleado para buscarlo en el sistema.";
            // 
            // lblNombreBusqueda
            // 
            lblNombreBusqueda.AutoSize = true;
            lblNombreBusqueda.Font = new Font("Corbel", 10.8F, FontStyle.Bold);
            lblNombreBusqueda.ForeColor = Color.WhiteSmoke;
            lblNombreBusqueda.Location = new Point(30, 200);
            lblNombreBusqueda.Name = "lblNombreBusqueda";
            lblNombreBusqueda.Size = new Size(78, 22);
            lblNombreBusqueda.TabIndex = 16;
            lblNombreBusqueda.Text = "Nombre:";
            // 
            // txtNombreBusqueda
            // 
            txtNombreBusqueda.Font = new Font("Segoe UI", 10.8F);
            txtNombreBusqueda.Location = new Point(34, 225);
            txtNombreBusqueda.Name = "txtNombreBusqueda";
            txtNombreBusqueda.Size = new Size(300, 31);
            txtNombreBusqueda.TabIndex = 10;
            // 
            // lblApellidoBusqueda
            // 
            lblApellidoBusqueda.AutoSize = true;
            lblApellidoBusqueda.Font = new Font("Corbel", 10.8F, FontStyle.Bold);
            lblApellidoBusqueda.ForeColor = Color.WhiteSmoke;
            lblApellidoBusqueda.Location = new Point(356, 200);
            lblApellidoBusqueda.Name = "lblApellidoBusqueda";
            lblApellidoBusqueda.Size = new Size(146, 22);
            lblApellidoBusqueda.TabIndex = 15;
            lblApellidoBusqueda.Text = "Apellido Paterno:";
            // 
            // txtApellidoBusqueda
            // 
            txtApellidoBusqueda.Font = new Font("Segoe UI", 10.8F);
            txtApellidoBusqueda.Location = new Point(360, 225);
            txtApellidoBusqueda.Name = "txtApellidoBusqueda";
            txtApellidoBusqueda.Size = new Size(300, 31);
            txtApellidoBusqueda.TabIndex = 11;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.SlateBlue;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Corbel", 10.8F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(680, 220);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 40);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.BackgroundColor = Color.FromArgb(45, 49, 57);
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(34, 280);
            dgvResultados.MultiSelect = false;
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersWidth = 51;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(1194, 350);
            dgvResultados.TabIndex = 13;
            dgvResultados.CellContentClick += dgvResultados_CellContentClick;
            dgvResultados.SelectionChanged += dgvResultados_SelectionChanged;
            // 
            // btnConfirmarBorrar
            // 
            btnConfirmarBorrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmarBorrar.BackColor = Color.Crimson;
            btnConfirmarBorrar.Cursor = Cursors.Hand;
            btnConfirmarBorrar.FlatStyle = FlatStyle.Flat;
            btnConfirmarBorrar.Font = new Font("Corbel", 12F, FontStyle.Bold);
            btnConfirmarBorrar.ForeColor = Color.White;
            btnConfirmarBorrar.Location = new Point(680, 663);
            btnConfirmarBorrar.Name = "btnConfirmarBorrar";
            btnConfirmarBorrar.Size = new Size(268, 60);
            btnConfirmarBorrar.TabIndex = 14;
            btnConfirmarBorrar.Text = "Eliminar permanentemente al seleccionado";
            btnConfirmarBorrar.UseVisualStyleBackColor = false;
            btnConfirmarBorrar.Click += btnEliminar_Click;
            // 
            // btnBaja
            // 
            btnBaja.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBaja.BackColor = Color.Crimson;
            btnBaja.Cursor = Cursors.Hand;
            btnBaja.FlatStyle = FlatStyle.Flat;
            btnBaja.Font = new Font("Corbel", 12F, FontStyle.Bold);
            btnBaja.ForeColor = Color.White;
            btnBaja.Location = new Point(960, 663);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(268, 60);
            btnBaja.TabIndex = 14;
            btnBaja.Text = "Dar de baja al usuario";
            btnBaja.UseVisualStyleBackColor = false;
            btnBaja.Click += btnBaja_Click;
            // 
            // frmEliminaEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1262, 769);
            Controls.Add(btnConfirmarBorrar);
            Controls.Add(btnBaja);
            Controls.Add(dgvResultados);
            Controls.Add(btnBuscar);
            Controls.Add(txtApellidoBusqueda);
            Controls.Add(lblApellidoBusqueda);
            Controls.Add(txtNombreBusqueda);
            Controls.Add(lblNombreBusqueda);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            Controls.Add(panelBar);
            Name = "frmEliminaEmpleado";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminación de empleados";
            FormClosed += frmEliminaEmpleado_FormClosed;
            panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // --- Declaraciones de Controles ---
        private Panel panelBar;
        private FontAwesome.Sharp.IconButton btnDeleteEmpleado;
        private FontAwesome.Sharp.IconButton btnUpdateEmpleado;
        private FontAwesome.Sharp.IconButton btnReadEmpleado;
        private FontAwesome.Sharp.IconButton btnCreateEmpleado;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Label lblNombreBusqueda;
        private TextBox txtNombreBusqueda;
        private Label lblApellidoBusqueda;
        private TextBox txtApellidoBusqueda;
        private Button btnBuscar;
        private DataGridView dgvResultados;
        private Button btnConfirmarBorrar;
        private Button btnBaja;
    }
}