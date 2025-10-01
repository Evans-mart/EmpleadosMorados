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

namespace EmpleadosMorados.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1️ Validar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El campo de correo no puede estar vacío...", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacío...", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 2️ Validar formato del correo
            if (!UsuarioNegocios.EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("El campo de correo no tiene el formato correcto...", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 3 Verificar credenciales y obtener rol
            //var controller = new UsuariosController();
            //var (autenticado, rol, mensaje) = controller.AutenticarUsuario(txtCorreo.Text, txtContraseña.Text);
            //if (autenticado)
            //{
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show(mensaje, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            // 3️ Crear y mostrar el formulario de administrador
            Forma1 form = new Forma1();
            form.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Cuando esta ventana se cierra, cerramos la aplicación entera 
            // para evitar que el menú quede oculto sin forma de salir.
            Application.Exit();

            // O, si tienes una forma de referenciar el formulario anterior, 
            // podrías hacer que se muestre de nuevo. Pero Application.Exit() es más seguro y simple.
        }
    }
}
