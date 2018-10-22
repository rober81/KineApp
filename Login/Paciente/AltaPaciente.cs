using BEFuncional;
using BLLFuncional;
using GUI.Personalizado;
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
    public partial class AltaPaciente : IdiomaForm
    {
        public AltaPaciente()
        {
            InitializeComponent();
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validarTextbox())
                {
                    Paciente pa = new Paciente();
                    pa.Dni = int.Parse(textBox1.Text);
                    pa.Nombre = textBox2.Text;
                    pa.Apellido = textBox3.Text;
                    pa.FechaNacimiento = dateTimePicker1.Value;
                    GestionarPaciente.Insertar(pa);
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void AltaPaciente_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }
    }
}
