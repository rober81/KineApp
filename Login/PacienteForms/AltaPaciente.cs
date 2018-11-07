using BEFuncional;
using BLLFuncional;
using GUI;
using System;

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
                if (this.ValidarTextbox())
                {
                    Paciente pa = new Paciente();
                    pa.Dni = int.Parse(txtDni.Text.Trim());
                    pa.Nombre = txtNombre.Text.Trim();
                    pa.Apellido = txtApellido.Text.Trim();
                    pa.FechaNacimiento = dateTimePicker1.Value;
                    int respuesta = GestionarPaciente.Insertar(pa);
                    if (respuesta == 0)
                        Mensaje("msgErrorAltaPaciente", "msgError");
                    else
                    {
                        Mensaje("msgOperacionOk");
                        txtDni.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtApellido.Text = string.Empty;
                    }
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
            this.AcceptButton = this.btnAceptar;
        }
    }
}
