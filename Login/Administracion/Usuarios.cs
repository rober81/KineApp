using BE;
using BLL;
using GUI.Personalizado;
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
            textBox1.Text = string.Empty;
            textBox1.Enabled = true;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox8.Text = string.Empty;
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
                if (this.validarTextbox())
                {
                    if (!textBox2.Text.Equals(textBox3.Text))
                    {
                        Mensaje("msgErrorPassNoIguales", "msgError");
                        return;
                    }
                    Usuario usr = new Usuario();
                    usr.Login = textBox1.Text;
                    usr.Password = textBox2.Text;
                    usr.Nombre = textBox6.Text;
                    usr.Apellido = textBox8.Text;
                    usr.Correo = textBox4.Text;
                    usr.Dni = int.Parse(textBox5.Text);
                    if (textBox1.Enabled)
                        respuesta = GestionarUsuario.Insertar(usr);
                    else
                        respuesta = GestionarUsuario.Modificar(usr);
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                        Mensaje("msgOperacionOk");
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
            ActualizarLista();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usr = (Usuario)listBox1.SelectedItem;
            if (usr != null)
            {
                textBox1.Text = usr.Login;
                textBox2.Text = usr.Password;
                textBox3.Text = usr.Password;
                textBox1.Enabled = false;
                textBox4.Text = usr.Correo;
                textBox5.Text = usr.Dni.ToString();
                textBox6.Text = usr.Nombre;
                textBox8.Text = usr.Apellido;
            } else
            {
                btnNuevo_Click(null,null);
            }
        }
    }
}
