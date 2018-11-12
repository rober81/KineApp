using BEFuncional;
using BLLFuncional;
using GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ModificarPaciente : IdiomaForm
    {
        private List<Paciente> lista;
        private GestionarPaciente gp;

        public ModificarPaciente()
        {
            InitializeComponent();
        }

        private void ModificarPaciente_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Nuevo(btnNuevo);
            gp = new GestionarPaciente();
            lista = gp.Listar();
            ActualizarLista(lista);
            dtFecha.MaxDate = DateTime.Now;
            this.AcceptButton = this.btnAceptar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarTextbox())
                {
                    Paciente pa = new Paciente();
                    pa.Dni = int.Parse(txtDni.Text.Trim());
                    pa.Nombre = txtNombre.Text.Trim();
                    pa.Apellido = txtApellido.Text.Trim();
                    pa.FechaNacimiento = dtFecha.Value;
                    int respuesta = GestionarPaciente.Modificar(pa);
                    if (respuesta == 0)
                        Mensaje("msgPacienteNoEncontrado", "msgError");
                    else
                    {
                        Mensaje("msgOperacionOk");
                        txtDni.Text = string.Empty;
                        txtNombre.Text = string.Empty;
                        txtApellido.Text = string.Empty;
                        lista = gp.Listar();
                        ActualizarLista(lista);
                    }
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void ActualizarLista(List<Paciente> pacientes)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pacientes;
            dataGridView1.Columns["dni"].DisplayIndex = 0;
            dataGridView1.Columns["nombre"].DisplayIndex = 1;
            dataGridView1.Columns["apellido"].DisplayIndex = 2;
            dataGridView1.Columns["fechaNacimiento"].DisplayIndex = 3;
            dataGridView1.Columns["fechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["DVH"].DisplayIndex = 4;
            dataGridView1.Columns["DVH"].Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                ActualizarLista(lista);
            }
            else
            {
                ActualizarLista(gp.Listar(txtBuscar.Text));
            }
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row != null)
            {
                Paciente pa = (Paciente)e.Row.DataBoundItem;
                if (pa != null)
                {
                    txtDni.Text = pa.Dni.ToString();
                    txtNombre.Text = pa.Nombre;
                    txtApellido.Text = pa.Apellido;
                    dtFecha.Value = pa.FechaNacimiento;
                }
                else
                {
                    txtDni.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AltaPaciente dialog = new AltaPaciente();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(lista);
            }
            else
            {
                ActualizarLista(lista);
            }
            dialog.Dispose();
        }
    }
}
