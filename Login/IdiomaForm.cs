﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;

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
            foreach (Control item in this.Controls)
            {
                if (null != item.Tag)
                    item.Text = Traducir(item.Tag.ToString());
            }
        }

        protected string Traducir(string texto)
        {
            return BLL.GestionarIdioma.getInstance().getTexto(texto);
        }

        private void IdiomaForm_Load(object sender, EventArgs e)
        {
            actualizar();
        }


    }
}