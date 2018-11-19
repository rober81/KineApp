﻿using BEFuncional;
using BLLFuncional;
using GUI.PacienteForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConsultarConsulta : IdiomaForm
    {
        private List<Consulta> lista;
        private GestionarConsulta gestor;

        public ConsultarConsulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            Estilo.Modificar(btnModificar);
            Estilo.Nuevo(btnNuevo);
            gestor = new GestionarConsulta();
            lista = gestor.Listar();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Dni";
            dataGridView1.Columns[2].Name = "Nombre";
            dataGridView1.Columns[3].Name = "Apellido";
            dataGridView1.Columns[4].Name = "Resumen";
            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].Width = 220;

            ActualizarLista(lista);
        }

        private void ActualizarLista(List<Consulta> consultas)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (var item in consultas)
            {
                string[] fila = new string[]{item.Id.ToString(),item.Paciente.Dni.ToString(), item.Paciente.Nombre, item.Paciente.Apellido, item.Resumen};
                dataGridView1.Rows.Add(fila);
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                ActualizarLista(gestor.Listar());
            }
            else
            {
                ActualizarLista(gestor.Listar(txtBuscar.Text));
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                AbmConsulta dialog = new AbmConsulta();
                dialog.Seleccionado = (Consulta)dataGridView1.SelectedRows[0].DataBoundItem;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                   ActualizarLista(gestor.Listar());
                }
                dialog.Dispose();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AbmConsulta dialog = new AbmConsulta();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ActualizarLista(gestor.Listar());
            }
            dialog.Dispose();
        }
    }
}
