using System;
using BLLFuncional;
namespace GUI
{
    public partial class DigitoVerificador : IdiomaForm
    {
        GestionarDV gestor = new GestionarDV();

        public DigitoVerificador()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += gestor.VerificarDVHLog() + Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += gestor.VerificarDVVLog() + Environment.NewLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void DigitoVerificador_Load(object sender, EventArgs e)
        {
            textBox1.Text += gestor.VerificarDVHLog() + Environment.NewLine;
            textBox1.Text += gestor.VerificarDVVLog() + Environment.NewLine;
        }
    }
}
