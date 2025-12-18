using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EmpleadosMorados.Controller;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities; // Para el LoggingManager o extensiones si se usan

namespace EmpleadosMorados.View
{
    public partial class frmActualizaEmpleado : Form
    {
        private EmpleadosController _controller;
        private Empleado _empleadoCargado; // Objeto para guardar los datos al cargar
        private int _idPersonaAActualizar; // ID de la persona que se va a editar

        // =========================================================================
        // CONSTRUCTOR Y CARGA INICIAL
        // =========================================================================

        // Constructor público que debe ser llamado al abrir la ventana (ej: desde frmListaEmpleado)
        public frmActualizaEmpleado(int idPersona)
        {
            InitializeComponent();
            _controller = new EmpleadosController();
            _idPersonaAActualizar = idPersona;
            this.Load += new EventHandler(frmActualizaEmpleado_Load);
        }

        // Si el diseñador usa un constructor vacío, mantenlo, delegando al principal
        // public frmActualizaEmpleado() : this(0) { } 


        private void frmActualizaEmpleado_Load(object sender, EventArgs e)
        {
            // 1. Cargar Catálogos (Estados, Departamentos, etc.)
            CargarCatalogos();

            // 2. Cargar los datos del empleado existente
            if (_idPersonaAActualizar > 0)
            {
                CargarDatosEmpleado(_idPersonaAActualizar);
            }
            else
            {
                MessageBox.Show("Error: ID de empleado no especificado. Cerrando ventana.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        // =========================================================================
        // MÉTODOS DE CONSULTA (SELECT)
        // =========================================================================

        /// <summary>
        /// Obtiene y mapea los datos del empleado del Controller a los controles de la Vista.
        /// </summary>
        private void CargarDatosEmpleado(int idPersona)
        {
            // Llama al método del Controller que a su vez llama a EmpleadosDataAccess.ObtenerEmpleadoPorIdPersona
            _empleadoCargado = _controller.ObtenerEmpleadoParaActualizar(idPersona);

            if (_empleadoCargado != null)
            {
                // -- Mapeo de IDs (ocultos o solo lectura) --
                // Estos IDs son CRUCIALES para que el UPDATE funcione
                //txtIdRegistroLaboral.Text = _empleadoCargado.Id.ToString();
                //txtIdPersona.Text = _empleadoCargado.IdPersona.ToString();

                // -- Mapeo de Datos Personales (USUARIOS) --
                txtNombre.Text = _empleadoCargado.DatosPersonales.NombreCompleto;
                txtApPatAct.Text = _empleadoCargado.DatosPersonales.ApellidoPaterno;
                txtApMatAct.Text = _empleadoCargado.DatosPersonales.ApellidoMaterno;
                txtCURPAct.Text = _empleadoCargado.DatosPersonales.Curp;
                txtRFCAct.Text = _empleadoCargado.DatosPersonales.Rfc;
                txtNoTelAct.Text = _empleadoCargado.DatosPersonales.Telefono;
                cboSexoAct.SelectedItem = _empleadoCargado.DatosPersonales.Sexo;
                textCalleAct.Text = _empleadoCargado.DatosPersonales.Domicilio.Calle;
                txtNoExAct.Text = _empleadoCargado.DatosPersonales.Domicilio.NoExterior;
                txtNoIntAct.Text = _empleadoCargado.DatosPersonales.Domicilio.NoInterior;
                txtColoniaAct.Text = _empleadoCargado.DatosPersonales.Domicilio.Colonia;
                txtCPAct.Text = _empleadoCargado.DatosPersonales.Domicilio.CodigoPostal;
               // cmbEstadoAct = _controller.ObtenerEstados(_empleadoCargado.DatosPersonales.Domicilio);

                // Cargar el valor seleccionado en el ComboBox de Departamento
                cboDeptoAct.SelectedValue = _empleadoCargado.DatosPersonales.IdDepartamento;

                // Mapear Puesto (requiere cargar primero el ComboBox de Puestos)
                cboPuestoAct.SelectedValue = _empleadoCargado.Puesto; // Asume que Puesto es el ID o Key

                // -- NOTA: Mapeo de Domicilio y Correo queda pendiente aquí, requiere métodos auxiliares --

                // Una vez que se selecciona el Departamento, cargar Puestos
                CargarPuestos(cboDeptoAct.SelectedValue.ToString());


            }
            else
            {
                MessageBox.Show($"No se encontró el empleado con ID: {idPersona}.", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        // Métodos de carga de catálogos (DEBEN SER IMPLEMENTADOS)
        private void CargarCatalogos()
        {
            cboDeptoAct.DataSource = _controller.ObtenerDepartamentos();
        }

        private void CargarMunicipios(string idEstado)
        {
            cmbMnAct.DataSource = _controller.ObtenerMunicipiosPorEstado(idEstado);
        }

        private void CargarPuestos(string idDepto)
        {
            cboPuestoAct.DataSource = _controller.ObtenerPuestosPorDepto(idDepto);
        }

        // =========================================================================
        // LÓGICA DEL BOTÓN DE GUARDAR (UPDATE)
        // =========================================================================

        private void btnUpdateEmpleado_Click(object sender, EventArgs e)
        {
            if (_empleadoCargado == null)
            {
                MessageBox.Show("No hay datos cargados para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1. Capturar los datos de la Vista y actualizar el objeto _empleadoCargado

                // --- Datos Personales (USUARIOS) ---
                _empleadoCargado.DatosPersonales.NombreCompleto = txtNombre.Text;
                _empleadoCargado.DatosPersonales.ApellidoPaterno = txtApPatAct.Text; // Usar el nombre de tu control
                _empleadoCargado.DatosPersonales.ApellidoMaterno = txtApMatAct.Text; // Usar el nombre de tu control
                _empleadoCargado.DatosPersonales.Curp = txtCURPAct.Text; // Usar el nombre de tu control
                _empleadoCargado.DatosPersonales.Rfc = txtRFCAct.Text; // Usar el nombre de tu control
                _empleadoCargado.DatosPersonales.Sexo = cboSexoAct.SelectedItem.ToString();
                _empleadoCargado.DatosPersonales.Telefono = txtNoTelAct.Text; // Usar el nombre de tu control
                _empleadoCargado.DatosPersonales.IdDepartamento = cboDeptoAct.SelectedValue.ToString();

                // --- Datos Empresariales (TRAY_LAB) ---
                // Asumiremos que el Puesto en el modelo Empleado.Puesto es el ID, no el nombre
                _empleadoCargado.Puesto = cboPuestoAct.SelectedValue.ToString();

                // NOTA: Matrícula, Sueldo, FechaIngreso, TipoContrato, FechaBaja
                // No están en la vista, por lo que se mantienen los valores cargados en _empleadoCargado
                // (Si el usuario debe poder cambiarlos, se necesita agregar los controles al formulario)

                // --- Datos de Contacto (CORREOS) ---
                // Aquí necesitarás actualizar las propiedades de Correo Principal y Secundario en el objeto Persona:
                // _empleadoCargado.DatosPersonales.CorreoPrincipal = txtCorreoPrincipal.Text;
                // _empleadoCargado.DatosPersonales.CorreoSecundario = txtCorreoSecundario.Text;

                // --- Datos de Domicilio (DOMICILIOS) ---
                _empleadoCargado.DatosPersonales.Domicilio.Calle = textCalleAct.Text;
                _empleadoCargado.DatosPersonales.Domicilio.NoExterior = txtNoExAct.Text;
                _empleadoCargado.DatosPersonales.Domicilio.NoInterior = txtNoIntAct.Text;
                _empleadoCargado.DatosPersonales.Domicilio.Colonia = txtColoniaAct.Text;
                _empleadoCargado.DatosPersonales.Domicilio.CodigoPostal = txtCPAct.Text;
                // El Controller se encarga de obtener el ID_MUNICIPIO

                // 2. Llamar al Controller
                string municipioNombre = cmbMnAct.Text;
                string estadoNombre = cmbEAct.Text;

                //var (codigo, mensaje) = _controller.ActualizarEmpleadoExistente(_empleadoCargado, municipioNombre, estadoNombre);

                //// 3. Manejo de Respuesta
                //if (codigo > 0)
                //{
                //    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show(mensaje, "Error en Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // MÉTODOS DE NAVEGACIÓN (Originales)
        // =========================================================================


        //antes de aqui 
        private void btnCreateEmpleado_Click(object sender, EventArgs e)
        {
            frmAltaEmpleados formAlta = new frmAltaEmpleados();
            formAlta.Show();
            this.Hide();
        }

        private void btnReadEmpleado_Click(object sender, EventArgs e)
        {
            frmListaEmpleado formList = new frmListaEmpleado();
            formList.Show();
            this.Hide();
        }

        // NOTA: El btnUpdateEmpleado_Click se cambió a la lógica de Guardar

        private void btnDeleteEmpleado_Click(object sender, EventArgs e)
        {
            frmEliminaEmpleado formElim = new frmEliminaEmpleado();
            formElim.Show();
            this.Hide();
        }

        private void frmActualizaEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cierra la aplicación entera al cerrar esta ventana
            Application.Exit();
        }
    }
}