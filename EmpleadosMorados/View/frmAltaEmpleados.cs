using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpleadosMorados.Controller;
using EmpleadosMorados.Model;
using static System.Windows.Forms.DataFormats;

namespace EmpleadosMorados.View
{
    public partial class frmAltaEmpleados : Form
    {
        // Instancia de la clase de negocio para orquestar la inserción
        private readonly EmpleadosController _empleadosNegocio;
        public frmAltaEmpleados()
        {
            InitializeComponent(); // Simulación del método generado por el diseñador
            _empleadosNegocio = new EmpleadosController();
            InicializaVentanaEmpleadoRegistro();
        }
        public void InicializaVentanaEmpleadoRegistro()
        {
            PoblaGenero();
            PoblaDepartamentos();
            PoblaEstados();
            // Otros inicializadores de Placeholders si se necesitan
        }
        private void PoblaGenero()
        {
            // Usamos los valores exactos del DDL: MASCULINO, FEMENINO, OTRO
            Dictionary<string, string> listGenero = new Dictionary<string, string>
            {
                { "MASCULINO", "Masculino" },
                { "FEMENINO", "Femenino" },
                { "OTRO", "Otro" }
            };
            cboSexo.DataSource = new BindingSource(listGenero, null);
            cboSexo.DisplayMember = "Value";
            cboSexo.ValueMember = "Key";
            cboSexo.SelectedIndex = -1;
        }

        private void PoblaDepartamentos()
        {
            // Implementación simplificada
            try
            {
                var departamentos = _empleadosNegocio.ObtenerDepartamentos();
                cboDepto.DataSource = new BindingSource(departamentos, null);
                cboDepto.DisplayMember = "Value";
                cboDepto.ValueMember = "Key";
                cboDepto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PoblaEstados()
        {
            // Implementación simplificada
            try
            {
                var estados = _empleadosNegocio.ObtenerEstados();
                cboEstado.DataSource = new BindingSource(estados, null);
                cboEstado.DisplayMember = "Value";
                cboEstado.ValueMember = "Key";
                cboEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estados: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCreateEmpleado_Click_1(object sender, EventArgs e)
        {
            frmAltaEmpleados formAlta = new frmAltaEmpleados();
            formAlta.Show();
            this.Hide();
        }

        private void btnReadEmpleado_Click_1(object sender, EventArgs e)
        {
            frmListaEmpleado formList = new frmListaEmpleado();
            formList.Show();
            this.Hide();
        }

        private void btnUpdateEmpleado_Click(object sender, EventArgs e)
        {
            frmActualizaEmpleado formActualiza = new frmActualizaEmpleado();
            formActualiza.Show();
            this.Hide();
        }

        private void btnDeleteEmpleado_Click(object sender, EventArgs e)
        {
            frmEliminaEmpleado formElim = new frmEliminaEmpleado();
            formElim.Show();
            this.Hide();
        }

        private void frmAltaEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cuando esta ventana se cierra, cerramos la aplicación entera 
            // para evitar que el menú quede oculto sin forma de salir.
            Application.Exit();

            // O, si tienes una forma de referenciar el formulario anterior, 
            // podrías hacer que se muestre de nuevo. Pero Application.Exit() es más seguro y simple.
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Simulación del ComboBox de Estados
            if (cboEstado.SelectedValue != null && cboEstado.SelectedValue is string idEstado)
            {
                PoblaMunicipios(idEstado);
            }
            else
            {
                cboMunicipio.DataSource = null;
            }
        }
        private void PoblaMunicipios(string idEstado)
        {
            // Implementación simplificada
            try
            {
                var municipios = _empleadosNegocio.ObtenerMunicipiosPorEstado(idEstado);
                cboMunicipio.DataSource = new BindingSource(municipios, null);
                cboMunicipio.DisplayMember = "Value";
                cboMunicipio.ValueMember = "Key";
                cboMunicipio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar municipios: " + ex.Message, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            GuardarEmpleado();
        }
        private void GuardarEmpleado()
        {
            // 1. Validaciones de la Vista (se asume que existe el método ValidarDatosFormulario)
            if (!ValidarDatosFormulario())
            {
                return;
            }

            try
            {
                // ** 2. Mapeo de Domicilio **
                Domicilio domicilio = new Domicilio
                {
                    Calle = txtCalle.Text.Trim(),
                    NoExterior = txtNoExt.Text.Trim(),
                    NoInterior = txtNoInt.Text.Trim(),
                    CodigoPostal = txtCP.Text.Trim(),
                    Colonia = txtColonia.Text.Trim(),
                    Estado = cboEstado.Text,
                    Municipio = cboMunicipio.Text
                    // El campo IdMunicipio se obtendrá en la capa de negocio
                };

                // ** 3. Mapeo de Persona (USUARIOS, CORREOS) **
                Persona persona = new Persona
                {
                    NombreCompleto = txtNombre.Text.Trim(),
                    ApellidoPaterno = txtApPat.Text.Trim(),
                    ApellidoMaterno = txtApMat.Text.Trim(),
                    Curp = txtCURP.Text.Trim(),
                    Rfc = txtRFC.Text.Trim(),
                    Sexo = cboSexo.SelectedValue?.ToString() ?? "OTRO",
                    Telefono = txtTelefono.Text.Trim(),
                    CorreoPrincipal = txtCorreoPrincipal.Text.Trim(),
                    CorreoSecundario = txtCorreoSecundario.Text.Trim(),
                    IdDepartamento = cboDepto.SelectedValue?.ToString(),
                    Domicilio = domicilio,
                    Estatus = "ACTIVO"
                };

                // ** 4. Mapeo de Empleado (TRAY_LAB) **
                Empleado empleado = new Empleado
                {
                    // La vista solo tiene un campo de departamento, el resto se asume o se setea por defecto.
                    // Si la vista tuviera Matricula, Sueldo, Puesto, se mapearían aquí.
                    Matricula = "NA-0000",
                    Puesto = "N/A",
                    Sueldo = 0.00m,
                    TipoContrato = "INDEFINIDO",
                    FechaIngreso = DateTime.Now,
                    DatosPersonales = persona
                };

                // ** 5. Llamar al Controlador/Negocio **
                // Se envían los nombres de municipio/estado para que el negocio obtenga el ID_MUNICIPIO
                var (id, mensaje) = _empleadosNegocio.RegistrarNuevoEmpleado(empleado, cboMunicipio.Text, cboEstado.Text);

                if (id > 0)
                {
                    MessageBox.Show($"Empleado registrado: ID {id}. {mensaje}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Fallo en el registro: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico en la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // --- Métodos Auxiliares (Limpieza y Validación) ---

        private bool ValidarDatosFormulario()
        {
            // ******* Lógica de validación de campos obligatorios *******
            // Aquí se debe replicar la lógica de DatosVacios y DatosValidos

            // Validación de combos
            if (cboSexo.SelectedValue == null || cboDepto.SelectedValue == null ||
                cboEstado.SelectedValue == null || cboMunicipio.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una opción válida en todos los menús desplegables.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de campos de texto obligatorios (solo un ejemplo parcial)
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtRFC.Text) ||
                string.IsNullOrWhiteSpace(txtCorreoPrincipal.Text) || string.IsNullOrWhiteSpace(txtCalle.Text))
            {
                MessageBox.Show("Los campos con * son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de formatos (ejemplo)
            // if (!Validaciones.EsRFCValido(txtRFC.Text))
            // {
            //     MessageBox.Show("Formato de RFC inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     return false;
            // }

            return true;
        }

        private void LimpiarCampos()
        {
           txtNombre.Text = string.Empty;
           txtApPat.Text = string.Empty;
            txtApMat.Text = string.Empty;
            txtCURP.Text = string.Empty;
            txtRFC.Text = string.Empty;
            cboSexo.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtColonia.Text = string.Empty;
            txtCP.Text = string.Empty;
            cboEstado.Text = string.Empty;
            cboMunicipio.Text = string.Empty;
            txtCorreoPrincipal.Text = string.Empty;
            txtCorreoSecundario.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            cboDepto.Text = string.Empty;
            // ...
            InicializaVentanaEmpleadoRegistro(); // La forma más simple de resetear combos y reestablecer estados
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
