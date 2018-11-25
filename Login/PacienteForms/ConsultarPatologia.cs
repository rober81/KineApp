using BEFuncional;
using BLLFuncional;
using GUI.PacienteForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConsultarPatologia : IdiomaForm
    {
        GestionarPatologia gestor;
        public Patologia Seleccionado { get; set; }

        public ConsultarPatologia()
        {
            InitializeComponent();
        }

        private void ConsultaPatologia_Load(object sender, EventArgs e)
        {
            Estilo.Nuevo(btnNuevo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Modificar(btnModificar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            gestor = new GestionarPatologia();
            ActualizarLista(gestor.Listar());
        }

        private void ActualizarLista(List<Patologia> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].Width = 25;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Nombre"].Width = 220;
            dataGridView1.Columns["descripcion"].DisplayIndex = 2;
            dataGridView1.Columns["descripcion"].Width = 460;
            dataGridView1.Columns["PalabrasClave"].Width = 120;
            if (Seleccionado != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((DatoBase)row.DataBoundItem).Id.Equals(Seleccionado.Id))
                        row.Selected = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmPatologia dialog = new AbmPatologia();
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
                    Seleccionado = (Patologia)dataGridView1.SelectedRows[0].DataBoundItem;
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
                AbmPatologia dialog = new AbmPatologia();
                dialog.Seleccionado = (Patologia)dataGridView1.SelectedRows[0].DataBoundItem;
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
