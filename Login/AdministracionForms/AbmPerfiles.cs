using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class AbmPerfiles : IdiomaForm
    {
        private GestionarRolesPerfiles gestor;

        public AbmPerfiles()
        {
            InitializeComponent();
        }

        private void Perfiles_Load(object sender, EventArgs e)
        {
            gestor = new GestionarRolesPerfiles();
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            Actualizar();
        }

        private void Actualizar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestor.ListarPerfiles();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 310;
            dataGridView1.Columns[2].Width = 50;
            cmbPadre.Items.Clear();
            cmbPadre.Items.Add("");
            foreach (var item in gestor.ListarPerfilesPadres())
            {
                cmbPadre.Items.Add(item);
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
                    Perfiles obj = new Perfiles();
                    obj.Nombre = txtNombre.Text.Trim();
                    Perfiles padre = cmbPadre.SelectedItem as Perfiles;
                    if (padre == null)
                        obj.Padre = 0;
                    else
                        obj.Padre = padre.Id;

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
                }
                else
                    this.DialogResult = DialogResult.None;
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                lblID.Text = row.Cells[0].Value.ToString();
                txtNombre.Text = row.Cells[1].Value.ToString();
                int padre = int.Parse(row.Cells[2].Value.ToString());
                if (padre == 0)
                    cmbPadre.SelectedIndex = 0;
                else
                {
                    foreach (var item in gestor.ListarPerfilesPadres())
                    {
                        if (item.Id == padre)
                            cmbPadre.SelectedItem = item;
                    }
                }
            }
        }
    }
}
