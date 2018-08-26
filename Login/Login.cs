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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                BLL.GestionarSesion sesion = BLL.GestionarSesion.getInstance();
                if (sesion.iniciarSesion(textBox1.Text, textBox2.Text)){
                    this.Hide();
                    Maestro form = new Maestro();
                    form.ShowDialog();
                } else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }
            }
        }

        private Boolean validar()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Completar el usuario");
                return false;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Completar la contraseña");
                return false;
            }
            return true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label5.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña enviada por Correo");
            label5.Visible = true;
            textBox3.Visible = true;
            button2.Visible = true;
        }

    }
}
