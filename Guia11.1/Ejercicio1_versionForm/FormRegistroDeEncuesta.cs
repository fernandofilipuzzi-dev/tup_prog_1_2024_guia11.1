using System;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class FormRegistroDeEncuesta : Form
    {
        public FormRegistroDeEncuesta()
        {
            InitializeComponent();
        }

        private void chkPuedeSerContactado_CheckedChanged(object sender, EventArgs e)
        {
            tbEmail.Enabled = chkPuedeSerContactado.Checked;
        }

        private void tbDistanciaASuDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' ||
               char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
