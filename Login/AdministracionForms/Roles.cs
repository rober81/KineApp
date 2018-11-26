using BE;
using BLL;
using System;
using System.Collections.Generic;

namespace GUI
{
    public partial class Roles : IdiomaForm
    {
        GestionarRolesPerfiles gestorRolesPerfiles = new GestionarRolesPerfiles();
        public Roles()
        {
            InitializeComponent();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Agregar(btnAgregar);
            Estilo.Remover(btnRemover);
            actualizarCombos();
        }

        private void actualizarCombos()
        {
            cmbUsuarios.DataSource = null;
            cmbUsuarios.DataSource = GestionarUsuario.Listar();
            cmbRoles.DataSource = null;
            cmbRoles.DataSource = gestorRolesPerfiles.ListarPerfilesPadres();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int index = -1;
            foreach (iPermisos itemDetalle in listBox1.Items)
            {
                if (itemDetalle.Id == ((iPermisos)cmbRoles.SelectedItem).Id)
                    index = listBox1.Items.IndexOf(itemDetalle);
            }
            if (index == -1)
                listBox1.Items.Add(cmbRoles.SelectedItem);
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

        private void btnRemover_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                Usuario usr = (Usuario)cmbUsuarios.SelectedItem;
                List<iPermisos> permisos = new List<iPermisos>();
                foreach (iPermisos item in listBox1.Items)
                {
                    permisos.Add(item);
                }
                int respuesta = gestorRolesPerfiles.InsertarUsuarioPerfil(usr, permisos);
                if (respuesta == 0)
                    Mensaje("msgErrorAlta", "msgError");
                else
                {
                    Mensaje("msgOperacionOk");
                    this.Close();
                }  
            } else
            {
                Mensaje("msgErrorUnItem", "msgError");
            }
        }
    }
}
