using BEFuncional;
using BLLFuncional;
using GUI.Personalizado;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GUI
{
    public partial class ModificarPaciente : IdiomaForm
    {
        private List<Paciente> lista;

        public ModificarPaciente()
        {
            InitializeComponent();
        }

        private void ModificarPaciente_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Buscar(btnBuscar);
            lista = GestionarPaciente.Listar();
            ActualizarLista(lista);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
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
                    int respuesta = GestionarPaciente.Modificar(pa);
                    if (respuesta == 0)
                        Mensaje("msgPacienteNoEncontrado", "msgError");
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void ActualizarLista(List<Paciente> pacientes)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = pacientes;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (! string.IsNullOrWhiteSpace(textBox5.Text))
            {
                string busqueda = textBox5.Text;
                IEnumerable<Paciente> filtro = from item in lista
                                               where item.Nombre.Contains(busqueda) ||
                                               item.Apellido.Contains(busqueda) ||
                                               item.Dni.ToString().Contains(busqueda)
                                               select item;
                ActualizarLista(filtro.ToList<Paciente>());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarLista(lista);
        }
    }
}
