using System;
using System.Windows.Forms;


namespace Ejercicio1
{
    public partial class FormMenu : Form
    {
        ProcesoEncuestas proceso = new ProcesoEncuestas();
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnRegistroDeEncuesta_Click(object sender, EventArgs e)
        {
            FormRegistroDeEncuesta fRegistro = new FormRegistroDeEncuesta();

            if (fRegistro.ShowDialog() == DialogResult.OK)
            {
                Encuesta nuevo = new Encuesta();

                nuevo.UsaBicicleta = fRegistro.chkUsaBicicleta.Checked;
                nuevo.UsaAuto = fRegistro.chkUsaAuto.Checked;
                nuevo.UsaTransportePublico = fRegistro.chkTranspPub.Checked;
                nuevo.DistanciaASuDestino = Convert.ToDouble( fRegistro.tbDistanciaASuDestino.Text);

                nuevo.Email = fRegistro.tbEmail.Text;

                bool puedeSerContactado = fRegistro.chkPuedeSerContactado.Checked;

                proceso.RegistrarEncuesta(nuevo, puedeSerContactado);
            }

            fRegistro.Dispose();
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            FormInforme fInforme = new FormInforme();

            fInforme.Text = "Informe.";

            fInforme.listBox1.Items.Add("\t\t Informe de resultados");
            fInforme.listBox1.Items.Add("");
            fInforme.listBox1.Items.Add("Modo de transporte habitual");
            fInforme.listBox1.Items.Add($"\t{"Bicicleta:",-20}  {proceso.PorcBicleta,10:f2}%");
            fInforme.listBox1.Items.Add($"\t{"Automóvil:",-20}  {proceso.PorcAuto,10:f2}%");
            fInforme.listBox1.Items.Add($"\t{"Transporte público:",-20}  {proceso.PorcTranspPublico,10:f2}%");

            fInforme.ShowDialog();
            fInforme.Dispose();
        }

        private void btnListadoContactables_Click(object sender, EventArgs e)
        {
            FormInforme fInforme = new FormInforme();

            fInforme.Text = "Informe.";

            fInforme.listBox1.Items.Add("\t\t Informe de encuestados contactables");
            fInforme.listBox1.Items.Add("");

            proceso.OrdernarEncuestables();
            fInforme.listBox1.Items.Add($"\t{"Email",-30} {"Distancia",10}");
            for (int n = 0; n < proceso.CantContactables; n++)
            {
                fInforme.listBox1.Items.Add($"\t{proceso.VerContactable(n).Email,-30} {proceso.VerContactable(n).DistanciaASuDestino,10:f2}");
            }

            fInforme.ShowDialog();
            fInforme.Dispose();
        }
    }
}
