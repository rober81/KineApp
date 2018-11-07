using BEFuncional;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class AbmEntrenamiento : Form
    {
        private Ejercicio ejercicioSeleccionado;
        public Entrenamiento entrenamientoSeleccionado { get; set; }

        public AbmEntrenamiento()
        {
            InitializeComponent();
        }

        private void AbmEntrenamiento_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Agregar(btnAgregar);
            Estilo.Remover(btnRemover);
            Estilo.Nuevo(btnNuevo);
            Estilo.Buscar(btnBuscar);
            actualizarEntrenamiento();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEjercicio dialog = new BuscarEjercicio();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ejercicioSeleccionado = dialog.seleccionado;
            }
            else
            {
                ejercicioSeleccionado = null;
            }
            actualizarEjer();
            dialog.Dispose();
        }

        private void actualizarEjer()
        {
            if (null != ejercicioSeleccionado)
            {
                txtNombre.Text = ejercicioSeleccionado.ToString();
                txtDescripcion.Text = ejercicioSeleccionado.Descripcion;
                txtCantidad.Text = ejercicioSeleccionado.Cantidad;
                txtRepeticiones.Text = ejercicioSeleccionado.Repeticiones;
                txtObservaciones.Text = ejercicioSeleccionado.Observaciones;
            }
            else
            {
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtRepeticiones.Text = string.Empty;
                txtObservaciones.Text = string.Empty;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (null != ejercicioSeleccionado)
            {
                EjerCargados.Items.Add(ejercicioSeleccionado);
                ejercicioSeleccionado = null;
                actualizarEjer();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (EjerCargados.Items.Count > 0)
                EjerCargados.Items.Remove(EjerCargados.SelectedItem);
        }

        private void EjerCargados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EjerCargados.Items.Count > 0)
                ejercicioSeleccionado = (Ejercicio) EjerCargados.SelectedItem;
            actualizarEjer();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void actualizarEntrenamiento()
        {
            if (null != entrenamientoSeleccionado)
            {
                txtNombreE.Text = entrenamientoSeleccionado.Nombre;
                txtDescripcionE.Text = entrenamientoSeleccionado.Descripcion;
                EjerCargados.DataSource = null;
                EjerCargados.Items.Clear();
                EjerCargados.DataSource = entrenamientoSeleccionado.ListaEjercicios;
            } else
            {
                entrenamientoSeleccionado = new Entrenamiento();
                actualizarEntrenamiento();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            entrenamientoSeleccionado = null;
            actualizarEntrenamiento();
        }

    }
}
