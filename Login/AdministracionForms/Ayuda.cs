using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.AdministracionForms
{
    public partial class Ayuda : IdiomaForm
    {
        public string Formulario { get; set; }

        public Ayuda()
        {
            InitializeComponent();
        }

        private void Ayuda_Load(object sender, EventArgs e)
        {
            this.HelpButton = false;
            this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(Formulario);

        }
    }
}
