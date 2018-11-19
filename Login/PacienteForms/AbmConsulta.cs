using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
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
                    Seleccionado.Detalle = new List<ConsultaDetalle>();
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
                    if (respuesta == 0) {
                        Mensaje("msgErrorAlta", "msgError");
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        Mensaje("msgOperacionOk");
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
            if (listaPAT.Items.Count == 0)
                resultado = false;
            if (listaTRA.Items.Count == 0)
                resultado = false;
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
            dialog.Seleccionado = patologiaSeleccionada;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                patologiaSeleccionada = dialog.Seleccionado;
                txtDescripcionPAT.Text = patologiaSeleccionada.ToString();
            }
            else
            {
                LimpiarPatologia();
            }
            dialog.Dispose();
        }

        private void btnBuscarTRA_Click(object sender, EventArgs e)
        {
            ConsultarTratamiento dialog = new ConsultarTratamiento();
            dialog.Seleccionado = tratamientoSeleccionado as Tratamiento;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
            }
            else
            {
                LimpiarTratamiento();
            }
            dialog.Dispose();
        }

        private void btnBuscarEN_Click(object sender, EventArgs e)
        {
            ConsultarEntrenamiento dialog = new ConsultarEntrenamiento();
            dialog.Seleccionado = tratamientoSeleccionado as Entrenamiento;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
            }
            else
            {
                LimpiarTratamiento();
            }
            dialog.Dispose();
        }

        private void btnBuscarEJ_Click(object sender, EventArgs e)
        {
            ConsultarEjercicio dialog = new ConsultarEjercicio();
            dialog.Seleccionado = tratamientoSeleccionado as Ejercicio;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
            }
            else
            {
                LimpiarTratamiento();
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
                LimpiarPatologia();
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
                LimpiarTratamiento();
            }
        }

        private void btnRemoverPAT_Click(object sender, EventArgs e)
        {
            listaPAT.Items.Remove(listaPAT.SelectedItem);
            LimpiarPatologia();
        }

        private void btnRemoverTRA_Click(object sender, EventArgs e)
        {
            listaTRA.Items.Remove(listaTRA.SelectedItem);
            LimpiarTratamiento();
        }

        private void listaPAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaDetalle detalle = listaPAT.SelectedItem as ConsultaDetalle;
            if (detalle != null)
            {
                patologiaSeleccionada = (Patologia) detalle.Item;
                txtDescripcionPAT.Text = patologiaSeleccionada.ToString();
                txtObservacionesPAT.Text = detalle.Observaciones;
            }
        }

        private void listaTRA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaDetalle detalle = listaTRA.SelectedItem as ConsultaDetalle;
            if (detalle != null)
            {
                tratamientoSeleccionado = (DatoBase)detalle.Item;
                txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
                txtObservacionesTRA.Text = detalle.Observaciones;
                txtResultadoTRA.Text = detalle.Resultado;
            }
        }

        private void LimpiarTratamiento()
        {
            tratamientoSeleccionado = null;
            txtDescripcionTRA.Text = string.Empty;
            txtObservacionesTRA.Text = string.Empty;
            txtResultadoTRA.Text = string.Empty;
        }

        private void LimpiarPatologia()
        {
            patologiaSeleccionada = null;
            txtDescripcionPAT.Text = string.Empty;
            txtObservacionesPAT.Text = string.Empty;
        }
    }
}
