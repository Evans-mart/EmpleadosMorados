using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmpleadosMorados.View
{
    public partial class frmListaEmpleado : Form
    {
        public frmListaEmpleado()
        {
            InitializeComponent();
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

        private void btnCreateEmpleado_Click(object sender, EventArgs e)
        {
            frmAltaEmpleados formAlta = new frmAltaEmpleados();
            formAlta.Show();
            this.Hide();
        }

        private void btnDeleteEmpleado_Click(object sender, EventArgs e)
        {
            frmEliminaEmpleado formElim = new frmEliminaEmpleado();
            formElim.Show();
            this.Hide();
        }

        private void frmListaEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cuando esta ventana se cierra, cerramos la aplicación entera 
            // para evitar que el menú quede oculto sin forma de salir.
            Application.Exit();

            // O, si tienes una forma de referenciar el formulario anterior, 
            // podrías hacer que se muestre de nuevo. Pero Application.Exit() es más seguro y simple.
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BotonBuscar_Click(object sender, EventArgs e)
        {
            try {
                string nombre = textnombre.Text;
                string numeroUsuario = txtUsuario.Text;
                string estatus = comboBox1.SelectedValue?.ToString() ?? "";
                string depto = comboDepto.SelectedValue?.ToString() ?? "";

                DataTable dtUsuarios = EmpleadosMorados.Bussines.ListaEmpleados.ObtenerUsuarios(nombre, numeroUsuario, estatus, depto);
                dgvusuarios.DataSource = dtUsuarios;
                dgvusuarios.AutoResizeColumns();

                if (dtUsuarios == null || dtUsuarios.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros con los filtros seleccionados.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvusuarios.DataSource = null; // Limpia el grid
                }
                else
                {
                    dgvusuarios.DataSource = dtUsuarios;
                    MessageBox.Show("Filas encontradas: " + dtUsuarios.Rows.Count);
                    dgvusuarios.AutoResizeColumns();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmListaEmpleado_Load(object sender, EventArgs e)
        {
            // Llenar Departamento
            DataTable dtDepto = EmpleadosMorados.Bussines.ListaEmpleados.ObtenerDepartamentos();
            comboDepto.DataSource = dtDepto;
            comboDepto.DisplayMember = "NOMBRE_DEPTO"; // lo que verá el usuario
            comboDepto.ValueMember = "ID_DEPTO";       // el valor real que usarás en consultas
            comboDepto.SelectedIndex = -1;             // para que inicie vacío

            // Llenar Estatus
            DataTable dtEstatus = EmpleadosMorados.Bussines.ListaEmpleados.ObtenerEstatus();
            comboBox1.DataSource = dtEstatus;
            comboBox1.DisplayMember = "ESTATUS";
            comboBox1.ValueMember = "ESTATUS";
            comboBox1.SelectedIndex = -1;
        }


    }



}
