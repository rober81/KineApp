using BEFuncional;
using BLLFuncional;
using GUI.Personalizado;
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
            Estilo.Buscar(btnBuscar);
            gp = new GestionarPaciente();
            lista = gp.Listar();
            ActualizarLista(lista);
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
                    pa.Dni = int.Parse(txtDni.Text);
                    pa.Nombre = txtNombre.Text;
                    pa.Apellido = txtApellido.Text;
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
            dataGridView1.Columns["Dni"].DisplayIndex = 0;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Apellido"].DisplayIndex = 2;
            dataGridView1.Columns["FechaNacimiento"].DisplayIndex = 3;
            dataGridView1.Columns["DVH"].DisplayIndex = 4;
            dataGridView1.Columns["DVH"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (! string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                ActualizarLista(gp.Listar(txtBuscar.Text));
            } else
                ActualizarLista(lista);
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarLista(lista);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnBuscar;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnAceptar;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnAceptar;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnAceptar;
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
    }
}
