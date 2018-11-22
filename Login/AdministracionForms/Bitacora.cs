using BE;
using BLL;
using GUI;
using System;
using System.Collections.Generic;

namespace GUI
{
    public partial class Bitacora : IdiomaForm
    {
        List<BE.Bitacora> lista;
        GestionarBitacora gb;

        public Bitacora()
        {
            InitializeComponent();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            gb = new GestionarBitacora();
            lista = gb.Listar();
            comboBox1.Items.Add("");
            foreach ( var item in GestionarUsuario.Listar())
            {
                comboBox1.Items.Add(item);
            }
            Actualizar(lista);
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<BE.Bitacora> temp = null;
            Usuario seleccionado = comboBox1.SelectedItem as Usuario;
            if (seleccionado == null)
            {
                temp = gb.ListarFecha(dateTimePicker1.Value, dateTimePicker2.Value);
            } else 
            {
                temp = gb.ListarFechaUsuario(dateTimePicker1.Value, dateTimePicker2.Value, seleccionado);
            }
            
            if (temp != null)
                Actualizar(temp);
            else
                Mensaje("msgNofiltro");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Parse("01/01/2018");
            //dateTimePicker2.Value = DateTime.Now;
            Actualizar(lista);
        }

        private void Actualizar(List<BE.Bitacora> param)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = param;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 280;
        }
    }
}
