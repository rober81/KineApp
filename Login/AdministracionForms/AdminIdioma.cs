using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class AdminIdioma : IdiomaForm
    {

        List<Idioma> listaDeIdiomas = GestionarIdioma.getInstance().Listar();
        private DataTable dataTable;

        public AdminIdioma()
        {
            InitializeComponent();
        }

        private void AdminIdioma_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnAceptar;
            Estilo.Guardar(btnAceptar);
            Estilo.Cancelar(btnCancelar);
            Estilo.Agregar(btnAgregar);
            cargar();
        }

        private void cargar()
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();

            foreach (Idioma item in listaDeIdiomas)
            {
                BLL.GestionarIdioma.getInstance().Cargar(item);
                dictionary.Add(item.Nombre, item.Detalle);
            }
            int cantidadIdiomas = listaDeIdiomas.Count;
            int cantidadFilas = listaDeIdiomas[0].Detalle.Count;

            dataTable = new DataTable();

            dataTable.Columns.Add("Key");
            foreach (var key in dictionary.Keys)
            {
                dataTable.Columns.Add(key);
            }

            foreach (var keyIdioma in listaDeIdiomas[0].Detalle)
            {
                var row = dataTable.Rows.Add();
                row["Key"] = keyIdioma.Key;
                foreach (var key in dictionary.Keys)
                {
                    try
                    {
                        var fila = dictionary[key];
                        row[key] = fila[keyIdioma.Key];
                    }
                    catch
                    {
                        row[key] = null;
                    }
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dataTable;

            for (int i = 0; i < (cantidadIdiomas + 1); i++)
            {
                dataGridView1.Columns[i].Width = 200;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tabla = dataTable;
            List<IdiomaDetalle> lista = new List<IdiomaDetalle>();
            string clave;
            string error = string.Empty;
            int cantError = 0;
            foreach (DataRow fila in tabla.Rows)
            {
                if (string.IsNullOrWhiteSpace(fila["Key"].ToString()))
                {
                    MessageBox.Show(Traducir("errorFaltaDato") + " Key", Traducir("msgError"));
                    break;
                }
                else
                {
                    clave = fila["Key"].ToString();
                }

                foreach (DataColumn columna in tabla.Columns)
                {
                    if (! "Key".Equals(columna.Caption.ToString()))
                    {
                        string idioma = columna.Caption.ToString();
                        if (string.IsNullOrWhiteSpace(fila[idioma].ToString()))
                        {
                            error = error + clave + (cantError < 10 ? " - " : Environment.NewLine);
                            cantError = (cantError == 10 ? cantError = 0 : cantError++ );
                            break;
                        }
                        else
                        {
                            IdiomaDetalle detalle = new IdiomaDetalle();
                            detalle.Clave = clave;
                            detalle.Idioma = idioma;
                            detalle.Texto = fila[idioma].ToString();
                            lista.Add(detalle);
                        } 
                    }
                }
            }
            if (! string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(Traducir("errorFaltaDato") + Environment.NewLine + error, Traducir("msgError"));
            } else 
            {
                foreach (Idioma item in listaDeIdiomas)
                {
                    GestionarIdioma.getInstance().insertar(item);
                }
                foreach (var item in lista)
                {
                    int resultado = GestionarIdioma.getInstance().insertarDetalle(item);
                }
                Maestro master = this.MdiParent as Maestro;
                master.actualizarIdioma();
                Mensaje("msgOperacionOk");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarTextbox())
            {
                Idioma nuevo = GestionarIdioma.getInstance().CrearIdioma(txtNombre.Text);
                listaDeIdiomas.Add(nuevo);
                cargar();
            }
            Limpiar();
        }
    }
}
