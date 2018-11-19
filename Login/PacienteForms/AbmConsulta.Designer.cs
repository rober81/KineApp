namespace GUI.PacienteForms
{
    partial class AbmConsulta
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
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtResumen = new System.Windows.Forms.TextBox();
            this.lblResumen = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1176, 620);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 39);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Tag = "btnCancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(1272, 620);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(91, 39);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Tag = "btnAceptar";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(113, 38);
            this.txtPaciente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaciente.MaxLength = 100;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(531, 22);
            this.txtPaciente.TabIndex = 39;
            this.txtPaciente.Tag = "lblPaciente";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(36, 42);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(63, 17);
            this.lblPaciente.TabIndex = 38;
            this.lblPaciente.Tag = "lblPaciente";
            this.lblPaciente.Text = "Paciente";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(665, 30);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 39);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Tag = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.CausesValidation = false;
            this.lblID.Location = new System.Drawing.Point(776, 41);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 17);
            this.lblID.TabIndex = 41;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // dtFecha
            // 
            this.dtFecha.CustomFormat = "dd/MM/yyyy";
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFecha.Location = new System.Drawing.Point(113, 79);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFecha.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(139, 22);
            this.dtFecha.TabIndex = 43;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(36, 84);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 42;
            this.lblFecha.Tag = "lblFecha";
            this.lblFecha.Text = "Fecha";
            // 
            // txtResumen
            // 
            this.txtResumen.Location = new System.Drawing.Point(113, 115);
            this.txtResumen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResumen.MaxLength = 500;
            this.txtResumen.Multiline = true;
            this.txtResumen.Name = "txtResumen";
            this.txtResumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumen.Size = new System.Drawing.Size(900, 111);
            this.txtResumen.TabIndex = 44;
            this.txtResumen.Tag = "lblResumen";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(39, 115);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(68, 17);
            this.lblResumen.TabIndex = 45;
            this.lblResumen.Tag = "lblResumen";
            this.lblResumen.Text = "Resumen";
            // 
            // AbmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 681);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.txtResumen);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmConsulta";
            this.Text = "AbmConsulta";
            this.Load += new System.EventHandler(this.AbmConsulta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtResumen;
        private System.Windows.Forms.Label lblResumen;
    }
}