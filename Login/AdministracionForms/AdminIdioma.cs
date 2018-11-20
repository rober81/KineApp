using BE;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class AdminIdioma : IdiomaForm
    {
        private static string idioma1 = "Español";
        private static string idioma2 = "English";
        private Idioma esp = new Idioma(idioma1);
        private Idioma ing = new Idioma(idioma2);
        private List<IdiomaFila> lista = new List<IdiomaFila>();

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
            BLL.GestionarIdioma.getInstance().Cargar(esp);
            BLL.GestionarIdioma.getInstance().Cargar(ing);
            foreach (KeyValuePair<string, string> item in esp.Detalle)
            {
                IdiomaFila fila = new IdiomaFila();
                fila.Clave = item.Key;
                fila.Esp = item.Value;
                fila.Ing = ing.Detalle[item.Key];
                lista.Add(fila);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidarTextbox()){
                IdiomaDetalle detalle = new IdiomaDetalle();
                detalle.Idioma = idioma1;
                detalle.Clave = textBox1.Text;
                detalle.Texto = textBox2.Text;
                int resultado = BLL.GestionarIdioma.getInstance().insertarDetalle(detalle);

                IdiomaDetalle detalle2 = new IdiomaDetalle();
                detalle2.Idioma = idioma2;
                detalle2.Clave = textBox1.Text;
                detalle2.Texto = textBox3.Text;
                int resultado2 = BLL.GestionarIdioma.getInstance().insertarDetalle(detalle2);
                resultado += resultado2;
            if (resultado != 2)
                Mensaje("errorGuardar", "msgError");
                cargar();
                Limpiar();
            } else
            {
                Mensaje("errorFaltaDato", "msgError");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }
    }

    class IdiomaFila
    {
        public string Clave { get; set; }
        public string Esp { get; set; }
        public string Ing { get; set; }
    }
}
