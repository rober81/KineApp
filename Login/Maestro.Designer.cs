namespace GUI
{
    partial class Maestro
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maestro));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPacienteAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPacienteModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConsulta = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEjercicios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntrenamientos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPatologias = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTratamientos = new System.Windows.Forms.ToolStripMenuItem();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBitacora = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopiaSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDigitoVerificador = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.españolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIdioma = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.pacientesToolStripMenuItem,
            this.serviciosToolStripMenuItem,
            this.administraciónToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(925, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Tag = "menuMenu";
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.cerrarSesiónToolStripMenuItem.Tag = "menuCerrarSesion";
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.salirToolStripMenuItem.Tag = "menuSalir";
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPacienteAlta,
            this.MenuPacienteModificar,
            this.MenuConsulta});
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.pacientesToolStripMenuItem.Tag = "menuGestionPacientes";
            this.pacientesToolStripMenuItem.Text = "Gestión de Pacientes";
            // 
            // MenuPacienteAlta
            // 
            this.MenuPacienteAlta.Name = "MenuPacienteAlta";
            this.MenuPacienteAlta.Size = new System.Drawing.Size(181, 26);
            this.MenuPacienteAlta.Tag = "menuPacienteAlta";
            this.MenuPacienteAlta.Text = "Alta";
            this.MenuPacienteAlta.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // MenuPacienteModificar
            // 
            this.MenuPacienteModificar.Name = "MenuPacienteModificar";
            this.MenuPacienteModificar.Size = new System.Drawing.Size(181, 26);
            this.MenuPacienteModificar.Tag = "menuPacienteModificacion";
            this.MenuPacienteModificar.Text = "Modificación";
            this.MenuPacienteModificar.Click += new System.EventHandler(this.modificaciónToolStripMenuItem_Click);
            // 
            // MenuConsulta
            // 
            this.MenuConsulta.Name = "MenuConsulta";
            this.MenuConsulta.Size = new System.Drawing.Size(181, 26);
            this.MenuConsulta.Tag = "menuPacienteConsulta";
            this.MenuConsulta.Text = "Consulta";
            this.MenuConsulta.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // serviciosToolStripMenuItem
            // 
            this.serviciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEjercicios,
            this.MenuEntrenamientos,
            this.MenuPatologias,
            this.MenuTratamientos});
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            this.serviciosToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.serviciosToolStripMenuItem.Tag = "menuEntrenamientos";
            this.serviciosToolStripMenuItem.Text = "Gestión de Entrenamientos";
            // 
            // MenuEjercicios
            // 
            this.MenuEjercicios.Name = "MenuEjercicios";
            this.MenuEjercicios.Size = new System.Drawing.Size(187, 26);
            this.MenuEjercicios.Tag = "menuEntrenamientosEjercicios";
            this.MenuEjercicios.Text = "Ejercicios";
            this.MenuEjercicios.Click += new System.EventHandler(this.tratamientosToolStripMenuItem_Click);
            // 
            // MenuEntrenamientos
            // 
            this.MenuEntrenamientos.Name = "MenuEntrenamientos";
            this.MenuEntrenamientos.Size = new System.Drawing.Size(187, 26);
            this.MenuEntrenamientos.Tag = "menuEntrenamientos";
            this.MenuEntrenamientos.Text = "Entrenamientos";
            this.MenuEntrenamientos.Click += new System.EventHandler(this.entrenamientosToolStripMenuItem_Click);
            // 
            // MenuPatologias
            // 
            this.MenuPatologias.Name = "MenuPatologias";
            this.MenuPatologias.Size = new System.Drawing.Size(187, 26);
            this.MenuPatologias.Tag = "MenuPatologias";
            this.MenuPatologias.Text = "Patologias";
            this.MenuPatologias.Click += new System.EventHandler(this.patologiasToolStripMenuItem_Click);
            // 
            // MenuTratamientos
            // 
            this.MenuTratamientos.Name = "MenuTratamientos";
            this.MenuTratamientos.Size = new System.Drawing.Size(187, 26);
            this.MenuTratamientos.Tag = "MenuTratamientos";
            this.MenuTratamientos.Text = "Tratamientos";
            this.MenuTratamientos.Click += new System.EventHandler(this.tratamientosToolStripMenuItem_Click_1);
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUsuarios,
            this.MenuRoles,
            this.MenuPerfiles,
            this.MenuBitacora,
            this.MenuCopiaSeguridad,
            this.MenuDigitoVerificador});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.administraciónToolStripMenuItem.Tag = "menuAdministracion";
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(291, 26);
            this.MenuUsuarios.Tag = "menuAdmUsuarios";
            this.MenuUsuarios.Text = "Gestión de Usuarios";
            this.MenuUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // MenuRoles
            // 
            this.MenuRoles.Name = "MenuRoles";
            this.MenuRoles.Size = new System.Drawing.Size(291, 26);
            this.MenuRoles.Tag = "menuAdmRoles";
            this.MenuRoles.Text = "Gestión de Roles";
            this.MenuRoles.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // MenuPerfiles
            // 
            this.MenuPerfiles.Name = "MenuPerfiles";
            this.MenuPerfiles.Size = new System.Drawing.Size(291, 26);
            this.MenuPerfiles.Tag = "menuAdmPerfiles";
            this.MenuPerfiles.Text = "Gestión de Perfiles";
            this.MenuPerfiles.Click += new System.EventHandler(this.perfilesToolStripMenuItem_Click);
            // 
            // MenuBitacora
            // 
            this.MenuBitacora.Name = "MenuBitacora";
            this.MenuBitacora.Size = new System.Drawing.Size(291, 26);
            this.MenuBitacora.Tag = "menuAdmBitacora";
            this.MenuBitacora.Text = "Consultar Bitácora";
            this.MenuBitacora.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // MenuCopiaSeguridad
            // 
            this.MenuCopiaSeguridad.Name = "MenuCopiaSeguridad";
            this.MenuCopiaSeguridad.Size = new System.Drawing.Size(291, 26);
            this.MenuCopiaSeguridad.Tag = "menuAdmBackup";
            this.MenuCopiaSeguridad.Text = "Gestión de Copia de Seguridad";
            this.MenuCopiaSeguridad.Click += new System.EventHandler(this.copiaDeSeguridadToolStripMenuItem_Click);
            // 
            // MenuDigitoVerificador
            // 
            this.MenuDigitoVerificador.Name = "MenuDigitoVerificador";
            this.MenuDigitoVerificador.Size = new System.Drawing.Size(291, 26);
            this.MenuDigitoVerificador.Tag = "frmDigito";
            this.MenuDigitoVerificador.Text = "Gestión de Digito Verificador";
            this.MenuDigitoVerificador.Click += new System.EventHandler(this.gestiónDeDigitoVerificadorToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.españolToolStripMenuItem,
            this.inglesToolStripMenuItem,
            this.MenuIdioma});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.idiomaToolStripMenuItem.Tag = "menuIdioma";
            this.idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // españolToolStripMenuItem
            // 
            this.españolToolStripMenuItem.Checked = true;
            this.españolToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.españolToolStripMenuItem.Name = "españolToolStripMenuItem";
            this.españolToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.españolToolStripMenuItem.Tag = "lblEspaniol";
            this.españolToolStripMenuItem.Text = "Español";
            this.españolToolStripMenuItem.Click += new System.EventHandler(this.españolToolStripMenuItem_Click);
            // 
            // inglesToolStripMenuItem
            // 
            this.inglesToolStripMenuItem.Name = "inglesToolStripMenuItem";
            this.inglesToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.inglesToolStripMenuItem.Tag = "lblIngles";
            this.inglesToolStripMenuItem.Text = "Ingles";
            this.inglesToolStripMenuItem.Click += new System.EventHandler(this.inglesToolStripMenuItem_Click);
            // 
            // MenuIdioma
            // 
            this.MenuIdioma.Name = "MenuIdioma";
            this.MenuIdioma.Size = new System.Drawing.Size(212, 26);
            this.MenuIdioma.Tag = "menuAdminIdioma";
            this.MenuIdioma.Text = "Administrar Idioma";
            this.MenuIdioma.Click += new System.EventHandler(this.agregarIdiomaToolStripMenuItem_Click);
            // 
            // Maestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 481);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Maestro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KineAPP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Maestro_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuPacienteAlta;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuRoles;
        private System.Windows.Forms.ToolStripMenuItem MenuBitacora;
        private System.Windows.Forms.ToolStripMenuItem MenuCopiaSeguridad;
        private System.Windows.Forms.ToolStripMenuItem MenuPacienteModificar;
        private System.Windows.Forms.ToolStripMenuItem serviciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEjercicios;
        private System.Windows.Forms.ToolStripMenuItem MenuEntrenamientos;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem españolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inglesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuIdioma;
        private System.Windows.Forms.ToolStripMenuItem MenuPerfiles;
        private System.Windows.Forms.ToolStripMenuItem MenuConsulta;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuDigitoVerificador;
        private System.Windows.Forms.ToolStripMenuItem MenuPatologias;
        private System.Windows.Forms.ToolStripMenuItem MenuTratamientos;
    }
}

