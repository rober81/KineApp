using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConsultarEjercicio : IdiomaForm
    {
        GestionarEjercicio ge;
        public Ejercicio seleccionado { get; set; }

        public ConsultarEjercicio()
        {
            InitializeComponent();
        }

        private void BuscarEjercicio_Load(object sender, EventArgs e)
        {
            Estilo.Nuevo(btnNuevo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Modificar(btnModificar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            ge = new GestionarEjercicio();
            ActualizarLista(ge.Listar());
        }

        private void ActualizarLista(List<Ejercicio> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].Width = 25;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Nombre"].Width = 180;
            dataGridView1.Columns["descripcion"].DisplayIndex = 2;
            dataGridView1.Columns["descripcion"].Width = 300;
            dataGridView1.Columns["cantidad"].DisplayIndex = 3;
            dataGridView1.Columns["cantidad"].Width = 100;
            dataGridView1.Columns["repeticiones"].DisplayIndex = 4;
            dataGridView1.Columns["repeticiones"].Width = 100;
            dataGridView1.Columns["Observaciones"].DisplayIndex = 5;
            dataGridView1.Columns["Observaciones"].Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            seleccionado = null;
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmEjercicios dialog = new AbmEjercicios();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(ge.Listar());
            }
            else
            {
                ActualizarLista(ge.Listar());
            }
            dialog.Dispose();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((txtBuscar.Text))){
                ActualizarLista(ge.Listar());
            } else {
                ActualizarLista(ge.Listar(txtBuscar.Text));
            }
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
                    seleccionado = (Ejercicio)dataGridView1.SelectedRows[0].DataBoundItem;
                else
                    seleccionado = null;
            }
                
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0){
                AbmEjercicios dialog = new AbmEjercicios();
                dialog.seleccionado = (Ejercicio)dataGridView1.SelectedRows[0].DataBoundItem;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarLista(ge.Listar());
                }
                else
                {
                    ActualizarLista(ge.Listar());
                }
                dialog.Dispose();
            }

        }
    }
}
