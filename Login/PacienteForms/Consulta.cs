using BEFuncional;
using BLLFuncional;
using GUI;
using System;
using System.Collections.Generic;
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
            this.AcceptButton = this.btnBuscar;
            gp = new GestionarPaciente();
            listaPaciente = gp.Listar();
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

        private void btnNuevaConsulta_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
