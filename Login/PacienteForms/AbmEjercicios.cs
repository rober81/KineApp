﻿using BEFuncional;
using BLLFuncional;
using GUI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class AbmEjercicios : IdiomaForm
    {
        List<Ejercicio> listaEjercicios;
        GestionarEjercicio ge;

        public AbmEjercicios()
        {
            InitializeComponent();
        }

        private void AbmEjercicios_Load(object sender, EventArgs e)
        {
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Nuevo(btnNuevo);
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;

            lblID.Text = string.Empty;
            ge = new GestionarEjercicio();
            listaEjercicios = ge.Listar();
            ActualizarLista(listaEjercicios);
        }

        private void ActualizarLista(List<Ejercicio> lista)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Id"].DisplayIndex = 0;
            dataGridView1.Columns["Id"].Width = 25;
            dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            dataGridView1.Columns["Nombre"].Width = 180;
            dataGridView1.Columns["descripcion"].DisplayIndex = 2;
            dataGridView1.Columns["descripcion"].Width = 300;
            dataGridView1.Columns["cantidad"].DisplayIndex = 3;
            dataGridView1.Columns["cantidad"].Width = 100;
            dataGridView1.Columns["repeticiones"].DisplayIndex = 4;
            dataGridView1.Columns["repeticiones"].Width = 100;
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
                    Ejercicio ej = new Ejercicio();
                    ej.Nombre = txtNombre.Text.Trim();
                    ej.Descripcion = txtDescripcion.Text.Trim();
                    ej.Cantidad = txtCantidad.Text.Trim();
                    ej.Repeticiones = txtRepeticiones.Text.Trim();
                    if (string.IsNullOrWhiteSpace(lblID.Text))
                        respuesta = GestionarEjercicio.Insertar(ej);
                    else
                    {
                        ej.Id = int.Parse(lblID.Text);
                        respuesta = GestionarEjercicio.Modificar(ej);
                    }
                    if (respuesta == 0)
                        Mensaje("msgErrorAlta", "msgError");
                    else
                        Mensaje("msgOperacionOk");
                    ActualizarLista(ge.Listar());
                    if (this.Owner == null)
                        nuevo();
                    else
                        this.Close();
                }
            }
            catch (Exception)
            {
                Mensaje("errorDatoMal", "msgFaltaCompletarTitulo");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void nuevo()
        {
            lblID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtRepeticiones.Text = string.Empty;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row != null)
            {
                Ejercicio ej = (Ejercicio)e.Row.DataBoundItem;
                if (ej != null)
                {
                    lblID.Text = ej.Id.ToString();
                    txtNombre.Text = ej.Nombre;
                    txtDescripcion.Text = ej.Descripcion;
                    txtCantidad.Text = ej.Cantidad;
                    txtRepeticiones.Text = ej.Repeticiones;
                }
                else
                {
                    lblID.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtDescripcion.Text = string.Empty;
                    txtCantidad.Text = string.Empty;
                    txtRepeticiones.Text = string.Empty;
                }
            }
        }
    }
}