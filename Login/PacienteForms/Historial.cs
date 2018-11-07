using BEFuncional;
using BLLFuncional;
using GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class Historial : IdiomaForm
    {
        private List<Paciente> listaPaciente;
        private GestionarPaciente gp;

        public Historial()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                ActualizarLista(gp.Listar(txtBuscar.Text));
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarLista(listaPaciente);
        }

        private void ActualizarLista(List<Paciente> pacientes)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pacientes;
            dataGridView1.Columns["Dni"].DisplayIndex = 0;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Apellido"].DisplayIndex = 2;
            dataGridView1.Columns["FechaNacimiento"].DisplayIndex = 3;
            dataGridView1.Columns["DVH"].DisplayIndex = 4;
            dataGridView1.Columns["DVH"].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            Estilo.Buscar(btnBuscar);
            this.AcceptButton = this.btnBuscar;
            gp = new GestionarPaciente();
            listaPaciente = gp.Listar();
            ActualizarLista(listaPaciente);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
