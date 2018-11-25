using BEFuncional;
using BLL;
using BLLFuncional;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class AbmPaciente : IdiomaForm
    {
        public Paciente Seleccionado { get; set; }
        private GestionarPaciente gestor;

        public AbmPaciente()
        {
            InitializeComponent();
        }

        private void AbmPaciente_Load(object sender, EventArgs e)
        {
            gestor = new GestionarPaciente();
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            this.AcceptButton = this.btnAceptar;
            Actualizar();
            dtFecha.MaxDate = DateTime.Now;
        }

        private void Actualizar()
        {
            if (Seleccionado != null)
            {
                txtDni.Text = Seleccionado.Dni.ToString();
                txtDni.ReadOnly = true;
                txtNombre.Text = Seleccionado.Nombre;
                txtApellido.Text = Seleccionado.Apellido;
                dtFecha.Value = Seleccionado.FechaNacimiento;
            }
            else
            {
                txtDni.Text = string.Empty;
                txtDni.ReadOnly = false;
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                dtFecha.Value = DateTime.Now;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int respuesta;
            if (Seleccionado == null)
                Seleccionado = new Paciente();
            try
            {
                if (this.ValidarTextbox())
                {
                    Seleccionado.Dni = int.Parse(txtDni.Text.Trim());
                    Seleccionado.Nombre = txtNombre.Text.Trim();
                    Seleccionado.Apellido = txtApellido.Text.Trim();
                    Seleccionado.FechaNacimiento = dtFecha.Value;

                    Paciente existe = GestionarPaciente.Buscar(Seleccionado);
                    if (existe == null)
                        respuesta = gestor.Insertar(Seleccionado);
                    else
                    {
                        respuesta = gestor.Modificar(Seleccionado);
                    }
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                    {
                        Mensaje("msgOperacionOk");
                        this.Close();
                    }
                }
                else
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