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
    public partial class Bitacora : IdiomaForm
    {
        List<BE.Bitacora> lista;

        public Bitacora()
        {
            InitializeComponent();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            lista = BLL.GestionarBitacora.Listar();
            comboBox1.DataSource = BLL.GestionarUsuario.Listar();
            Actualizar(lista);
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<BE.Bitacora> temp = null;

            if (checkBox1.Checked && ! checkBox2.Checked)
            {
                 temp = from bitacora in lista
                   where bitacora.Fecha > dateTimePicker1.Value
                   && bitacora.Fecha < dateTimePicker2.Value
                   select bitacora;
            } else if (! checkBox1.Checked && checkBox2.Checked)
            {
                temp = from bitacora in lista
                       where bitacora.Usuario.Login.Equals(((BE.Usuario)comboBox1.SelectedItem).Login)
                       select bitacora;
            } else if (checkBox1.Checked && checkBox2.Checked)
            {
                temp = from bitacora in lista
                       where bitacora.Fecha > dateTimePicker1.Value
                       && bitacora.Fecha < dateTimePicker2.Value
                       && bitacora.Usuario.Login.Equals(((BE.Usuario)comboBox1.SelectedItem).Login)
                       select bitacora;
            }
            
            if (temp != null)
            {
                Actualizar(temp.ToList<BE.Bitacora>());
            }
            else
            {
                Mensaje("msgNofiltro");
            }

        }

        private void Actualizar(List<BE.Bitacora> param)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = param;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Actualizar(lista);
        }
    }
}
