using BEFuncional;
using BLL;
using BLLFuncional;
using System;

using System.Windows.Forms;

namespace GUI.PacienteForms
{
    public partial class AbmPatologia : IdiomaForm
    {
        public Patologia Seleccionado { get; set; }
        private GestionarPatologia gestor;

        public AbmPatologia()
        {
            InitializeComponent();
        }

        private void AbmPatologia_Load(object sender, EventArgs e)
        {
            gestor = new GestionarPatologia();
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            Actualizar();
        }

        private void Actualizar()
        {
            if (Seleccionado != null)
            {
                lblID.Text = Seleccionado.Id.ToString();
                txtNombre.Text = Seleccionado.Nombre;
                txtDescripcion.Text = Seleccionado.Descripcion;
                txtPalabrasClave.Text = Seleccionado.PalabrasClave;
            }
            else
            {
                lblID.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtPalabrasClave.Text = string.Empty;
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
                    Patologia obj = new Patologia();
                    obj.Nombre = txtNombre.Text.Trim();
                    obj.Descripcion = txtDescripcion.Text.Trim();
                    obj.PalabrasClave = txtPalabrasClave.Text.Trim();
                    
                    if (string.IsNullOrWhiteSpace(lblID.Text))
                        respuesta = gestor.Insertar(obj);
                    else
                    {
                        obj.Id = int.Parse(lblID.Text);
                        respuesta = gestor.Modificar(obj);
                    }
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                        Mensaje("msgOperacionOk");
                    if (this.Owner != null)
                        this.Close();
                } else
                    this.DialogResult = DialogResult.None;
            }
            catch (Exception ex)
            {
                GestionarError.loguear(ex.ToString());
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }
    }
}
