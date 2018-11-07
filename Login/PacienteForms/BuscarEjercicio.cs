using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class BuscarEjercicio : IdiomaForm
    {
        GestionarEjercicio ge;
        public Ejercicio seleccionado { get; set; }

        public BuscarEjercicio()
        {
            InitializeComponent();
        }

        private void BuscarEjercicio_Load(object sender, EventArgs e)
        {
            Estilo.Nuevo(btnNuevo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
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
            if (! string.IsNullOrWhiteSpace((txtBuscar.Text))){
                ActualizarLista(ge.Listar(txtBuscar.Text));
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                seleccionado = (Ejercicio) dataGridView1.SelectedRows[0].DataBoundItem;
            else
                seleccionado = null;
        }
    }
}
