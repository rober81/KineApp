﻿using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class IdiomaForm : Form, BE.iCambiarIdioma
    {
        public IdiomaForm()
        {
            InitializeComponent();
        }

        public virtual void actualizar()
        {
            if (null != this.Tag && ! string.IsNullOrWhiteSpace(this.Tag.ToString()))
                this.Text = Traducir(this.Tag.ToString());
            actualizarControles(this.Controls);
        }

        private void actualizarControles(Control.ControlCollection controles)
        {
            foreach (Control item in controles)
            {
                if (null != item.Tag && !(item is TextBox))
                    item.Text = Traducir(item.Tag.ToString());
                if (item.Controls.Count > 0)
                    actualizarControles(item.Controls);
            }
        }

        protected string Traducir(string texto)
        {
            return BLL.GestionarIdioma.getInstance().getTexto(texto);
        }

        protected void Mensaje (string texto)
        {
             MessageBox.Show(Traducir(texto));
        }

        protected void Mensaje(string texto, string titulo)
        {
            MessageBox.Show(Traducir(texto), Traducir(titulo));
        }

        private void IdiomaForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            actualizar();
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Ayuda);
            this.HelpButton = true;
        }

        protected virtual Boolean ValidarTextbox()
        {
            return ValidarTextbox(this.Controls);
        }

        private Boolean ValidarTextbox(Control.ControlCollection controles)
        {
            bool resultado = true;
            foreach (Control item in controles)
            {
                if (item.Controls.Count > 0 && item is GroupBox)
                    resultado = resultado && ValidarTextbox(item.Controls);
                if (item is TextBox && item.CausesValidation && string.IsNullOrWhiteSpace(item.Text))
                {
                    if (null != item.Tag)
                        MessageBox.Show(Traducir("msgFaltaCompletar") + " " + Traducir(item.Tag.ToString()), Traducir("msgFaltaCompletarTitulo"));
                    resultado = false;
                }
            }
            return resultado;
        }

        private void Ayuda(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            AdministracionForms.Ayuda dialog = new AdministracionForms.Ayuda();
            dialog.Formulario = this.Name;
            dialog.ShowDialog(this);
            dialog.Dispose();
        }
    }
}
