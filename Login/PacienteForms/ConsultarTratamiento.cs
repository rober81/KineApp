﻿using BEFuncional;
using BLLFuncional;
using GUI.PacienteForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConsultarTratamiento : IdiomaForm
    {
        GestionarTratamiento gestor;
        public Tratamiento Seleccionado { get; set; }
        public string PalabrasClave { get; set; }

        public ConsultarTratamiento()
        {
            InitializeComponent();
        }

        private void ConsultaTratamiento_Load(object sender, EventArgs e)
        {
            Estilo.Nuevo(btnNuevo);
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Modificar(btnModificar);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            gestor = new GestionarTratamiento();
            ActualizarLista(FiltrarLista());
            if (this.Owner != null)
            {
                btnModificar.Visible = false;
                btnNuevo.Visible = false;
            }
        }

        private void ActualizarLista(List<Tratamiento> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].Width = 25;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Nombre"].Width = 220;
            dataGridView1.Columns["Descripcion"].DisplayIndex = 2;
            dataGridView1.Columns["Descripcion"].Width = 460;
            dataGridView1.Columns["PalabrasClave"].Width = 120;
            if (Seleccionado != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((DatoBase)row.DataBoundItem).Id.Equals(Seleccionado.Id))
                        row.Selected = true;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmTratamiento dialog = new AbmTratamiento();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(FiltrarLista());
            }
            dialog.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    Seleccionado = (Tratamiento)dataGridView1.SelectedRows[0].DataBoundItem;
                else
                    Seleccionado = null;
            }
            else
                this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AbmTratamiento dialog = new AbmTratamiento();
                dialog.Seleccionado = (Tratamiento)dataGridView1.SelectedRows[0].DataBoundItem;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ActualizarLista(FiltrarLista());
                }
                dialog.Dispose();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace((txtBuscar.Text)))
            {
                ActualizarLista(FiltrarLista());
            }
            else
            {
                ActualizarLista(FiltrarLista(txtBuscar.Text));
            }
        }

        private List<Tratamiento> FiltrarLista()
        {
            if (string.IsNullOrWhiteSpace(PalabrasClave))
                return gestor.Listar();
            else
                return gestor.Filtrar(PalabrasClave);
        }

        private List<Tratamiento> FiltrarLista(string busqueda)
        {
            if (string.IsNullOrWhiteSpace(PalabrasClave))
                return gestor.Listar(busqueda);
            else
                return gestor.Filtrar(busqueda, PalabrasClave);
        }



    }
}
