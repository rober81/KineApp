using System;

namespace GUI
{
    public partial class DigitoVerificador : IdiomaForm
    {
        public DigitoVerificador()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += BLL.GestionarDigitoVerificador.VerificarDVH() + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += BLL.GestionarDigitoVerificador.CalcularDVH() + Environment.NewLine;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += BLL.GestionarDigitoVerificador.VerificarDVV() + Environment.NewLine;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += BLL.GestionarDigitoVerificador.CalcularDVV() + Environment.NewLine;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
