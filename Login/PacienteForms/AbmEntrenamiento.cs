using BEFuncional;
using System;
using System.Windows.Forms;
using BLLFuncional;
using BLL;

namespace GUI
{
    public partial class AbmEntrenamiento : IdiomaForm
    {
        private Ejercicio EjercicioSeleccionado;
        private GestionarEntrenamiento gestor = new GestionarEntrenamiento();

        public Entrenamiento EntrenamientoSeleccionado { get; set; }


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
            ConsultarEjercicio dialog = new ConsultarEjercicio();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                EjercicioSeleccionado = dialog.Seleccionado;
            }
            else
            {
                EjercicioSeleccionado = null;
            }
            actualizarEjercicio();
            dialog.Dispose();
        }

        private void actualizarEjercicio()
        {
            if (null != EjercicioSeleccionado)
            {
                txtNombre.Text = EjercicioSeleccionado.ToString();
                txtDescripcion.Text = EjercicioSeleccionado.Descripcion;
                txtCantidad.Text = EjercicioSeleccionado.Cantidad;
                txtRepeticiones.Text = EjercicioSeleccionado.Repeticiones;
                txtObservaciones.Text = EjercicioSeleccionado.Observaciones;
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

        public void actualizarListaEjercicios()
        {
            EjerCargados.DataSource = null;
            EjerCargados.DataSource = EntrenamientoSeleccionado.ListaEjercicios;
            EjerCargados.ClearSelected();
        }

        public void actualizarEntrenamiento()
        {
            if (null != EntrenamientoSeleccionado)
            {
                lblID.Text = EntrenamientoSeleccionado.Id.ToString();
                txtNombreE.Text = EntrenamientoSeleccionado.Nombre;
                txtDescripcionE.Text = EntrenamientoSeleccionado.Descripcion;
                txtPalabrasClave.Text = EntrenamientoSeleccionado.PalabrasClave;
                actualizarListaEjercicios();
            }
            else
            {
                EntrenamientoSeleccionado = new Entrenamiento();
                actualizarEntrenamiento();
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (null != EjercicioSeleccionado)
            {
                EjercicioSeleccionado.Observaciones = txtObservaciones.Text;
                if (! EntrenamientoSeleccionado.ListaEjercicios.Contains(EjercicioSeleccionado))
                    EntrenamientoSeleccionado.ListaEjercicios.Add(EjercicioSeleccionado);
                EjercicioSeleccionado = null;
                actualizarEjercicio();
                actualizarListaEjercicios();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (EntrenamientoSeleccionado.ListaEjercicios.Count > 0)
                EntrenamientoSeleccionado.ListaEjercicios.Remove((Ejercicio)EjerCargados.SelectedItem);
            actualizarListaEjercicios();
        }

        private void EjerCargados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EjerCargados.Items.Count > 0)
                EjercicioSeleccionado = (Ejercicio) EjerCargados.SelectedItem;
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
                if (this.Validar())
                {
                    EntrenamientoSeleccionado.Nombre = txtNombreE.Text.Trim();
                    EntrenamientoSeleccionado.Descripcion = txtDescripcionE.Text.Trim();
                    EntrenamientoSeleccionado.PalabrasClave = txtPalabrasClave.Text;

                    if (string.IsNullOrWhiteSpace(lblID.Text) || "0".Equals(lblID.Text))
                        respuesta = gestor.Insertar(EntrenamientoSeleccionado);
                    else
                    {
                        EntrenamientoSeleccionado.Id = int.Parse(lblID.Text);
                        respuesta = gestor.Modificar(EntrenamientoSeleccionado);
                    }
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                        Mensaje("msgOperacionOk");
                    if (this.Owner == null)
                        nuevo();
                    else
                        this.Close();
                } else
                {
                    Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                GestionarError.loguear(ex.ToString());
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private bool Validar()
        {
            if (EntrenamientoSeleccionado.ListaEjercicios.Count == 0)
            {
                return false;
            }
            return this.ValidarTextbox();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void nuevo()
        {
            EntrenamientoSeleccionado = null;
            EjercicioSeleccionado = null;
            actualizarEjercicio();
            actualizarEntrenamiento();
            actualizarListaEjercicios();
        }

    }
}
