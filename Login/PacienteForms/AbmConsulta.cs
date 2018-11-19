using BEFuncional;
using BLLFuncional;
using System;
using System.Windows.Forms;

namespace GUI.PacienteForms
{
    public partial class AbmConsulta : IdiomaForm
    {
        public Consulta Seleccionado { get; set; }
        GestionarConsulta gestor;

        public AbmConsulta()
        {
            InitializeComponent();
        }

        private void AbmConsulta_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            gestor = new GestionarConsulta();
            Actualizar();
            dtFecha.MaxDate = DateTime.Now;
            dtFecha.CustomFormat = "dd/MM/yyyy";
        }

        private void Actualizar()
        {
            if (Seleccionado != null)
            {
                lblID.Text = Seleccionado.Id.ToString();
                txtPaciente.Text = Seleccionado.Paciente.ToString();
                btnBuscarPaciente.Enabled = false;
                txtResumen.Text = Seleccionado.Resumen;
                dtFecha.Value = Seleccionado.Fecha;
            }
            else
            {
                lblID.Text = string.Empty;
                txtPaciente.Text = string.Empty;
                btnBuscarPaciente.Enabled = true;
                txtResumen.Text = string.Empty;
                dtFecha.Value = DateTime.Now;
                Seleccionado = new Consulta();
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
                if (this.validar())
                {
                    Consulta obj = new Consulta();
                    Seleccionado.Resumen = txtResumen.Text.Trim();
                    Seleccionado.Fecha = dtFecha.Value;

                    if (string.IsNullOrWhiteSpace(lblID.Text))
                        respuesta = gestor.Insertar(Seleccionado);
                    else
                    {
                        Seleccionado.Id = int.Parse(lblID.Text);
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
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private Boolean validar()
        {
            Boolean resultado = true;
            if (Seleccionado.Paciente == null)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
                resultado = false;
            }
            return resultado && this.ValidarTextbox();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            ConsultarPaciente dialog = new ConsultarPaciente();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Seleccionado.Paciente = dialog.Seleccionado;
                txtPaciente.Text = Seleccionado.Paciente.ToString();
            }
            dialog.Dispose();
        }
    }
}
