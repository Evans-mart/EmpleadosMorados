namespace EmpleadosMorados.View
{
    partial class frmAltaEmpleados
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
            label2 = new Label();
            gBoxDPersonales = new GroupBox();
            panel5 = new Panel();
            cboSexo = new ComboBox();
            lblSexo = new Label();
            panel4 = new Panel();
            txtRFC = new TextBox();
            lblRFC = new Label();
            v = new Panel();
            txtCURP = new TextBox();
            lblCURP = new Label();
            panel3 = new Panel();
            txtApMat = new TextBox();
            lblApMat = new Label();
            panel2 = new Panel();
            txtApPat = new TextBox();
            lblApPat = new Label();
            panel1 = new Panel();
            txtNombre = new TextBox();
            lblNombres = new Label();
            gBoxDContacto = new GroupBox();
            panel8 = new Panel();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            panel7 = new Panel();
            txtCorreoSecundario = new TextBox();
            lblCorreo2 = new Label();
            panel6 = new Panel();
            txtCorreoPrincipal = new TextBox();
            lblCorreo1 = new Label();
            gBoxDomicilio = new GroupBox();
            panel15 = new Panel();
            cboMunicipio = new ComboBox();
            lblMunicipio = new Label();
            panel14 = new Panel();
            cboEstado = new ComboBox();
            lblEstado = new Label();
            panel13 = new Panel();
            txtColonia = new TextBox();
            lblColonia = new Label();
            panel12 = new Panel();
            txtCP = new TextBox();
            lblCP = new Label();
            panel9 = new Panel();
            txtNoInt = new TextBox();
            lblNoInt = new Label();
            panel10 = new Panel();
            txtNoExt = new TextBox();
            lblNoExt = new Label();
            panel11 = new Panel();
            txtCalle = new TextBox();
            lblCalle = new Label();
            gBoxDEmpresarial = new GroupBox();
            panel16 = new Panel();
            cboDepto = new ComboBox();
            lblDepto = new Label();
            btnLimpiar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            lblDatosObligatorios = new Label();
            panelBar.SuspendLayout();
            gBoxDPersonales.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            v.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            gBoxDContacto.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            gBoxDomicilio.SuspendLayout();
            panel15.SuspendLayout();
            panel14.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            gBoxDEmpresarial.SuspendLayout();
            panel16.SuspendLayout();
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
            panelBar.Size = new Size(1262, 64);
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
            btnDeleteEmpleado.Location = new Point(625, 3);
            btnDeleteEmpleado.Name = "btnDeleteEmpleado";
            btnDeleteEmpleado.Size = new Size(221, 58);
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
            btnUpdateEmpleado.Size = new Size(238, 58);
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
            btnReadEmpleado.Size = new Size(194, 58);
            btnReadEmpleado.TabIndex = 2;
            btnReadEmpleado.Text = "Listado Empleados";
            btnReadEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReadEmpleado.UseVisualStyleBackColor = false;
            btnReadEmpleado.Click += btnReadEmpleado_Click_1;
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
            btnCreateEmpleado.Size = new Size(174, 58);
            btnCreateEmpleado.TabIndex = 1;
            btnCreateEmpleado.Text = "Alta Empleado";
            btnCreateEmpleado.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreateEmpleado.UseVisualStyleBackColor = false;
            btnCreateEmpleado.Click += btnCreateEmpleado_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(12, 215, 253);
            label1.Location = new Point(12, 88);
            label1.Name = "label1";
            label1.Size = new Size(229, 35);
            label1.TabIndex = 6;
            label1.Text = "Alta de Empleado";
            // 
            // label2
            // 
            label2.Font = new Font("Corbel", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 125);
            label2.Name = "label2";
            label2.Size = new Size(764, 53);
            label2.TabIndex = 7;
            label2.Text = "Ingresa los datos para registrar un nuevo empleado en el sistema.\r\n";
            // 
            // gBoxDPersonales
            // 
            gBoxDPersonales.Controls.Add(panel5);
            gBoxDPersonales.Controls.Add(panel4);
            gBoxDPersonales.Controls.Add(v);
            gBoxDPersonales.Controls.Add(panel3);
            gBoxDPersonales.Controls.Add(panel2);
            gBoxDPersonales.Controls.Add(panel1);
            gBoxDPersonales.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gBoxDPersonales.ForeColor = SystemColors.ControlLightLight;
            gBoxDPersonales.Location = new Point(12, 162);
            gBoxDPersonales.Name = "gBoxDPersonales";
            gBoxDPersonales.Size = new Size(1213, 188);
            gBoxDPersonales.TabIndex = 8;
            gBoxDPersonales.TabStop = false;
            gBoxDPersonales.Text = "DATOS PERSONALES";
            // 
            // panel5
            // 
            panel5.Controls.Add(cboSexo);
            panel5.Controls.Add(lblSexo);
            panel5.Location = new Point(833, 104);
            panel5.Name = "panel5";
            panel5.Size = new Size(329, 63);
            panel5.TabIndex = 6;
            // 
            // cboSexo
            // 
            cboSexo.FlatStyle = FlatStyle.Flat;
            cboSexo.FormattingEnabled = true;
            cboSexo.Location = new Point(3, 30);
            cboSexo.Name = "cboSexo";
            cboSexo.Size = new Size(323, 28);
            cboSexo.TabIndex = 1;
            // 
            // lblSexo
            // 
            lblSexo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSexo.AutoSize = true;
            lblSexo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblSexo.Location = new Point(3, 0);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(56, 23);
            lblSexo.TabIndex = 0;
            lblSexo.Text = "Sexo*\r\n";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtRFC);
            panel4.Controls.Add(lblRFC);
            panel4.Location = new Point(435, 104);
            panel4.Name = "panel4";
            panel4.Size = new Size(329, 63);
            panel4.TabIndex = 5;
            // 
            // txtRFC
            // 
            txtRFC.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtRFC.Location = new Point(3, 26);
            txtRFC.MaxLength = 13;
            txtRFC.Name = "txtRFC";
            txtRFC.Size = new Size(326, 30);
            txtRFC.TabIndex = 1;
            // 
            // lblRFC
            // 
            lblRFC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblRFC.AutoSize = true;
            lblRFC.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblRFC.Location = new Point(3, 0);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(49, 23);
            lblRFC.TabIndex = 0;
            lblRFC.Text = "RFC*\r\n";
            // 
            // v
            // 
            v.Controls.Add(txtCURP);
            v.Controls.Add(lblCURP);
            v.Location = new Point(34, 104);
            v.Name = "v";
            v.Size = new Size(329, 63);
            v.TabIndex = 4;
            // 
            // txtCURP
            // 
            txtCURP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtCURP.Location = new Point(3, 26);
            txtCURP.MaxLength = 18;
            txtCURP.Name = "txtCURP";
            txtCURP.Size = new Size(326, 30);
            txtCURP.TabIndex = 1;
            // 
            // lblCURP
            // 
            lblCURP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCURP.AutoSize = true;
            lblCURP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCURP.Location = new Point(3, 0);
            lblCURP.Name = "lblCURP";
            lblCURP.Size = new Size(62, 23);
            lblCURP.TabIndex = 0;
            lblCURP.Text = "CURP*\r\n";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtApMat);
            panel3.Controls.Add(lblApMat);
            panel3.Location = new Point(830, 26);
            panel3.Name = "panel3";
            panel3.Size = new Size(329, 63);
            panel3.TabIndex = 3;
            // 
            // txtApMat
            // 
            txtApMat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtApMat.Location = new Point(3, 26);
            txtApMat.MaxLength = 100;
            txtApMat.Name = "txtApMat";
            txtApMat.Size = new Size(326, 30);
            txtApMat.TabIndex = 1;
            // 
            // lblApMat
            // 
            lblApMat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblApMat.AutoSize = true;
            lblApMat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblApMat.Location = new Point(3, 0);
            lblApMat.Name = "lblApMat";
            lblApMat.Size = new Size(151, 23);
            lblApMat.TabIndex = 0;
            lblApMat.Text = "Apellido Materno\r\n";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtApPat);
            panel2.Controls.Add(lblApPat);
            panel2.Location = new Point(435, 26);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 63);
            panel2.TabIndex = 2;
            // 
            // txtApPat
            // 
            txtApPat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtApPat.Location = new Point(3, 26);
            txtApPat.MaxLength = 100;
            txtApPat.Name = "txtApPat";
            txtApPat.Size = new Size(326, 30);
            txtApPat.TabIndex = 1;
            // 
            // lblApPat
            // 
            lblApPat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblApPat.AutoSize = true;
            lblApPat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblApPat.Location = new Point(3, 0);
            lblApPat.Name = "lblApPat";
            lblApPat.Size = new Size(153, 23);
            lblApPat.TabIndex = 0;
            lblApPat.Text = "Apellido Paterno*";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(lblNombres);
            panel1.Location = new Point(34, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 63);
            panel1.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtNombre.Location = new Point(3, 26);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(326, 30);
            txtNombre.TabIndex = 1;
            // 
            // lblNombres
            // 
            lblNombres.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNombres.AutoSize = true;
            lblNombres.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNombres.Location = new Point(3, 0);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(103, 23);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombre(s)*";
            // 
            // gBoxDContacto
            // 
            gBoxDContacto.Controls.Add(panel8);
            gBoxDContacto.Controls.Add(panel7);
            gBoxDContacto.Controls.Add(panel6);
            gBoxDContacto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gBoxDContacto.ForeColor = SystemColors.ControlLightLight;
            gBoxDContacto.Location = new Point(13, 546);
            gBoxDContacto.Name = "gBoxDContacto";
            gBoxDContacto.Size = new Size(1212, 104);
            gBoxDContacto.TabIndex = 10;
            gBoxDContacto.TabStop = false;
            gBoxDContacto.Text = "DATOS DE CONTACTO";
            // 
            // panel8
            // 
            panel8.Controls.Add(txtTelefono);
            panel8.Controls.Add(lblTelefono);
            panel8.Location = new Point(835, 26);
            panel8.Name = "panel8";
            panel8.Size = new Size(329, 63);
            panel8.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtTelefono.ForeColor = Color.DarkGray;
            txtTelefono.Location = new Point(3, 26);
            txtTelefono.MaxLength = 10;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(326, 30);
            txtTelefono.TabIndex = 1;
            txtTelefono.Text = "EJ: 7220001234";
            // 
            // lblTelefono
            // 
            lblTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTelefono.Location = new Point(3, 0);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(181, 23);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Número de Teléfono*";
            // 
            // panel7
            // 
            panel7.Controls.Add(txtCorreoSecundario);
            panel7.Controls.Add(lblCorreo2);
            panel7.Location = new Point(434, 26);
            panel7.Name = "panel7";
            panel7.Size = new Size(329, 63);
            panel7.TabIndex = 3;
            // 
            // txtCorreoSecundario
            // 
            txtCorreoSecundario.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtCorreoSecundario.Location = new Point(3, 26);
            txtCorreoSecundario.MaxLength = 100;
            txtCorreoSecundario.Name = "txtCorreoSecundario";
            txtCorreoSecundario.Size = new Size(326, 30);
            txtCorreoSecundario.TabIndex = 1;
            // 
            // lblCorreo2
            // 
            lblCorreo2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCorreo2.AutoSize = true;
            lblCorreo2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCorreo2.Location = new Point(3, 0);
            lblCorreo2.Name = "lblCorreo2";
            lblCorreo2.Size = new Size(158, 23);
            lblCorreo2.TabIndex = 0;
            lblCorreo2.Text = "Correo Secundario";
            // 
            // panel6
            // 
            panel6.Controls.Add(txtCorreoPrincipal);
            panel6.Controls.Add(lblCorreo1);
            panel6.Location = new Point(34, 26);
            panel6.Name = "panel6";
            panel6.Size = new Size(329, 63);
            panel6.TabIndex = 2;
            // 
            // txtCorreoPrincipal
            // 
            txtCorreoPrincipal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtCorreoPrincipal.Location = new Point(3, 26);
            txtCorreoPrincipal.MaxLength = 100;
            txtCorreoPrincipal.Name = "txtCorreoPrincipal";
            txtCorreoPrincipal.Size = new Size(326, 30);
            txtCorreoPrincipal.TabIndex = 1;
            // 
            // lblCorreo1
            // 
            lblCorreo1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCorreo1.AutoSize = true;
            lblCorreo1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCorreo1.Location = new Point(3, 0);
            lblCorreo1.Name = "lblCorreo1";
            lblCorreo1.Size = new Size(147, 23);
            lblCorreo1.TabIndex = 0;
            lblCorreo1.Text = "Correo Principal*";
            // 
            // gBoxDomicilio
            // 
            gBoxDomicilio.Controls.Add(panel15);
            gBoxDomicilio.Controls.Add(panel14);
            gBoxDomicilio.Controls.Add(panel13);
            gBoxDomicilio.Controls.Add(panel12);
            gBoxDomicilio.Controls.Add(panel9);
            gBoxDomicilio.Controls.Add(panel10);
            gBoxDomicilio.Controls.Add(panel11);
            gBoxDomicilio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gBoxDomicilio.ForeColor = SystemColors.ControlLightLight;
            gBoxDomicilio.Location = new Point(13, 356);
            gBoxDomicilio.Name = "gBoxDomicilio";
            gBoxDomicilio.Size = new Size(1212, 184);
            gBoxDomicilio.TabIndex = 9;
            gBoxDomicilio.TabStop = false;
            gBoxDomicilio.Text = "DOMICILIO";
            // 
            // panel15
            // 
            panel15.Controls.Add(cboMunicipio);
            panel15.Controls.Add(lblMunicipio);
            panel15.Location = new Point(832, 108);
            panel15.Name = "panel15";
            panel15.Size = new Size(329, 63);
            panel15.TabIndex = 8;
            // 
            // cboMunicipio
            // 
            cboMunicipio.FlatStyle = FlatStyle.Flat;
            cboMunicipio.FormattingEnabled = true;
            cboMunicipio.Location = new Point(3, 28);
            cboMunicipio.Name = "cboMunicipio";
            cboMunicipio.Size = new Size(323, 28);
            cboMunicipio.TabIndex = 2;
            // 
            // lblMunicipio
            // 
            lblMunicipio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMunicipio.AutoSize = true;
            lblMunicipio.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblMunicipio.Location = new Point(3, 0);
            lblMunicipio.Name = "lblMunicipio";
            lblMunicipio.Size = new Size(98, 23);
            lblMunicipio.TabIndex = 0;
            lblMunicipio.Text = "Municipio*";
            // 
            // panel14
            // 
            panel14.Controls.Add(cboEstado);
            panel14.Controls.Add(lblEstado);
            panel14.Location = new Point(434, 108);
            panel14.Name = "panel14";
            panel14.Size = new Size(329, 63);
            panel14.TabIndex = 7;
            // 
            // cboEstado
            // 
            cboEstado.FlatStyle = FlatStyle.Flat;
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(3, 30);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(323, 28);
            cboEstado.TabIndex = 1;
            cboEstado.SelectedIndexChanged += cboEstado_SelectedIndexChanged;
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblEstado.Location = new Point(3, 0);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(71, 23);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado*\r\n";
            // 
            // panel13
            // 
            panel13.Controls.Add(txtColonia);
            panel13.Controls.Add(lblColonia);
            panel13.Location = new Point(832, 26);
            panel13.Name = "panel13";
            panel13.Size = new Size(329, 63);
            panel13.TabIndex = 5;
            // 
            // txtColonia
            // 
            txtColonia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtColonia.Location = new Point(3, 26);
            txtColonia.MaxLength = 100;
            txtColonia.Name = "txtColonia";
            txtColonia.Size = new Size(326, 30);
            txtColonia.TabIndex = 1;
            // 
            // lblColonia
            // 
            lblColonia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblColonia.AutoSize = true;
            lblColonia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblColonia.Location = new Point(3, 0);
            lblColonia.Name = "lblColonia";
            lblColonia.Size = new Size(78, 23);
            lblColonia.TabIndex = 0;
            lblColonia.Text = "Colonia*";
            // 
            // panel12
            // 
            panel12.Controls.Add(txtCP);
            panel12.Controls.Add(lblCP);
            panel12.Location = new Point(33, 108);
            panel12.Name = "panel12";
            panel12.Size = new Size(329, 63);
            panel12.TabIndex = 6;
            // 
            // txtCP
            // 
            txtCP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtCP.Location = new Point(3, 26);
            txtCP.MaxLength = 5;
            txtCP.Name = "txtCP";
            txtCP.Size = new Size(326, 30);
            txtCP.TabIndex = 1;
            // 
            // lblCP
            // 
            lblCP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCP.AutoSize = true;
            lblCP.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCP.Location = new Point(3, 0);
            lblCP.Name = "lblCP";
            lblCP.Size = new Size(128, 23);
            lblCP.TabIndex = 0;
            lblCP.Text = "Código Postal*";
            // 
            // panel9
            // 
            panel9.Controls.Add(txtNoInt);
            panel9.Controls.Add(lblNoInt);
            panel9.Location = new Point(627, 26);
            panel9.Name = "panel9";
            panel9.Size = new Size(136, 63);
            panel9.TabIndex = 4;
            // 
            // txtNoInt
            // 
            txtNoInt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtNoInt.ForeColor = Color.DarkGray;
            txtNoInt.Location = new Point(3, 26);
            txtNoInt.MaxLength = 5;
            txtNoInt.Name = "txtNoInt";
            txtNoInt.Size = new Size(125, 30);
            txtNoInt.TabIndex = 1;
            // 
            // lblNoInt
            // 
            lblNoInt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNoInt.AutoSize = true;
            lblNoInt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNoInt.Location = new Point(3, 0);
            lblNoInt.Name = "lblNoInt";
            lblNoInt.Size = new Size(106, 23);
            lblNoInt.TabIndex = 0;
            lblNoInt.Text = "No.Interior*";
            // 
            // panel10
            // 
            panel10.Controls.Add(txtNoExt);
            panel10.Controls.Add(lblNoExt);
            panel10.Location = new Point(437, 26);
            panel10.Name = "panel10";
            panel10.Size = new Size(137, 63);
            panel10.TabIndex = 3;
            // 
            // txtNoExt
            // 
            txtNoExt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtNoExt.Location = new Point(3, 26);
            txtNoExt.MaxLength = 5;
            txtNoExt.Name = "txtNoExt";
            txtNoExt.Size = new Size(128, 30);
            txtNoExt.TabIndex = 1;
            // 
            // lblNoExt
            // 
            lblNoExt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNoExt.AutoSize = true;
            lblNoExt.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblNoExt.Location = new Point(3, 0);
            lblNoExt.Name = "lblNoExt";
            lblNoExt.Size = new Size(109, 23);
            lblNoExt.TabIndex = 0;
            lblNoExt.Text = "No.Exterior*";
            // 
            // panel11
            // 
            panel11.Controls.Add(txtCalle);
            panel11.Controls.Add(lblCalle);
            panel11.Location = new Point(34, 26);
            panel11.Name = "panel11";
            panel11.Size = new Size(329, 63);
            panel11.TabIndex = 2;
            // 
            // txtCalle
            // 
            txtCalle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            txtCalle.Location = new Point(3, 26);
            txtCalle.MaxLength = 100;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(326, 30);
            txtCalle.TabIndex = 1;
            // 
            // lblCalle
            // 
            lblCalle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCalle.AutoSize = true;
            lblCalle.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblCalle.Location = new Point(3, 0);
            lblCalle.Name = "lblCalle";
            lblCalle.Size = new Size(57, 23);
            lblCalle.TabIndex = 0;
            lblCalle.Text = "Calle*";
            // 
            // gBoxDEmpresarial
            // 
            gBoxDEmpresarial.Controls.Add(panel16);
            gBoxDEmpresarial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            gBoxDEmpresarial.ForeColor = SystemColors.ControlLightLight;
            gBoxDEmpresarial.Location = new Point(13, 656);
            gBoxDEmpresarial.Name = "gBoxDEmpresarial";
            gBoxDEmpresarial.Size = new Size(402, 104);
            gBoxDEmpresarial.TabIndex = 11;
            gBoxDEmpresarial.TabStop = false;
            gBoxDEmpresarial.Text = "DATOS EMPRESARIAL";
            // 
            // panel16
            // 
            panel16.Controls.Add(cboDepto);
            panel16.Controls.Add(lblDepto);
            panel16.Location = new Point(34, 35);
            panel16.Name = "panel16";
            panel16.Size = new Size(329, 63);
            panel16.TabIndex = 5;
            // 
            // cboDepto
            // 
            cboDepto.FlatStyle = FlatStyle.Flat;
            cboDepto.FormattingEnabled = true;
            cboDepto.Location = new Point(3, 28);
            cboDepto.Name = "cboDepto";
            cboDepto.Size = new Size(323, 28);
            cboDepto.TabIndex = 2;
            // 
            // lblDepto
            // 
            lblDepto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDepto.AutoSize = true;
            lblDepto.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblDepto.Location = new Point(3, 0);
            lblDepto.Name = "lblDepto";
            lblDepto.Size = new Size(135, 23);
            lblDepto.TabIndex = 0;
            lblDepto.Text = "Departamento*";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.Cyan;
            btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnLimpiar.IconColor = Color.Cyan;
            btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLimpiar.IconSize = 32;
            btnLimpiar.Location = new Point(851, 674);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(134, 58);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 192);
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Corbel", 10.2F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.Lime;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            btnAgregar.IconColor = Color.FromArgb(128, 255, 128);
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.IconSize = 32;
            btnAgregar.Location = new Point(1091, 674);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(134, 58);
            btnAgregar.TabIndex = 12;
            btnAgregar.Text = "AGREGAR";
            btnAgregar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDatosObligatorios.ForeColor = Color.Brown;
            lblDatosObligatorios.Location = new Point(453, 693);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(184, 21);
            lblDatosObligatorios.TabIndex = 14;
            lblDatosObligatorios.Text = "Datos obligatorios *";
            // 
            // frmAltaEmpleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(37, 41, 47);
            ClientSize = new Size(1262, 769);
            Controls.Add(lblDatosObligatorios);
            Controls.Add(btnAgregar);
            Controls.Add(btnLimpiar);
            Controls.Add(gBoxDEmpresarial);
            Controls.Add(gBoxDomicilio);
            Controls.Add(gBoxDContacto);
            Controls.Add(gBoxDPersonales);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelBar);
            Name = "frmAltaEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alta de empleados";
            FormClosed += frmAltaEmpleados_FormClosed;
            panelBar.ResumeLayout(false);
            gBoxDPersonales.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            v.ResumeLayout(false);
            v.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gBoxDContacto.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            gBoxDomicilio.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            gBoxDEmpresarial.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FontAwesome.Sharp.IconButton btnEmpleadoAPI;
        private Panel panelBar;
        private FontAwesome.Sharp.IconButton btnDeleteEmpleado;
        private FontAwesome.Sharp.IconButton btnUpdateEmpleado;
        private FontAwesome.Sharp.IconButton btnReadEmpleado;
        private FontAwesome.Sharp.IconButton btnCreateEmpleado;
        private Label label1;
        private Label label2;
        private GroupBox gBoxDPersonales;
        private Panel panel1;
        private TextBox txtNombre;
        private Label lblNombres;
        private Panel v;
        private TextBox txtCURP;
        private Label lblCURP;
        private Panel panel3;
        private TextBox txtApMat;
        private Label lblApMat;
        private Panel panel2;
        private TextBox txtApPat;
        private Label lblApPat;
        private Panel panel5;
        private ComboBox cboSexo;
        private Label lblSexo;
        private Panel panel4;
        private TextBox txtRFC;
        private Label lblRFC;
        private GroupBox gBoxDContacto;
        private Panel panel8;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private Panel panel7;
        private TextBox txtCorreoSecundario;
        private Label lblCorreo2;
        private Panel panel6;
        private TextBox txtCorreoPrincipal;
        private Label lblCorreo1;
        private GroupBox gBoxDomicilio;
        private Panel panel9;
        private TextBox txtNoInt;
        private Label lblNoInt;
        private Panel panel10;
        private TextBox txtNoExt;
        private Label lblNoExt;
        private Panel panel11;
        private TextBox txtCalle;
        private Label lblCalle;
        private Panel panel13;
        private TextBox txtColonia;
        private Label lblColonia;
        private Panel panel12;
        private TextBox txtCP;
        private Label lblCP;
        private Panel panel15;
        private Label lblMunicipio;
        private Panel panel14;
        private ComboBox cboEstado;
        private Label lblEstado;
        private ComboBox cboMunicipio;
        private GroupBox gBoxDEmpresarial;
        private Panel panel16;
        private ComboBox cboDepto;
        private Label lblDepto;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private Label lblDatosObligatorios;
    }
}