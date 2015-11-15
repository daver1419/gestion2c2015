namespace AerolineaFrba.Abm_Aeronave
{
    partial class AltaAeronave
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
            this.components = new System.ComponentModel.Container();
            this.DateAlta = new System.Windows.Forms.DateTimePicker();
            this.FechaAlta = new System.Windows.Forms.Label();
            this.Modelo = new System.Windows.Forms.Label();
            this.Fabricante = new System.Windows.Forms.Label();
            this.Matricula = new System.Windows.Forms.Label();
            this.TipoServicio = new System.Windows.Forms.Label();
            this.KG = new System.Windows.Forms.Label();
            this.Butacas = new System.Windows.Forms.Label();
            this.ComboFabricante = new System.Windows.Forms.ComboBox();
            this.TextModelo = new System.Windows.Forms.TextBox();
            this.TextMatricula = new System.Windows.Forms.TextBox();
            this.ComboTipoServicio = new System.Windows.Forms.ComboBox();
            this.NumericKG = new System.Windows.Forms.NumericUpDown();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButacaNumeric = new System.Windows.Forms.NumericUpDown();
            this.ButacaButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButacaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DateAlta
            // 
            this.DateAlta.Location = new System.Drawing.Point(129, 20);
            this.DateAlta.Name = "DateAlta";
            this.DateAlta.Size = new System.Drawing.Size(200, 20);
            this.DateAlta.TabIndex = 0;
            // 
            // FechaAlta
            // 
            this.FechaAlta.AutoSize = true;
            this.FechaAlta.Location = new System.Drawing.Point(11, 26);
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.Size = new System.Drawing.Size(73, 13);
            this.FechaAlta.TabIndex = 1;
            this.FechaAlta.Text = "Fecha de Alta";
            // 
            // Modelo
            // 
            this.Modelo.AutoSize = true;
            this.Modelo.Location = new System.Drawing.Point(23, 94);
            this.Modelo.Name = "Modelo";
            this.Modelo.Size = new System.Drawing.Size(42, 13);
            this.Modelo.TabIndex = 2;
            this.Modelo.Text = "Modelo";
            // 
            // Fabricante
            // 
            this.Fabricante.AutoSize = true;
            this.Fabricante.Location = new System.Drawing.Point(23, 63);
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.Size = new System.Drawing.Size(57, 13);
            this.Fabricante.TabIndex = 3;
            this.Fabricante.Text = "Fabricante";
            // 
            // Matricula
            // 
            this.Matricula.AutoSize = true;
            this.Matricula.Location = new System.Drawing.Point(23, 125);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(50, 13);
            this.Matricula.TabIndex = 4;
            this.Matricula.Text = "Matricula";
            // 
            // TipoServicio
            // 
            this.TipoServicio.AutoSize = true;
            this.TipoServicio.Location = new System.Drawing.Point(23, 153);
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.Size = new System.Drawing.Size(82, 13);
            this.TipoServicio.TabIndex = 5;
            this.TipoServicio.Text = "Tipo de servicio";
            // 
            // KG
            // 
            this.KG.AutoSize = true;
            this.KG.Location = new System.Drawing.Point(23, 182);
            this.KG.Name = "KG";
            this.KG.Size = new System.Drawing.Size(67, 13);
            this.KG.TabIndex = 6;
            this.KG.Text = "Cantidad KG";
            // 
            // Butacas
            // 
            this.Butacas.AutoSize = true;
            this.Butacas.Location = new System.Drawing.Point(11, 225);
            this.Butacas.Name = "Butacas";
            this.Butacas.Size = new System.Drawing.Size(46, 13);
            this.Butacas.TabIndex = 7;
            this.Butacas.Text = "Butacas";
            // 
            // ComboFabricante
            // 
            this.ComboFabricante.FormattingEnabled = true;
            this.ComboFabricante.Location = new System.Drawing.Point(141, 60);
            this.ComboFabricante.Name = "ComboFabricante";
            this.ComboFabricante.Size = new System.Drawing.Size(200, 21);
            this.ComboFabricante.TabIndex = 8;
            // 
            // TextModelo
            // 
            this.TextModelo.Location = new System.Drawing.Point(141, 87);
            this.TextModelo.Name = "TextModelo";
            this.TextModelo.Size = new System.Drawing.Size(200, 20);
            this.TextModelo.TabIndex = 9;
            // 
            // TextMatricula
            // 
            this.TextMatricula.Location = new System.Drawing.Point(141, 118);
            this.TextMatricula.Name = "TextMatricula";
            this.TextMatricula.Size = new System.Drawing.Size(200, 20);
            this.TextMatricula.TabIndex = 10;
            // 
            // ComboTipoServicio
            // 
            this.ComboTipoServicio.FormattingEnabled = true;
            this.ComboTipoServicio.Location = new System.Drawing.Point(141, 150);
            this.ComboTipoServicio.Name = "ComboTipoServicio";
            this.ComboTipoServicio.Size = new System.Drawing.Size(200, 21);
            this.ComboTipoServicio.TabIndex = 11;
            // 
            // NumericKG
            // 
            this.NumericKG.Location = new System.Drawing.Point(141, 182);
            this.NumericKG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericKG.Name = "NumericKG";
            this.NumericKG.Size = new System.Drawing.Size(200, 20);
            this.NumericKG.TabIndex = 12;
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(26, 315);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 13;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(266, 315);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 14;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButacaButton);
            this.groupBox1.Controls.Add(this.ButacaNumeric);
            this.groupBox1.Controls.Add(this.Butacas);
            this.groupBox1.Controls.Add(this.FechaAlta);
            this.groupBox1.Controls.Add(this.DateAlta);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 274);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Aeronave";
            // 
            // ButacaNumeric
            // 
            this.ButacaNumeric.Enabled = false;
            this.ButacaNumeric.Location = new System.Drawing.Point(254, 223);
            this.ButacaNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ButacaNumeric.Name = "ButacaNumeric";
            this.ButacaNumeric.Size = new System.Drawing.Size(75, 20);
            this.ButacaNumeric.TabIndex = 16;
            // 
            // ButacaButton
            // 
            this.ButacaButton.Location = new System.Drawing.Point(129, 220);
            this.ButacaButton.Name = "ButacaButton";
            this.ButacaButton.Size = new System.Drawing.Size(96, 23);
            this.ButacaButton.TabIndex = 16;
            this.ButacaButton.Text = "Agregar Butaca";
            this.ButacaButton.UseVisualStyleBackColor = true;
            this.ButacaButton.Click += new System.EventHandler(this.ButacaButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AltaAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 363);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.NumericKG);
            this.Controls.Add(this.ComboTipoServicio);
            this.Controls.Add(this.TextMatricula);
            this.Controls.Add(this.TextModelo);
            this.Controls.Add(this.ComboFabricante);
            this.Controls.Add(this.KG);
            this.Controls.Add(this.TipoServicio);
            this.Controls.Add(this.Matricula);
            this.Controls.Add(this.Fabricante);
            this.Controls.Add(this.Modelo);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaAeronave";
            this.Text = "Alta de Aeronave";
            this.Load += new System.EventHandler(this.Alta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButacaNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateAlta;
        private System.Windows.Forms.Label FechaAlta;
        private System.Windows.Forms.Label Modelo;
        private System.Windows.Forms.Label Fabricante;
        private System.Windows.Forms.Label Matricula;
        private System.Windows.Forms.Label TipoServicio;
        private System.Windows.Forms.Label KG;
        private System.Windows.Forms.Label Butacas;
        private System.Windows.Forms.ComboBox ComboFabricante;
        private System.Windows.Forms.TextBox TextModelo;
        private System.Windows.Forms.TextBox TextMatricula;
        private System.Windows.Forms.ComboBox ComboTipoServicio;
        private System.Windows.Forms.NumericUpDown NumericKG;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButacaButton;
        private System.Windows.Forms.NumericUpDown ButacaNumeric;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}