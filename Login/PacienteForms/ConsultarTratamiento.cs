using BEFuncional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConsultaTratamiento : IdiomaForm
    {
        public Paciente PacienteSeleccionado { get; set; }

        public ConsultaTratamiento()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbmEntrenamiento entrenamiento = new AbmEntrenamiento();
            entrenamiento.MdiParent = this.MdiParent;
            entrenamiento.StartPosition = FormStartPosition.CenterScreen;
            entrenamiento.Show();
        }

        private void ConsultaTratamiento_Load(object sender, EventArgs e)
        {

        }
    }
}
