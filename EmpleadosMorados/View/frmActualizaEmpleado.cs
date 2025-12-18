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
                        cboEstado.SelectedValue = idEstado;

                        // Forzar carga de municipios para este estado
                        var municipios = catalogos.ObtenerMunicipiosPorEstado(idEstado);
                        cboMunicipio.ValueMember = "Key";
                        cboMunicipio.DisplayMember = "Value";
                        cboMunicipio.DataSource = new BindingSource(municipios, null);

                        if (row["ID_MUNICIPIO"] != DBNull.Value)
                            cboMunicipio.SelectedValue = row["ID_MUNICIPIO"].ToString().Trim();
                    }

                    // --- CONTACTO (CORREGIDO) ---
                    txtEmail1Act.Text = row["CORREO_PRINCIPAL"] != DBNull.Value ? row["CORREO_PRINCIPAL"].ToString() : "";
                    // Validación para el secundario (según tu imagen 3 de Postgres llega como [null])
                    txtEmail2Act.Text = (row["CORREO_SECUNDARIO"] != DBNull.Value && row["CORREO_SECUNDARIO"].ToString() != "[null]")
                                        ? row["CORREO_SECUNDARIO"].ToString() : "";
                    txtNoTelAct.Text = row["TELEFONO"].ToString();

                    // --- EMPRESARIALES ---
                    if (row["ID_DEPTO"] != DBNull.Value)
                    {
                        string idDepto = row["ID_DEPTO"].ToString().Trim();
                        cboDeptoAct.SelectedValue = idDepto;

                        var puestos = catalogos.ObtenerPuestosPorDepto(idDepto);
                        cboPuestoAct.ValueMember = "Key";
                        cboPuestoAct.DisplayMember = "Value";
                        cboPuestoAct.DataSource = new BindingSource(puestos, null);

                        if (row["ID_PUESTO"] != DBNull.Value)
                            cboPuestoAct.SelectedValue = row["ID_PUESTO"].ToString().Trim();
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
    }
}
