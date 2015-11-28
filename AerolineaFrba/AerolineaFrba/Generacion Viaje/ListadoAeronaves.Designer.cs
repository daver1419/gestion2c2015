namespace AerolineaFrba.Generacion_Viaje
{
    partial class ListadoAeronaves
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboModelo = new System.Windows.Forms.ComboBox();
            this.DateVueltaFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DateVuelta = new System.Windows.Forms.DateTimePicker();
            this.DateFueraFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DateFuera = new System.Windows.Forms.DateTimePicker();
            this.DateBajaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DateBaja = new System.Windows.Forms.DateTimePicker();
            this.DateAltaFin = new System.Windows.Forms.DateTimePicker();
            this.ComboTipoServicio = new System.Windows.Forms.ComboBox();
            this.TextMatricula = new System.Windows.Forms.TextBox();
            this.ComboFabricante = new System.Windows.Forms.ComboBox();
            this.TipoServicio = new System.Windows.Forms.Label();
            this.Matricula = new System.Windows.Forms.Label();
            this.Fabricante = new System.Windows.Forms.Label();
            this.Modelo = new System.Windows.Forms.Label();
            this.FechaAlta = new System.Windows.Forms.Label();
            this.DateAlta = new System.Windows.Forms.DateTimePicker();
            this.NumericKG = new System.Windows.Forms.NumericUpDown();
            this.KG = new System.Windows.Forms.Label();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Button();
            this.tablaDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboModelo);
            this.groupBox1.Controls.Add(this.DateVueltaFin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DateVuelta);
            this.groupBox1.Controls.Add(this.DateFueraFin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DateFuera);
            this.groupBox1.Controls.Add(this.DateBajaFin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DateBaja);
            this.groupBox1.Controls.Add(this.DateAltaFin);
            this.groupBox1.Controls.Add(this.ComboTipoServicio);
            this.groupBox1.Controls.Add(this.TextMatricula);
            this.groupBox1.Controls.Add(this.ComboFabricante);
            this.groupBox1.Controls.Add(this.TipoServicio);
            this.groupBox1.Controls.Add(this.Matricula);
            this.groupBox1.Controls.Add(this.Fabricante);
            this.groupBox1.Controls.Add(this.Modelo);
            this.groupBox1.Controls.Add(this.FechaAlta);
            this.groupBox1.Controls.Add(this.DateAlta);
            this.groupBox1.Controls.Add(this.NumericKG);
            this.groupBox1.Controls.Add(this.KG);
            this.groupBox1.Location = new System.Drawing.Point(31, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 318);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Búsqueda";
            // 
            // ComboModelo
            // 
            this.ComboModelo.FormattingEnabled = true;
            this.ComboModelo.Location = new System.Drawing.Point(134, 159);
            this.ComboModelo.Name = "ComboModelo";
            this.ComboModelo.Size = new System.Drawing.Size(193, 21);
            this.ComboModelo.TabIndex = 41;
            // 
            // DateVueltaFin
            // 
            this.DateVueltaFin.Checked = false;
            this.DateVueltaFin.Location = new System.Drawing.Point(357, 103);
            this.DateVueltaFin.Name = "DateVueltaFin";
            this.DateVueltaFin.ShowCheckBox = true;
            this.DateVueltaFin.Size = new System.Drawing.Size(193, 20);
            this.DateVueltaFin.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Fecha Vuelta Servicio";
            // 
            // DateVuelta
            // 
            this.DateVuelta.Checked = false;
            this.DateVuelta.Location = new System.Drawing.Point(134, 103);
            this.DateVuelta.Name = "DateVuelta";
            this.DateVuelta.ShowCheckBox = true;
            this.DateVuelta.Size = new System.Drawing.Size(193, 20);
            this.DateVuelta.TabIndex = 38;
            // 
            // DateFueraFin
            // 
            this.DateFueraFin.Checked = false;
            this.DateFueraFin.Location = new System.Drawing.Point(357, 77);
            this.DateFueraFin.Name = "DateFueraFin";
            this.DateFueraFin.ShowCheckBox = true;
            this.DateFueraFin.Size = new System.Drawing.Size(193, 20);
            this.DateFueraFin.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Fecha Fuera Servicio";
            // 
            // DateFuera
            // 
            this.DateFuera.Checked = false;
            this.DateFuera.Location = new System.Drawing.Point(134, 77);
            this.DateFuera.Name = "DateFuera";
            this.DateFuera.ShowCheckBox = true;
            this.DateFuera.Size = new System.Drawing.Size(193, 20);
            this.DateFuera.TabIndex = 35;
            // 
            // DateBajaFin
            // 
            this.DateBajaFin.Checked = false;
            this.DateBajaFin.Location = new System.Drawing.Point(357, 51);
            this.DateBajaFin.Name = "DateBajaFin";
            this.DateBajaFin.ShowCheckBox = true;
            this.DateBajaFin.Size = new System.Drawing.Size(193, 20);
            this.DateBajaFin.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Fecha Baja Definitiva";
            // 
            // DateBaja
            // 
            this.DateBaja.Checked = false;
            this.DateBaja.Location = new System.Drawing.Point(134, 51);
            this.DateBaja.Name = "DateBaja";
            this.DateBaja.ShowCheckBox = true;
            this.DateBaja.Size = new System.Drawing.Size(193, 20);
            this.DateBaja.TabIndex = 32;
            // 
            // DateAltaFin
            // 
            this.DateAltaFin.Checked = false;
            this.DateAltaFin.Location = new System.Drawing.Point(357, 25);
            this.DateAltaFin.Name = "DateAltaFin";
            this.DateAltaFin.ShowCheckBox = true;
            this.DateAltaFin.Size = new System.Drawing.Size(193, 20);
            this.DateAltaFin.TabIndex = 31;
            // 
            // ComboTipoServicio
            // 
            this.ComboTipoServicio.FormattingEnabled = true;
            this.ComboTipoServicio.Location = new System.Drawing.Point(134, 217);
            this.ComboTipoServicio.Name = "ComboTipoServicio";
            this.ComboTipoServicio.Size = new System.Drawing.Size(193, 21);
            this.ComboTipoServicio.TabIndex = 28;
            // 
            // TextMatricula
            // 
            this.TextMatricula.Location = new System.Drawing.Point(134, 185);
            this.TextMatricula.Name = "TextMatricula";
            this.TextMatricula.Size = new System.Drawing.Size(193, 20);
            this.TextMatricula.TabIndex = 27;
            // 
            // ComboFabricante
            // 
            this.ComboFabricante.FormattingEnabled = true;
            this.ComboFabricante.Location = new System.Drawing.Point(134, 132);
            this.ComboFabricante.Name = "ComboFabricante";
            this.ComboFabricante.Size = new System.Drawing.Size(193, 21);
            this.ComboFabricante.TabIndex = 25;
            // 
            // TipoServicio
            // 
            this.TipoServicio.AutoSize = true;
            this.TipoServicio.Location = new System.Drawing.Point(16, 220);
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.Size = new System.Drawing.Size(82, 13);
            this.TipoServicio.TabIndex = 22;
            this.TipoServicio.Text = "Tipo de servicio";
            // 
            // Matricula
            // 
            this.Matricula.AutoSize = true;
            this.Matricula.Location = new System.Drawing.Point(16, 192);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(50, 13);
            this.Matricula.TabIndex = 21;
            this.Matricula.Text = "Matricula";
            // 
            // Fabricante
            // 
            this.Fabricante.AutoSize = true;
            this.Fabricante.Location = new System.Drawing.Point(16, 135);
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.Size = new System.Drawing.Size(57, 13);
            this.Fabricante.TabIndex = 20;
            this.Fabricante.Text = "Fabricante";
            // 
            // Modelo
            // 
            this.Modelo.AutoSize = true;
            this.Modelo.Location = new System.Drawing.Point(16, 166);
            this.Modelo.Name = "Modelo";
            this.Modelo.Size = new System.Drawing.Size(42, 13);
            this.Modelo.TabIndex = 19;
            this.Modelo.Text = "Modelo";
            // 
            // FechaAlta
            // 
            this.FechaAlta.AutoSize = true;
            this.FechaAlta.Location = new System.Drawing.Point(16, 31);
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.Size = new System.Drawing.Size(73, 13);
            this.FechaAlta.TabIndex = 18;
            this.FechaAlta.Text = "Fecha de Alta";
            // 
            // DateAlta
            // 
            this.DateAlta.Checked = false;
            this.DateAlta.Location = new System.Drawing.Point(134, 25);
            this.DateAlta.Name = "DateAlta";
            this.DateAlta.ShowCheckBox = true;
            this.DateAlta.Size = new System.Drawing.Size(193, 20);
            this.DateAlta.TabIndex = 17;
            // 
            // NumericKG
            // 
            this.NumericKG.Location = new System.Drawing.Point(134, 249);
            this.NumericKG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericKG.Name = "NumericKG";
            this.NumericKG.Size = new System.Drawing.Size(193, 20);
            this.NumericKG.TabIndex = 29;
            // 
            // KG
            // 
            this.KG.AutoSize = true;
            this.KG.Location = new System.Drawing.Point(16, 249);
            this.KG.Name = "KG";
            this.KG.Size = new System.Drawing.Size(67, 13);
            this.KG.TabIndex = 23;
            this.KG.Text = "Cantidad KG";
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(415, 360);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 11;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(107, 360);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 10;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // tablaDatos
            // 
            this.tablaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.tablaDatos.Location = new System.Drawing.Point(31, 394);
            this.tablaDatos.Name = "tablaDatos";
            this.tablaDatos.Size = new System.Drawing.Size(563, 156);
            this.tablaDatos.TabIndex = 12;
            this.tablaDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaDatos_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ListadoAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 562);
            this.Controls.Add(this.tablaDatos);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ListadoAeronaves";
            this.Text = "ListadoAeronaves";
            this.Load += new System.EventHandler(this.ListadoAeronaves_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboModelo;
        private System.Windows.Forms.DateTimePicker DateVueltaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateVuelta;
        private System.Windows.Forms.DateTimePicker DateFueraFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateFuera;
        private System.Windows.Forms.DateTimePicker DateBajaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateBaja;
        private System.Windows.Forms.DateTimePicker DateAltaFin;
        private System.Windows.Forms.ComboBox ComboTipoServicio;
        private System.Windows.Forms.TextBox TextMatricula;
        private System.Windows.Forms.ComboBox ComboFabricante;
        private System.Windows.Forms.Label TipoServicio;
        private System.Windows.Forms.Label Matricula;
        private System.Windows.Forms.Label Fabricante;
        private System.Windows.Forms.Label Modelo;
        private System.Windows.Forms.Label FechaAlta;
        private System.Windows.Forms.DateTimePicker DateAlta;
        private System.Windows.Forms.NumericUpDown NumericKG;
        private System.Windows.Forms.Label KG;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.DataGridView tablaDatos;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}