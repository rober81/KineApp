using BEFuncional;
using BLLFuncional;
using GUI.Personalizado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Consulta : Form
    {
        private List<Paciente> listaPaciente; 

        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnNuevaConsulta);
            Estilo.Buscar(btnBuscar);
            listaPaciente = GestionarPaciente.Listar();
            ActualizarLista(listaPaciente);
        }

        private void ActualizarLista(List<Paciente> pacientes)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = pacientes;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                string busqueda = txtBuscar.Text;
                IEnumerable<Paciente> filtro = from item in listaPaciente
                                               where item.Nombre.Contains(busqueda) ||
                                               item.Apellido.Contains(busqueda) ||
                                               item.Dni.ToString().Contains(busqueda)
                                               select item;
                ActualizarLista(filtro.ToList<Paciente>());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarLista(listaPaciente);
        }
    }
}
