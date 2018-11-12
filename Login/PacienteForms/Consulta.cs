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
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Nuevo(btnNuevo);
            gp = new GestionarPaciente();
            listaPaciente = gp.Listar();
            ActualizarLista(listaPaciente);
        }

        private void ActualizarLista(List<Paciente> pacientes)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pacientes;
            dataGridView1.Columns["dni"].DisplayIndex = 0;
            dataGridView1.Columns["nombre"].DisplayIndex = 1;
            dataGridView1.Columns["nombre"].Width = 200;
            dataGridView1.Columns["apellido"].DisplayIndex = 2;
            dataGridView1.Columns["apellido"].Width = 200;
            dataGridView1.Columns["fechaNacimiento"].DisplayIndex = 3;
            dataGridView1.Columns["fechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["DVH"].DisplayIndex = 4;
            dataGridView1.Columns["DVH"].Visible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                ActualizarLista(gp.Listar());
            }
            else
            {
                ActualizarLista(gp.Listar(txtBuscar.Text));
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
