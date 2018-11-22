using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI.PacienteForms
{
    public partial class ConsultarEntrenamiento : IdiomaForm
    {
        GestionarEntrenamiento gestor;
        public Entrenamiento Seleccionado { get; set; }

        public ConsultarEntrenamiento()
        {
            InitializeComponent();
        }

        private void ConsultarEntrenamiento_Load(object sender, EventArgs e)
        {
            Estilo.Nuevo(btnNuevo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Modificar(btnModificar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            gestor = new GestionarEntrenamiento();
            ActualizarLista(gestor.Listar());
        }

        private void ActualizarLista(List<Entrenamiento> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].Width = 25;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Nombre"].Width = 220;
            dataGridView1.Columns["descripcion"].DisplayIndex = 2;
            dataGridView1.Columns["descripcion"].Width = 460;
            if (Seleccionado != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((DatoBase)row.DataBoundItem).Id.Equals(Seleccionado.Id))
                        row.Selected = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Seleccionado = null;
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmEntrenamiento dialog = new AbmEntrenamiento();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(gestor.Listar());
            } else
            {
                ActualizarLista(gestor.Listar());
            }
            dialog.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    Seleccionado = (Entrenamiento)dataGridView1.SelectedRows[0].DataBoundItem;
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
                AbmEntrenamiento dialog = new AbmEntrenamiento();
                dialog.EntrenamientoSeleccionado = (Entrenamiento)dataGridView1.SelectedRows[0].DataBoundItem;
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
            } else
            {
                ActualizarLista(gestor.Listar(txtBuscar.Text));
            }
        }
    }
}
