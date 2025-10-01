using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace EmpleadosMorados.View
{
    public partial class frmAltaEmpleados : Form
    {
        public frmAltaEmpleados()
        {
            InitializeComponent();
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
    }
}
