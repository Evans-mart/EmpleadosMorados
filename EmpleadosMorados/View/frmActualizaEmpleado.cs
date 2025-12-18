using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpleadosMorados.Bussines;
using EmpleadosMorados.Data;

namespace EmpleadosMorados.View
{
    public partial class frmActualizaEmpleado : Form
    {
        private void PoblaGenero()
        {
            // Usamos los valores exactos del DDL: MASCULINO, FEMENINO, OTRO
            Dictionary<string, string> listGenero = new Dictionary<string, string>
            {
                { "MASCULINO", "Masculino" },
                { "FEMENINO", "Femenino" },
                { "OTRO", "Otro" }
            };
            cboSexoAct.DataSource = new BindingSource(listGenero, null);
            cboSexoAct.DisplayMember = "Value";
            cboSexoAct.ValueMember = "Key";
            cboSexoAct.SelectedIndex = -1;
        }
        public frmActualizaEmpleado()
        {
            InitializeComponent();
            PoblaGenero();
        }

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

        private void frmActualizaEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cuando esta ventana se cierra, cerramos la aplicación entera 
            // para evitar que el menú quede oculto sin forma de salir.
            Application.Exit();

            // O, si tienes una forma de referenciar el formulario anterior, 
            // podrías hacer que se muestre de nuevo. Pero Application.Exit() es más seguro y simple.
        }

        private void txtIdActualiza_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada NO es un dígito (número).
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back) // Permite la tecla 'Back' (borrar)
            {
                // Si no es un dígito ni la tecla Back, anula el evento.
                // Esto evita que el carácter se muestre en el TextBox.
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdActualiza.Text))
            {
                MessageBox.Show("Por favor, ingrese un ID válido.");
                return;
            }

            try
            {
                int id = int.Parse(txtIdActualiza.Text);
                DataTable dt = EmpleadosMorados.Data.ActualizaDataAccess.ObtenerEmpleadoPorId(id);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    CatalogosDataAccess catalogos = new CatalogosDataAccess();

                    // --- DATOS PERSONALES ---
                    txtNombreAct.Text = row["NOMBRE"].ToString();
                    txtApPatAct.Text = row["APELLIDO_PAT"].ToString();
                    txtApMatAct.Text = row["APELLIDO_MAT"].ToString();
                    txtCURPAct.Text = row["CURP"].ToString();
                    txtRFCAct.Text = row["RFC"].ToString();


                    cboSexoAct.Text = row["SEXO"].ToString().Trim();

                    // --- DOMICILIO Y ESTADO ---
                    txtCalle.Text = row["CALLE"].ToString();
                    txtNoExt.Text = row["NO_EXT"].ToString();
                    txtNoInt.Text = row["NO_INT"].ToString();
                    txtColonia.Text = row["COLONIA"].ToString();
                    txtCP.Text = row["CP"].ToString();

                    if (row["ID_ESTADO"] != DBNull.Value)
                    {
                        string idEstado = row["ID_ESTADO"].ToString().Trim();

                        // Al asignar el SelectedValue, se disparará automáticamente cboEstado_SelectedIndexChanged
                        // El cual cargará la lista de municipios correspondiente.
                        cboEstado.SelectedValue = idEstado;

                        // Ahora sí, asignamos el municipio específico del empleado
                        if (row["ID_MUNICIPIO"] != DBNull.Value)
                            cboMunicipio.SelectedValue = row["ID_MUNICIPIO"].ToString().Trim();
                    }

                    // --- CONTACTO (CORREGIDO) ---
                    txtEmail1Act.Text = row["CORREO_PRINCIPAL"] != DBNull.Value ? row["CORREO_PRINCIPAL"].ToString() : "";
                    // Validación para el secundario (según tu imagen 3 de Postgres llega como [null])
                    string correoSec = row["CORREO_SECUNDARIO"].ToString();
                    txtEmail2Act.Text = (correoSec == "[null]" || string.IsNullOrEmpty(correoSec)) ? "" : correoSec;
                    txtNoTelAct.Text = row["TELEFONO"].ToString();

                    // --- EMPRESARIALES ---
                    if (row["ID_DEPTO"] != DBNull.Value)
                    {
                        string idDepto = row["ID_DEPTO"].ToString().Trim();

                        // Al asignar este valor, se dispara cboDeptoAct_SelectedIndexChanged
                        // el cual poblará la lista de puestos correspondiente a este depto.
                        cboDeptoAct.SelectedValue = idDepto;

                        // Una vez que la lista de puestos ya existe, seleccionamos el del empleado
                        if (row["ID_PUESTO"] != DBNull.Value)
                        {
                            cboPuestoAct.SelectedValue = row["ID_PUESTO"].ToString().Trim();
                        }
                    }
                }
                else { MessageBox.Show("No se encontró al empleado."); }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void frmActualizaEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                CatalogosDataAccess catalogos = new CatalogosDataAccess();

                // 1. Departamentos
                var deptos = catalogos.ObtenerDepartamentosActivos();
                cboDeptoAct.ValueMember = "Key";     // ID_DEPTO
                cboDeptoAct.DisplayMember = "Value"; // NOMBRE_DEPTO
                cboDeptoAct.DataSource = new BindingSource(deptos, null);
                cboDeptoAct.SelectedIndex = -1;

                // 2. Estados
                var estados = catalogos.ObtenerEstadosActivos();
                cboEstado.ValueMember = "Key";      // ID_ESTADO
                cboEstado.DisplayMember = "Value";  // NOM_ESTADO
                cboEstado.DataSource = new BindingSource(estados, null);
                cboEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 1. Validación básica de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtIdActualiza.Text) || string.IsNullOrWhiteSpace(txtNombreAct.Text))
            {
                MessageBox.Show("Por favor, busque un empleado y llene los campos obligatorios.");
                return;
            }
            try
            {
                // Recolección de datos
                int id = int.Parse(txtIdActualiza.Text);

                // El teléfono se envía como string, el CAST en el SQL lo convertirá a numeric
                string telefono = txtNoTelAct.Text.Trim();
                string cp = txtCP.Text.Trim();

                bool exito = ActualizaDataAccess.ActualizarEmpleado(
                    id,
                    txtNombreAct.Text.Trim(),
                    txtApPatAct.Text.Trim(),
                    txtApMatAct.Text.Trim(),
                    txtCURPAct.Text.Trim(),
                    txtRFCAct.Text.Trim(),
                    cboSexoAct.SelectedValue?.ToString() ?? "OTRO",
                    telefono,
                    txtCalle.Text.Trim(),
                    txtNoExt.Text.Trim(),
                    txtNoInt.Text.Trim(),
                    txtColonia.Text.Trim(),
                    cp,
                    cboMunicipio.SelectedValue?.ToString(),
                    txtEmail1Act.Text.Trim(),
                    txtEmail2Act.Text.Trim(),
                    cboDeptoAct.SelectedValue?.ToString(),
                    cboPuestoAct.SelectedValue?.ToString()
                );

                if (exito)
                {
                    MessageBox.Show("¡Información actualizada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNoTelAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada NO es un dígito (número).
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back) // Permite la tecla 'Back' (borrar)
            {
                // Si no es un dígito ni la tecla Back, anula el evento.
                // Esto evita que el carácter se muestre en el TextBox.
                e.Handled = true;
            }
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos que haya un valor seleccionado y que sea un string (el ID del estado)
            if (cboEstado.SelectedValue != null && cboEstado.SelectedValue is string idEstado)
            {
                try
                {
                    CatalogosDataAccess catalogos = new CatalogosDataAccess();
                    var municipios = catalogos.ObtenerMunicipiosPorEstado(idEstado);

                    // Importante: Limpiamos el DataSource anterior antes de asignar el nuevo
                    cboMunicipio.DataSource = null;
                    cboMunicipio.ValueMember = "Key";
                    cboMunicipio.DisplayMember = "Value";
                    cboMunicipio.DataSource = new BindingSource(municipios, null);
                    cboMunicipio.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar municipios: " + ex.Message);
                }
            }
        }

        private void cboDeptoAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDeptoAct.SelectedValue != null && cboDeptoAct.SelectedValue is string idDepto)
            {
                try
                {
                    CatalogosDataAccess catalogos = new CatalogosDataAccess();
                    var puestos = catalogos.ObtenerPuestosPorDepto(idDepto);

                    cboPuestoAct.DataSource = null;
                    cboPuestoAct.ValueMember = "Key";
                    cboPuestoAct.DisplayMember = "Value";
                    cboPuestoAct.DataSource = new BindingSource(puestos, null);
                    cboPuestoAct.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar puestos: " + ex.Message);
                }
            }
        }
    }
}
