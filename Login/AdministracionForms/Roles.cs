using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class Roles : Form
    {
        GestionarRolesPerfiles gestorRolesPerfiles = new GestionarRolesPerfiles();
        public Roles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            actualizar();

        }

        private void actualizar()
        {
            cmbUsuarios.DataSource = null;
            cmbUsuarios.DataSource = GestionarUsuario.Listar();
            cmbRoles.DataSource = null;
            cmbRoles.DataSource = new GestionarRolesPerfiles().arbol;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void cmbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<iPermisos> perfiles = gestorRolesPerfiles.ListarUsuarioPerfil((Usuario)cmbUsuarios.SelectedItem);
            foreach (var item in perfiles)
            {
                listBox1.Items.Add(item);
            }
        }
    }
}
