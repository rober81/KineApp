using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.PacienteForms
{
    public partial class ConsultarPaciente : IdiomaForm
    {
        GestionarPaciente gestor;
        public Paciente Seleccionado { get; set; }

        public ConsultarPaciente()
        {
            InitializeComponent();
        }

        private void ConsultarPaciente_Load(object sender, EventArgs e)
        {
            Estilo.Nuevo(btnNuevo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Modificar(btnModificar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            gestor = new GestionarPaciente();
            ActualizarLista(gestor.Listar());
        }

        private void ActualizarLista(List<Paciente> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Dni"].Width = 100;
            dataGridView1.Columns["Nombre"].Width = 300;
            dataGridView1.Columns["Apellido"].Width = 300;
            dataGridView1.Columns["Dni"].DisplayIndex = 0;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Apellido"].DisplayIndex = 2;
            dataGridView1.Columns["FechaNacimiento"].Visible = false;
            dataGridView1.Columns["DVH"].Visible = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmPaciente dialog = new AbmPaciente();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(gestor.Listar());
            }
            dialog.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    Seleccionado = (Paciente)dataGridView1.SelectedRows[0].DataBoundItem;
                else
                    Seleccionado = null;
            }
            else
                this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AbmPaciente dialog = new AbmPaciente();
                dialog.Seleccionado = (Paciente)dataGridView1.SelectedRows[0].DataBoundItem;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarLista(gestor.Listar());
                }
                dialog.Dispose();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((txtBuscar.Text)))
            {
                ActualizarLista(gestor.Listar());
            }
            else
            {
                ActualizarLista(gestor.Listar(txtBuscar.Text));
            }
        }
    }
}
