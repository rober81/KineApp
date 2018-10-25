using BLL;
using GUI.Personalizado;
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
            comboBox1.DataSource = BLL.GestionarUsuario.Listar();
            Actualizar(lista);
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
            Estilo.Buscar(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<BE.Bitacora> temp = null;
            
            if (checkBox1.Checked && ! checkBox2.Checked)
            {
                temp = gb.ListarFecha(dateTimePicker1.Value, dateTimePicker2.Value);
            } else if (! checkBox1.Checked && checkBox2.Checked)
            {
                temp = gb.ListarUsuario(((BE.Usuario)comboBox1.SelectedItem));
            } else if (checkBox1.Checked && checkBox2.Checked)
            {
                temp = gb.ListarFechaUsuario(dateTimePicker1.Value, dateTimePicker2.Value, ((BE.Usuario)comboBox1.SelectedItem));
            }
            
            if (temp != null)
                Actualizar(temp);
            else
                Mensaje("msgNofiltro");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizar(lista);
        }

        private void Actualizar(List<BE.Bitacora> param)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = param;
        }
    }
}
