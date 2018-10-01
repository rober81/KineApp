using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class AdminIdioma : IdiomaForm
    {
        private static string idioma1 = "Español";
        private static string idioma2 = "English";
        private BE.Idioma esp = new BE.Idioma(idioma1);
        private BE.Idioma ing = new BE.Idioma(idioma2);

        public AdminIdioma()
        {
            InitializeComponent();
        }

        private void AdminIdioma_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.button1;
            cargar();
        }

        private void cargar()
        {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            BLL.GestionarIdioma.getInstance().Cargar(esp);
            BLL.GestionarIdioma.getInstance().Cargar(ing);
            listBox1.DataSource = new BindingSource(esp.Detalle, null);
            listBox2.DataSource = new BindingSource(ing.Detalle, null);
            radioButton1.Checked = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            if (null != listBox1.SelectedItem)
            {
                try
                {
                    KeyValuePair<string, string> temp1 = (KeyValuePair<string, string>)listBox1.SelectedItem;
                    textBox1.Text = temp1.Key.ToString();
                    textBox2.Text = temp1.Value.ToString();
                    textBox3.Text = ing.Detalle[temp1.Key.ToString()];
                }
                catch (Exception)
                {
                    textBox3.Text = string.Empty;
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            if (null != listBox2.SelectedItem)
            {
                try
                {
                    KeyValuePair<string, string> temp1 = (KeyValuePair<string, string>)listBox2.SelectedItem;
                    textBox1.Text = temp1.Key.ToString();
                    textBox2.Text = temp1.Value.ToString();
                    textBox3.Text = esp.Detalle[temp1.Key.ToString()];
                }
                catch (Exception)
                {
                    textBox3.Text = string.Empty;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( ! string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)){
                BE.IdiomaDetalle detalle = new BE.IdiomaDetalle();
                if (radioButton1.Checked)
                    detalle.Idioma = idioma1;
                else
                    detalle.Idioma = idioma2;
                detalle.Clave = textBox1.Text;
                detalle.Texto = textBox2.Text;
                int resultado = BLL.GestionarIdioma.getInstance().insertarDetalle(detalle);
                if (! string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    BE.IdiomaDetalle traduccion = new BE.IdiomaDetalle();
                    if (radioButton1.Checked)
                        traduccion.Idioma = idioma2;
                    else
                        traduccion.Idioma = idioma1;
                    traduccion.Clave = textBox1.Text;
                    traduccion.Texto = textBox3.Text;
                    int resultado2 = BLL.GestionarIdioma.getInstance().insertarDetalle(traduccion);
                }
            if (resultado != 1)
                MessageBox.Show(Traducir("errorGuardar"));
            cargar();
            Limpiar();
            } else
            {
                MessageBox.Show(Traducir("errorFaltaDato"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            radioButton1.Checked = true;
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }
    }
}
