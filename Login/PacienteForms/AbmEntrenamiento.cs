using BEFuncional;
using System;
using System.Windows.Forms;
using BLLFuncional;

namespace GUI
{
    public partial class AbmEntrenamiento : IdiomaForm
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
            actualizarEjercicio();
            dialog.Dispose();
        }

        private void actualizarEjercicio()
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

        private void actualizarListaEjercicios()
        {
            EjerCargados.DataSource = null;
            EjerCargados.DataSource = entrenamientoSeleccionado.ListaEjercicios;
            EjerCargados.ClearSelected();
        }

        private void actualizarEntrenamiento()
        {
            if (null != entrenamientoSeleccionado)
            {
                lblID.Text = entrenamientoSeleccionado.Id.ToString();
                txtNombreE.Text = entrenamientoSeleccionado.Nombre;
                txtDescripcionE.Text = entrenamientoSeleccionado.Descripcion;
            }
            else
            {
                entrenamientoSeleccionado = new Entrenamiento();
                txtNombreE.Text = string.Empty;
                txtDescripcionE.Text = string.Empty;
                actualizarEntrenamiento();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (null != ejercicioSeleccionado)
            {
                ejercicioSeleccionado.Observaciones = txtObservaciones.Text;
                if (! entrenamientoSeleccionado.ListaEjercicios.Contains(ejercicioSeleccionado))
                    entrenamientoSeleccionado.ListaEjercicios.Add(ejercicioSeleccionado);
                ejercicioSeleccionado = null;
                actualizarEjercicio();
                actualizarListaEjercicios();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (entrenamientoSeleccionado.ListaEjercicios.Count > 0)
                entrenamientoSeleccionado.ListaEjercicios.Remove((Ejercicio)EjerCargados.SelectedItem);
            actualizarListaEjercicios();
        }

        private void EjerCargados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EjerCargados.Items.Count > 0)
                ejercicioSeleccionado = (Ejercicio) EjerCargados.SelectedItem;
            actualizarEjercicio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int respuesta;
            try
            {
                if (this.ValidarTextbox())
                {
                    entrenamientoSeleccionado.Nombre = txtNombreE.Text.Trim();
                    entrenamientoSeleccionado.Descripcion = txtDescripcionE.Text.Trim();
                    if (string.IsNullOrWhiteSpace(lblID.Text) || "0".Equals(lblID.Text))
                        respuesta = GestionarEntrenamiento.Insertar(entrenamientoSeleccionado);
                    else
                    {
                        entrenamientoSeleccionado.Id = int.Parse(lblID.Text);
                        respuesta = GestionarEntrenamiento.Modificar(entrenamientoSeleccionado);
                    }
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                        Mensaje("msgOperacionOk");
                    if (this.Owner == null)
                        nuevo();
                    else
                        this.Close();
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void nuevo()
        {
            entrenamientoSeleccionado = null;
            ejercicioSeleccionado = null;
            actualizarEjercicio();
            actualizarEntrenamiento();
            actualizarListaEjercicios();
        }

    }
}
