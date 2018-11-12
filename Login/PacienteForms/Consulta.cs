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
            Estilo.Modificar(btnModificar);
            Estilo.Nuevo(btnNuevo);
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
            dataGridView1.Columns["Nombre"].Width = 250;
            dataGridView1.Columns["Apellido"].DisplayIndex = 2;
            dataGridView1.Columns["Apellido"].Width = 250;
            dataGridView1.Columns["FechaNacimiento"].DisplayIndex = 3;
            dataGridView1.Columns["FechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
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

 

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Owner == null)
            {
                this.Close();
            }
            else
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    //seleccionado = (Paciente)dataGridView1.SelectedRows[0].DataBoundItem;
                }
                else
                {
                    //seleccionado = null;
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ConsultaTratamiento dialog = new ConsultaTratamiento();
                //dialog.seleccionado = (Ejercicio)dataGridView1.SelectedRows[0].DataBoundItem;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                   // ActualizarLista(ge.Listar());
                }
                else
                {
                    //ActualizarLista(ge.Listar());
                }
                dialog.Dispose();
            }

        }
    }
}
