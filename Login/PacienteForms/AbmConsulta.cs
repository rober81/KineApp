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
        private Patologia patologiaSeleccionada;
        private DatoBase tratamientoSeleccionado;

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
                Seleccionado = gestor.Buscar(Seleccionado);
                lblID.Text = Seleccionado.Id.ToString();
                txtPaciente.Text = Seleccionado.Paciente.ToString();
                btnBuscarPaciente.Enabled = false;
                txtResumen.Text = Seleccionado.Resumen;
                dtFecha.Value = Seleccionado.Fecha;
                foreach (ConsultaDetalle item in Seleccionado.Detalle)
                {
                    if (item.Item is Patologia)
                        listaPAT.Items.Add(item);
                    else
                        listaTRA.Items.Add(item);
                }
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
                    Seleccionado.Detalle.Clear();
                    foreach (ConsultaDetalle item in listaPAT.Items)
                    {
                        Seleccionado.Detalle.Add(item);
                    }
                    foreach (ConsultaDetalle item in listaTRA.Items)
                    {
                        Seleccionado.Detalle.Add(item);
                    }

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

        private void btnBuscarPAT_Click(object sender, EventArgs e)
        {
            ConsultarPatologia dialog = new ConsultarPatologia();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                patologiaSeleccionada = dialog.Seleccionado;
                txtDescripcionPAT.Text = patologiaSeleccionada.ToString();
            }
            else
            {
                patologiaSeleccionada = null;
                txtDescripcionPAT.Text = string.Empty;
            }
            dialog.Dispose();
        }

        private void btnBuscarTRA_Click(object sender, EventArgs e)
        {
            ConsultarTratamiento dialog = new ConsultarTratamiento();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
            }
            else
            {
                tratamientoSeleccionado = null;
                txtDescripcionTRA.Text = string.Empty;
            }
            dialog.Dispose();
        }

        private void btnBuscarEN_Click(object sender, EventArgs e)
        {
            ConsultarEntrenamiento dialog = new ConsultarEntrenamiento();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
            }
            else
            {
                tratamientoSeleccionado = null;
                txtDescripcionTRA.Text = string.Empty;
            }
            dialog.Dispose();
        }

        private void btnBuscarEJ_Click(object sender, EventArgs e)
        {
            ConsultarEjercicio dialog = new ConsultarEjercicio();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
            }
            else
            {
                tratamientoSeleccionado = null;
                txtDescripcionTRA.Text = string.Empty;
            }
            dialog.Dispose();
        }

        private void btnAgregarPAT_Click(object sender, EventArgs e)
        {
            if (patologiaSeleccionada != null)
            {
                ConsultaDetalle detalle = new ConsultaDetalle();
                detalle.Item = patologiaSeleccionada;
                detalle.Observaciones = txtObservacionesPAT.Text;
                listaPAT.Items.Add(detalle);
            }
        }

        private void btnAgregarTRA_Click(object sender, EventArgs e)
        {
            if (tratamientoSeleccionado != null)
            {
                ConsultaDetalle detalle = new ConsultaDetalle();
                detalle.Item = tratamientoSeleccionado;
                detalle.Observaciones = txtObservacionesTRA.Text;
                detalle.Resultado = txtResultadoTRA.Text;
                listaTRA.Items.Add(detalle);
            }
        }

        private void btnRemoverPAT_Click(object sender, EventArgs e)
        {
            listaPAT.Items.Remove(listaPAT.SelectedItem);
        }

        private void btnRemoverTRA_Click(object sender, EventArgs e)
        {
            listaPAT.Items.Remove(listaPAT.SelectedItem);
        }
    }
}
