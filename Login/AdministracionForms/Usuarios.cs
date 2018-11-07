using BE;
using BLL;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Usuarios : IdiomaForm
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Nuevo(btnNuevo);
            ActualizarLista();
        }

        private void ActualizarLista()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = GestionarUsuario.Listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
            txtUsuario.Enabled = true;
            txtPass.Text = string.Empty;
            txtPass2.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            listBox1.SelectedItem = null;
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
                    if (!txtPass.Text.Equals(txtPass2.Text))
                    {
                        Mensaje("msgErrorPassNoIguales", "msgError");
                        return;
                    }
                    Usuario usr = new Usuario();
                    usr.Login = txtUsuario.Text.Trim();
                    usr.Password = txtPass.Text.Trim();
                    usr.Nombre = txtNombre.Text.Trim();
                    usr.Apellido = txtApellido.Text.Trim();
                    usr.Correo = txtCorreo.Text.Trim();
                    usr.Dni = int.Parse(txtDni.Text.Trim());
                    if (txtUsuario.Enabled)
                        respuesta = GestionarUsuario.Insertar(usr);
                    else
                        respuesta = GestionarUsuario.Modificar(usr);
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                        Mensaje("msgOperacionOk");
                    ActualizarLista();
                    btnNuevo_Click(null, null);
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        protected override Boolean ValidarTextbox()
        {
            if (txtUsuario.Text.Length < 6)
            {
                Mensaje("msgLargoUsr", "msgFaltaCompletarTitulo");
                return false;
            }
            if (txtPass.Text.Length < 6)
            {
                Mensaje("msgLargoPass", "msgFaltaCompletarTitulo");
                return false;
            }
            return base.ValidarTextbox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usr = (Usuario)listBox1.SelectedItem;
            if (usr != null)
            {
                txtUsuario.Text = usr.Login;
                txtPass.Text = usr.Password;
                txtPass2.Text = usr.Password;
                txtUsuario.Enabled = false;
                txtCorreo.Text = usr.Correo;
                txtDni.Text = usr.Dni.ToString();
                txtNombre.Text = usr.Nombre;
                txtApellido.Text = usr.Apellido;
            } else
            {
                btnNuevo_Click(null,null);
            }
        }
    }
}
