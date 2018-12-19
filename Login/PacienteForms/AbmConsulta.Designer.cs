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
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtResumen = new System.Windows.Forms.TextBox();
            this.lblResumen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionTRA = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacionesPAT = new System.Windows.Forms.TextBox();
            this.btnBuscarPAT = new System.Windows.Forms.Button();
            this.txtDescripcionPAT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoverPAT = new System.Windows.Forms.Button();
            this.btnAgregarPAT = new System.Windows.Forms.Button();
            this.listaPAT = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarEJ = new System.Windows.Forms.Button();
            this.btnBuscarEN = new System.Windows.Forms.Button();
            this.btnBuscarTRA = new System.Windows.Forms.Button();
            this.txtResultadoTRA = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnRemoverTRA = new System.Windows.Forms.Button();
            this.btnAgregarTRA = new System.Windows.Forms.Button();
            this.listaTRA = new System.Windows.Forms.ListBox();
            this.txtObservacionesTRA = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(820, 592);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(68, 32);
            this.btnCancelar.TabIndex = 37;
            this.btnCancelar.Tag = "btnCancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(898, 592);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(68, 32);
            this.btnAceptar.TabIndex = 36;
            this.btnAceptar.Tag = "btnAceptar";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Location = new System.Drawing.Point(100, 28);
            this.txtPaciente.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaciente.MaxLength = 100;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(409, 20);
            this.txtPaciente.TabIndex = 39;
            this.txtPaciente.Tag = "lblPaciente";
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(19, 28);
            this.lblPaciente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(49, 13);
            this.lblPaciente.TabIndex = 38;
            this.lblPaciente.Tag = "lblPaciente";
            this.lblPaciente.Text = "Paciente";
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.Location = new System.Drawing.Point(521, 15);
            this.btnBuscarPaciente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(83, 44);
            this.btnBuscarPaciente.TabIndex = 40;
            this.btnBuscarPaciente.Tag = "btnBuscarPaciente";
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.CausesValidation = false;
            this.lblID.Location = new System.Drawing.Point(226, 62);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 41;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // dtFecha
            // 
            this.dtFecha.CustomFormat = "dd/MM/yyyy";
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFecha.Location = new System.Drawing.Point(100, 58);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtFecha.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(105, 20);
            this.dtFecha.TabIndex = 43;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(19, 62);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 42;
            this.lblFecha.Tag = "lblFecha";
            this.lblFecha.Text = "Fecha";
            // 
            // txtResumen
            // 
            this.txtResumen.Location = new System.Drawing.Point(21, 535);
            this.txtResumen.Margin = new System.Windows.Forms.Padding(2);
            this.txtResumen.MaxLength = 500;
            this.txtResumen.Multiline = true;
            this.txtResumen.Name = "txtResumen";
            this.txtResumen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResumen.Size = new System.Drawing.Size(786, 89);
            this.txtResumen.TabIndex = 44;
            this.txtResumen.Tag = "lblResumen";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(19, 513);
            this.lblResumen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(52, 13);
            this.lblResumen.TabIndex = 45;
            this.lblResumen.Tag = "lblResumen";
            this.lblResumen.Text = "Resumen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(393, 64);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 46;
            this.label4.Tag = "lblObservaciones";
            this.label4.Text = "Observaciones";
            // 
            // txtDescripcionTRA
            // 
            this.txtDescripcionTRA.CausesValidation = false;
            this.txtDescripcionTRA.Location = new System.Drawing.Point(475, 34);
            this.txtDescripcionTRA.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcionTRA.MaxLength = 100;
            this.txtDescripcionTRA.Name = "txtDescripcionTRA";
            this.txtDescripcionTRA.ReadOnly = true;
            this.txtDescripcionTRA.Size = new System.Drawing.Size(393, 20);
            this.txtDescripcionTRA.TabIndex = 59;
            this.txtDescripcionTRA.Tag = "lblDescripcion";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(393, 33);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 58;
            this.lblDescripcion.Tag = "lblDescripcion";
            this.lblDescripcion.Text = "Descripcion";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtObservacionesPAT);
            this.groupBox1.Controls.Add(this.btnBuscarPAT);
            this.groupBox1.Controls.Add(this.txtDescripcionPAT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRemoverPAT);
            this.groupBox1.Controls.Add(this.btnAgregarPAT);
            this.groupBox1.Controls.Add(this.listaPAT);
            this.groupBox1.Location = new System.Drawing.Point(21, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(980, 150);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "frmPatologias";
            this.groupBox1.Text = "Patologias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 73;
            this.label1.Tag = "lblObservaciones";
            this.label1.Text = "Observaciones";
            // 
            // txtObservacionesPAT
            // 
            this.txtObservacionesPAT.CausesValidation = false;
            this.txtObservacionesPAT.Location = new System.Drawing.Point(475, 55);
            this.txtObservacionesPAT.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservacionesPAT.MaxLength = 500;
            this.txtObservacionesPAT.Multiline = true;
            this.txtObservacionesPAT.Name = "txtObservacionesPAT";
            this.txtObservacionesPAT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacionesPAT.Size = new System.Drawing.Size(393, 85);
            this.txtObservacionesPAT.TabIndex = 72;
            this.txtObservacionesPAT.Tag = "lblObservaciones";
            // 
            // btnBuscarPAT
            // 
            this.btnBuscarPAT.Location = new System.Drawing.Point(877, 28);
            this.btnBuscarPAT.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarPAT.Name = "btnBuscarPAT";
            this.btnBuscarPAT.Size = new System.Drawing.Size(83, 44);
            this.btnBuscarPAT.TabIndex = 71;
            this.btnBuscarPAT.Tag = "btnBuscarPatologia";
            this.btnBuscarPAT.Text = "Buscar";
            this.btnBuscarPAT.UseVisualStyleBackColor = true;
            this.btnBuscarPAT.Click += new System.EventHandler(this.btnBuscarPAT_Click);
            // 
            // txtDescripcionPAT
            // 
            this.txtDescripcionPAT.CausesValidation = false;
            this.txtDescripcionPAT.Location = new System.Drawing.Point(475, 29);
            this.txtDescripcionPAT.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcionPAT.MaxLength = 100;
            this.txtDescripcionPAT.Name = "txtDescripcionPAT";
            this.txtDescripcionPAT.ReadOnly = true;
            this.txtDescripcionPAT.Size = new System.Drawing.Size(393, 20);
            this.txtDescripcionPAT.TabIndex = 70;
            this.txtDescripcionPAT.Tag = "lblDescripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 69;
            this.label3.Tag = "lblDescripcion";
            this.label3.Text = "Descripcion";
            // 
            // btnRemoverPAT
            // 
            this.btnRemoverPAT.Location = new System.Drawing.Point(318, 108);
            this.btnRemoverPAT.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverPAT.Name = "btnRemoverPAT";
            this.btnRemoverPAT.Size = new System.Drawing.Size(68, 32);
            this.btnRemoverPAT.TabIndex = 68;
            this.btnRemoverPAT.Tag = "btnRemover";
            this.btnRemoverPAT.Text = "Remover";
            this.btnRemoverPAT.UseVisualStyleBackColor = true;
            this.btnRemoverPAT.Click += new System.EventHandler(this.btnRemoverPAT_Click);
            // 
            // btnAgregarPAT
            // 
            this.btnAgregarPAT.Location = new System.Drawing.Point(877, 108);
            this.btnAgregarPAT.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPAT.Name = "btnAgregarPAT";
            this.btnAgregarPAT.Size = new System.Drawing.Size(68, 32);
            this.btnAgregarPAT.TabIndex = 67;
            this.btnAgregarPAT.Tag = "btnAgregar";
            this.btnAgregarPAT.Text = "Agregar";
            this.btnAgregarPAT.UseVisualStyleBackColor = true;
            this.btnAgregarPAT.Click += new System.EventHandler(this.btnAgregarPAT_Click);
            // 
            // listaPAT
            // 
            this.listaPAT.FormattingEnabled = true;
            this.listaPAT.Location = new System.Drawing.Point(14, 20);
            this.listaPAT.Margin = new System.Windows.Forms.Padding(2);
            this.listaPAT.Name = "listaPAT";
            this.listaPAT.Size = new System.Drawing.Size(300, 121);
            this.listaPAT.TabIndex = 66;
            this.listaPAT.SelectedIndexChanged += new System.EventHandler(this.listaPAT_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarEJ);
            this.groupBox2.Controls.Add(this.btnBuscarEN);
            this.groupBox2.Controls.Add(this.btnBuscarTRA);
            this.groupBox2.Controls.Add(this.txtResultadoTRA);
            this.groupBox2.Controls.Add(this.lblResultado);
            this.groupBox2.Controls.Add(this.btnRemoverTRA);
            this.groupBox2.Controls.Add(this.btnAgregarTRA);
            this.groupBox2.Controls.Add(this.listaTRA);
            this.groupBox2.Controls.Add(this.txtObservacionesTRA);
            this.groupBox2.Controls.Add(this.txtDescripcionTRA);
            this.groupBox2.Controls.Add(this.lblDescripcion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(21, 244);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(980, 258);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "frmTratamientos";
            this.groupBox2.Text = "Tratamientos";
            // 
            // btnBuscarEJ
            // 
            this.btnBuscarEJ.Location = new System.Drawing.Point(877, 132);
            this.btnBuscarEJ.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarEJ.Name = "btnBuscarEJ";
            this.btnBuscarEJ.Size = new System.Drawing.Size(83, 44);
            this.btnBuscarEJ.TabIndex = 70;
            this.btnBuscarEJ.Tag = "btnBuscarEjercicio";
            this.btnBuscarEJ.Text = "Ejercicio";
            this.btnBuscarEJ.UseVisualStyleBackColor = true;
            this.btnBuscarEJ.Click += new System.EventHandler(this.btnBuscarEJ_Click);
            // 
            // btnBuscarEN
            // 
            this.btnBuscarEN.Location = new System.Drawing.Point(877, 81);
            this.btnBuscarEN.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarEN.Name = "btnBuscarEN";
            this.btnBuscarEN.Size = new System.Drawing.Size(83, 45);
            this.btnBuscarEN.TabIndex = 69;
            this.btnBuscarEN.Tag = "btnBuscarEntrenamiento";
            this.btnBuscarEN.Text = "Entrenamiento";
            this.btnBuscarEN.UseVisualStyleBackColor = true;
            this.btnBuscarEN.Click += new System.EventHandler(this.btnBuscarEN_Click);
            // 
            // btnBuscarTRA
            // 
            this.btnBuscarTRA.Location = new System.Drawing.Point(877, 33);
            this.btnBuscarTRA.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarTRA.Name = "btnBuscarTRA";
            this.btnBuscarTRA.Size = new System.Drawing.Size(83, 45);
            this.btnBuscarTRA.TabIndex = 68;
            this.btnBuscarTRA.Tag = "btnBuscarTratamiento";
            this.btnBuscarTRA.Text = "Tratamiento";
            this.btnBuscarTRA.UseVisualStyleBackColor = true;
            this.btnBuscarTRA.Click += new System.EventHandler(this.btnBuscarTRA_Click);
            // 
            // txtResultadoTRA
            // 
            this.txtResultadoTRA.CausesValidation = false;
            this.txtResultadoTRA.Location = new System.Drawing.Point(475, 162);
            this.txtResultadoTRA.Margin = new System.Windows.Forms.Padding(2);
            this.txtResultadoTRA.MaxLength = 500;
            this.txtResultadoTRA.Multiline = true;
            this.txtResultadoTRA.Name = "txtResultadoTRA";
            this.txtResultadoTRA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultadoTRA.Size = new System.Drawing.Size(393, 85);
            this.txtResultadoTRA.TabIndex = 67;
            this.txtResultadoTRA.Tag = "lblObservaciones";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(393, 162);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(55, 13);
            this.lblResultado.TabIndex = 66;
            this.lblResultado.Tag = "lblResultado";
            this.lblResultado.Text = "Resultado";
            // 
            // btnRemoverTRA
            // 
            this.btnRemoverTRA.Location = new System.Drawing.Point(318, 214);
            this.btnRemoverTRA.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoverTRA.Name = "btnRemoverTRA";
            this.btnRemoverTRA.Size = new System.Drawing.Size(68, 32);
            this.btnRemoverTRA.TabIndex = 65;
            this.btnRemoverTRA.Tag = "btnRemover";
            this.btnRemoverTRA.Text = "Remover";
            this.btnRemoverTRA.UseVisualStyleBackColor = true;
            this.btnRemoverTRA.Click += new System.EventHandler(this.btnRemoverTRA_Click);
            // 
            // btnAgregarTRA
            // 
            this.btnAgregarTRA.Location = new System.Drawing.Point(877, 214);
            this.btnAgregarTRA.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarTRA.Name = "btnAgregarTRA";
            this.btnAgregarTRA.Size = new System.Drawing.Size(68, 32);
            this.btnAgregarTRA.TabIndex = 64;
            this.btnAgregarTRA.Tag = "btnAgregar";
            this.btnAgregarTRA.Text = "Agregar";
            this.btnAgregarTRA.UseVisualStyleBackColor = true;
            this.btnAgregarTRA.Click += new System.EventHandler(this.btnAgregarTRA_Click);
            // 
            // listaTRA
            // 
            this.listaTRA.FormattingEnabled = true;
            this.listaTRA.Location = new System.Drawing.Point(14, 22);
            this.listaTRA.Margin = new System.Windows.Forms.Padding(2);
            this.listaTRA.Name = "listaTRA";
            this.listaTRA.Size = new System.Drawing.Size(300, 225);
            this.listaTRA.TabIndex = 62;
            this.listaTRA.SelectedIndexChanged += new System.EventHandler(this.listaTRA_SelectedIndexChanged);
            // 
            // txtObservacionesTRA
            // 
            this.txtObservacionesTRA.CausesValidation = false;
            this.txtObservacionesTRA.Location = new System.Drawing.Point(475, 64);
            this.txtObservacionesTRA.Margin = new System.Windows.Forms.Padding(2);
            this.txtObservacionesTRA.MaxLength = 500;
            this.txtObservacionesTRA.Multiline = true;
            this.txtObservacionesTRA.Name = "txtObservacionesTRA";
            this.txtObservacionesTRA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacionesTRA.Size = new System.Drawing.Size(393, 85);
            this.txtObservacionesTRA.TabIndex = 61;
            this.txtObservacionesTRA.Tag = "lblObservaciones";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(898, 592);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(68, 32);
            this.btnImprimir.TabIndex = 68;
            this.btnImprimir.Tag = "btnImprimir";
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Visible = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // AbmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1010, 652);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.txtResumen);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmConsulta";
            this.Text = "AbmConsulta";
            this.Load += new System.EventHandler(this.AbmConsulta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtResumen;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionTRA;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacionesPAT;
        private System.Windows.Forms.Button btnBuscarPAT;
        private System.Windows.Forms.TextBox txtDescripcionPAT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoverPAT;
        private System.Windows.Forms.Button btnAgregarPAT;
        private System.Windows.Forms.ListBox listaPAT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnBuscarTRA;
        private System.Windows.Forms.TextBox txtResultadoTRA;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnRemoverTRA;
        private System.Windows.Forms.Button btnAgregarTRA;
        private System.Windows.Forms.ListBox listaTRA;
        private System.Windows.Forms.TextBox txtObservacionesTRA;
        private System.Windows.Forms.Button btnBuscarEJ;
        private System.Windows.Forms.Button btnBuscarEN;
        private System.Windows.Forms.Button btnImprimir;
    }
}