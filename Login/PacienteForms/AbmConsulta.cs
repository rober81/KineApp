using BEFuncional;
using BLLFuncional;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Util;

namespace GUI.PacienteForms
{
    public partial class AbmConsulta : IdiomaForm
    {
        public Consulta Seleccionado { get; set; }
        GestionarConsulta gestor;
        private Patologia patologiaSeleccionada;
        private DatoBase tratamientoSeleccionado;
        private ConsultaDetalle detallePAT;
        private ConsultaDetalle detalleTRAT;

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
                        this.DialogResult = DialogResult.None;
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
            {
                resultado = false;
                Mensaje("msgErrorUnItem", "msgFaltaCompletarTitulo");
            }
            if (listaTRA.Items.Count == 0)
            {
                resultado = false;
                Mensaje("msgErrorUnItem", "msgFaltaCompletarTitulo");
            }
            return resultado && this.ValidarTextbox();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            ConsultarPaciente dialog = new ConsultarPaciente();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Seleccionado.Paciente = dialog.Seleccionado;
                if (Seleccionado.Paciente != null)
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
                detallePAT = null;
                txtDescripcionPAT.Text = patologiaSeleccionada.ToString();
                txtObservacionesPAT.Text = string.Empty;
            }
            else
            {
                LimpiarPatologia();
            }
            dialog.Dispose();
            listaPAT.ClearSelected();
        }

        private void btnBuscarTRA_Click(object sender, EventArgs e)
        {
            ConsultarTratamiento dialog = new ConsultarTratamiento();
            dialog.Seleccionado = tratamientoSeleccionado as Tratamiento;
            dialog.PalabrasClave = ArmarPalabraClave();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                if (tratamientoSeleccionado != null)
                {
                    txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
                }
                    detalleTRAT = null;
                    txtObservacionesTRA.Text = string.Empty;
                    txtResultadoTRA.Text = string.Empty;
            }
            else
            {
                LimpiarTratamiento();
            }
            dialog.Dispose();
            listaTRA.ClearSelected();
        }

        private string ArmarPalabraClave()
        {
            string palabras = "";
            foreach (ConsultaDetalle item in listaPAT.Items)
            {
                palabras = palabras + item.Item.PalabrasClave + ",";
            }
            return palabras;
        }

        private void btnBuscarEN_Click(object sender, EventArgs e)
        {
            ConsultarEntrenamiento dialog = new ConsultarEntrenamiento();
            dialog.Seleccionado = tratamientoSeleccionado as Entrenamiento;
            dialog.PalabrasClave = ArmarPalabraClave();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                if (tratamientoSeleccionado != null)
                {
                    txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
                }
                    detalleTRAT = null;
                    txtObservacionesTRA.Text = string.Empty;
                    txtResultadoTRA.Text = string.Empty;
            }
            else
            {
                LimpiarTratamiento();
            }
            dialog.Dispose();
            listaTRA.ClearSelected();
        }

        private void btnBuscarEJ_Click(object sender, EventArgs e)
        {
            ConsultarEjercicio dialog = new ConsultarEjercicio();
            dialog.Seleccionado = tratamientoSeleccionado as Ejercicio;
            dialog.PalabrasClave = ArmarPalabraClave();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                tratamientoSeleccionado = dialog.Seleccionado;
                if (tratamientoSeleccionado != null)
                {
                    txtDescripcionTRA.Text = tratamientoSeleccionado.ToString();
                }
                    detalleTRAT = null;
                    txtObservacionesTRA.Text = string.Empty;
                    txtResultadoTRA.Text = string.Empty;
            }
            else
            {
                LimpiarTratamiento();
            }
            dialog.Dispose();
            listaTRA.ClearSelected();
        }

        private void btnAgregarPAT_Click(object sender, EventArgs e)
        {
            if (patologiaSeleccionada != null)
            {
                ConsultaDetalle detalle = new ConsultaDetalle();
                detalle.Item = patologiaSeleccionada;
                detalle.Observaciones = txtObservacionesPAT.Text;

                int index = -1;
                foreach (ConsultaDetalle itemDetalle in listaPAT.Items)
                {
                    if (itemDetalle.Item.Id == patologiaSeleccionada.Id)
                        index = listaPAT.Items.IndexOf(itemDetalle);
                }
                if (index >=0)
                    listaPAT.Items.RemoveAt(index);
                listaPAT.Items.Add(detalle);
                listaPAT.ClearSelected();
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

                int index = -1;
                foreach (ConsultaDetalle itemDetalle in listaTRA.Items)
                {
                    if (itemDetalle.Item.Id == tratamientoSeleccionado.Id)
                        index = listaTRA.Items.IndexOf(itemDetalle);
                }
                if (index >= 0)
                    listaTRA.Items.RemoveAt(index);
                listaTRA.Items.Add(detalle);
                listaTRA.ClearSelected();
                LimpiarTratamiento();
            }
        }

        private void btnRemoverPAT_Click(object sender, EventArgs e)
        {
            listaPAT.Items.Remove(listaPAT.SelectedItem);
            detallePAT = null;
            LimpiarPatologia();
        }

        private void btnRemoverTRA_Click(object sender, EventArgs e)
        {
            listaTRA.Items.Remove(listaTRA.SelectedItem);
            detalleTRAT = null;
            LimpiarTratamiento();
        }

        private void listaPAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultaDetalle detalle = listaPAT.SelectedItem as ConsultaDetalle;
            detallePAT = detalle;
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
            detalleTRAT = detalle;
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //string xml = SerializarXML.Serializar<Consulta>(Seleccionado);
            //MessageBox.Show(xml);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF|*.pdf";
            saveFileDialog1.Title = "Save an Pdf File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                GeneradorPDF generador = new GeneradorPDF(saveFileDialog1.FileName);
                generador.LeerTemplate(Seleccionado);
                Mensaje("msgOperacionOk");
            }
        }
    }
}
