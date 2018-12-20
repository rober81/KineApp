using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConsultarEjercicio : IdiomaForm
    {
        GestionarEjercicio gestor;
        public Ejercicio Seleccionado { get; set; }
        public string PalabrasClave { get; set; }

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
            gestor = new GestionarEjercicio();
            ActualizarLista(FiltrarLista());
            if (this.Owner != null)
            {
                btnModificar.Visible = false;
                btnNuevo.Visible = false;
            }
        }

        private void ActualizarLista(List<Ejercicio> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].Width = 25;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Nombre"].Width = 180;
            dataGridView1.Columns["Descripcion"].DisplayIndex = 2;
            dataGridView1.Columns["Descripcion"].Width = 300;
            dataGridView1.Columns["Cantidad"].DisplayIndex = 3;
            dataGridView1.Columns["Cantidad"].Width = 100;
            dataGridView1.Columns["Repeticiones"].DisplayIndex = 4;
            dataGridView1.Columns["Repeticiones"].Width = 100;
            dataGridView1.Columns["Observaciones"].DisplayIndex = 5;
            dataGridView1.Columns["Observaciones"].Visible = false;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Seleccionado = null;
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmEjercicios dialog = new AbmEjercicios();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(FiltrarLista());
            }
            dialog.Dispose();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((txtBuscar.Text))){
                ActualizarLista(FiltrarLista());
            } else {
                ActualizarLista(FiltrarLista(txtBuscar.Text));
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
                    Seleccionado = (Ejercicio)dataGridView1.SelectedRows[0].DataBoundItem;
                else
                    Seleccionado = null;
            }
                
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0){
                AbmEjercicios dialog = new AbmEjercicios();
                dialog.Seleccionado = (Ejercicio)dataGridView1.SelectedRows[0].DataBoundItem;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarLista(FiltrarLista());
                }
                dialog.Dispose();
            }

        }

        private List<Ejercicio> FiltrarLista()
        {
            if (string.IsNullOrWhiteSpace(PalabrasClave))
                return gestor.Listar();
            else
                return gestor.Filtrar(PalabrasClave);
        }

        private List<Ejercicio> FiltrarLista(string busqueda)
        {
            if (string.IsNullOrWhiteSpace(PalabrasClave))
                return gestor.Listar(busqueda);
            else
                return gestor.Filtrar(busqueda, PalabrasClave);
        }
    }
}
