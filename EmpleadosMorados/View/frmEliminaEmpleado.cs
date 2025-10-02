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
using EmpleadosMorados.Utilities;

namespace EmpleadosMorados.View
{
    public partial class frmEliminaEmpleado : Form
    {
        public frmEliminaEmpleado()
        {
            InitializeComponent();
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

        private void frmEliminaEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cuando esta ventana se cierra, cerramos la aplicación entera 
            // para evitar que el menú quede oculto sin forma de salir.
            Application.Exit();

            // O, si tienes una forma de referenciar el formulario anterior, 
            // podrías hacer que se muestre de nuevo. Pero Application.Exit() es más seguro y simple.
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Quieres continuar con la eliminacion?",
                "Continuar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // 1. La UI llama a la Capa de Lógica de Negocio (BLL).
                    var usuarioService = new DelUser();


                    DataGridViewRow filaSeleccionada = dgvResultados.SelectedRows[0];
                    int idParaBorrar = Convert.ToInt32(filaSeleccionada.Cells["NUMERO_USUARIO"].Value);

                    string nombreCompleto = usuarioService.VerificarYObtenerNombreUsuario(idParaBorrar);

                    // 2. La UI interpreta la respuesta de la BLL y muestra el mensaje apropiado.
                    if (nombreCompleto != null)
                    {
                        DialogResult borrar = MessageBox.Show(
                            $"¿Estás seguro de que deseas borrar al usuario: {nombreCompleto}?",
                            "Confirmar Borrado",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (borrar == DialogResult.Yes)
                        {
                            usuarioService.EliminarUsuarioPermanentemente(idParaBorrar);
                            MessageBox.Show("usuario eliminado", "confirmar");
                        }

                    }
                    else
                    {
                        MessageBox.Show(
                            "El usuario no fue encontrado en la base de datos.",
                            "Usuario No Encontrado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                catch (Exception ex)
                {
                    // La UI es responsable de mostrar los errores al usuario final.
                    MessageBox.Show(
                        "Ocurrió un error inesperado: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Leemos los dos campos de texto
            string nombre = txtNombreBusqueda.Text;
            string apellido = txtApellidoBusqueda.Text;

            // Validamos que el usuario haya llenado ambos campos
            if (Validaciones.EsNombreValido(nombre) || Validaciones.EsApellidoValido(apellido))
            {
                MessageBox.Show("Por favor, ingresa tanto el nombre como el apellido paterno para buscar.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuarioService = new DelUser();
            try
            {
                // Llamamos al nuevo método de la BLL que busca por ambos campos
                DataTable resultados = usuarioService.BuscarUsuariosPorNombreYApellido(nombre, apellido);

                dgvResultados.DataSource = resultados;

                if (resultados.Rows.Count == 0)
                {
                    btnConfirmarBorrar.Enabled = false;
                    MessageBox.Show("No se encontró ningún empleado con ese nombre y apellido.", "Sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvResultados_SelectionChanged(object sender, EventArgs e)
        {
            // Aquí va la lógica para habilitar/deshabilitar el botón de Confirmar Baja
            if (dgvResultados.SelectedRows.Count > 0)
            {
                btnConfirmarBorrar.Enabled = true;
            }
            else
            {
                btnConfirmarBorrar.Enabled = false;
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Quieres continuar con la baja?",
                "Continuar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // 1. La UI llama a la Capa de Lógica de Negocio (BLL).
                    var usuarioService = new DelUser();


                    DataGridViewRow filaSeleccionada = dgvResultados.SelectedRows[0];
                    int idParaBorrar = Convert.ToInt32(filaSeleccionada.Cells["NUMERO_USUARIO"].Value);

                    string nombreCompleto = usuarioService.VerificarYObtenerNombreUsuario(idParaBorrar);

                    // 2. La UI interpreta la respuesta de la BLL y muestra el mensaje apropiado.
                    if (nombreCompleto != null)
                    {
                        DialogResult borrar = MessageBox.Show(
                            $"¿Estás seguro de que deseas dar de baja al usuario: {nombreCompleto}?",
                            "Confirmar Borrado",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);
                        if (borrar == DialogResult.Yes)
                        {
                            usuarioService.DarDeBajaUsuario(idParaBorrar);
                            MessageBox.Show("usuario dado de baja", "confirmar");
                        }

                    }
                    else
                    {
                        MessageBox.Show(
                            "El usuario no fue encontrado en la base de datos.",
                            "Usuario No Encontrado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                catch (Exception ex)
                {
                    // La UI es responsable de mostrar los errores al usuario final.
                    MessageBox.Show(
                        "Ocurrió un error inesperado: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtApellidoBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
