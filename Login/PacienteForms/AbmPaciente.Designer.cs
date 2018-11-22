namespace GUI
{
    partial class AbmPaciente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(498, 341);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 39);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Tag = "btnCancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(594, 341);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(91, 39);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Tag = "btnAceptar";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.CustomFormat = "dd/MM/yyyy";
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFecha.Location = new System.Drawing.Point(200, 289);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFecha.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(176, 22);
            this.dtFecha.TabIndex = 7;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(53, 180);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(31, 17);
            this.lblDni.TabIndex = 30;
            this.lblDni.Tag = "lblDni";
            this.lblDni.Text = "DNI";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(130, 252);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(555, 22);
            this.txtApellido.TabIndex = 6;
            this.txtApellido.Tag = "lblApellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(130, 215);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(555, 22);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.Tag = "lblNombre";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(130, 180);
            this.txtDni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDni.MaxLength = 9;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(247, 22);
            this.txtDni.TabIndex = 4;
            this.txtDni.Tag = "lblDni";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(53, 295);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(141, 17);
            this.lblEdad.TabIndex = 26;
            this.lblEdad.Tag = "lblEdad";
            this.lblEdad.Text = "Fecha de Nacimiento";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(53, 257);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 25;
            this.lblApellido.Tag = "lblApellido";
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(53, 218);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 24;
            this.lblNombre.Tag = "lblNombre";
            this.lblNombre.Text = "Nombre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources._1;
            this.pictureBox1.Location = new System.Drawing.Point(-5, -46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(744, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // AbmPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 401);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbmPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmModificarPaciente";
            this.Text = "Modificar Paciente";
            this.Load += new System.EventHandler(this.AbmPaciente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}