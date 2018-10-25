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
    public partial class Consulta : IdiomaForm
    {
        private List<Paciente> listaPaciente;
        private GestionarPaciente gp;

        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnNuevaConsulta);
            Estilo.Buscar(btnBuscar);
            gp = new GestionarPaciente();
            listaPaciente = gp.Listar();
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
                ActualizarLista(gp.Listar(txtBuscar.Text));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarLista(listaPaciente);
        }
    }
}
