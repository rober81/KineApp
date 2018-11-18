using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class AbmEjercicios : IdiomaForm
    {
        public Ejercicio seleccionado { get; set; }
        List<Ejercicio> listaEjercicios;
        GestionarEjercicio gestor;

        public AbmEjercicios()
        {
            InitializeComponent();
        }

        private void AbmEjercicios_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;

            gestor = new GestionarEjercicio();
            listaEjercicios = gestor.Listar();
            Actualizar();
        }

        private void Actualizar()
        {
            if (seleccionado != null)
            {
                lblID.Text = seleccionado.Id.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtCantidad.Text = seleccionado.Cantidad;
                txtRepeticiones.Text = seleccionado.Repeticiones;
            }
            else
            {
                lblID.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtRepeticiones.Text = string.Empty;
            }
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
                    Ejercicio ej = new Ejercicio();
                    ej.Nombre = txtNombre.Text.Trim();
                    ej.Descripcion = txtDescripcion.Text.Trim();
                    ej.Cantidad = txtCantidad.Text.Trim();
                    ej.Repeticiones = txtRepeticiones.Text.Trim();
                    if (string.IsNullOrWhiteSpace(lblID.Text))
                        respuesta = GestionarEjercicio.Insertar(ej);
                    else
                    {
                        ej.Id = int.Parse(lblID.Text);
                        respuesta = GestionarEjercicio.Modificar(ej);
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
                else
                    this.DialogResult = DialogResult.None;
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void nuevo()
        {
            lblID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtRepeticiones.Text = string.Empty;
        }
    }
}
