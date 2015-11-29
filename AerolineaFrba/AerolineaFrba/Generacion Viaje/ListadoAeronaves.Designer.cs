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
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboModelo);
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
            this.groupBox1.Size = new System.Drawing.Size(639, 274);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Búsqueda";
            // 
            // ComboModelo
            // 
            this.ComboModelo.FormattingEnabled = true;
            this.ComboModelo.Location = new System.Drawing.Point(134, 97);
            this.ComboModelo.Name = "ComboModelo";
            this.ComboModelo.Size = new System.Drawing.Size(193, 21);
            this.ComboModelo.TabIndex = 41;
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
            this.ComboTipoServicio.Location = new System.Drawing.Point(134, 183);
            this.ComboTipoServicio.Name = "ComboTipoServicio";
            this.ComboTipoServicio.Size = new System.Drawing.Size(193, 21);
            this.ComboTipoServicio.TabIndex = 28;
            // 
            // TextMatricula
            // 
            this.TextMatricula.Location = new System.Drawing.Point(134, 140);
            this.TextMatricula.Name = "TextMatricula";
            this.TextMatricula.Size = new System.Drawing.Size(193, 20);
            this.TextMatricula.TabIndex = 27;
            // 
            // ComboFabricante
            // 
            this.ComboFabricante.FormattingEnabled = true;
            this.ComboFabricante.Location = new System.Drawing.Point(134, 59);
            this.ComboFabricante.Name = "ComboFabricante";
            this.ComboFabricante.Size = new System.Drawing.Size(193, 21);
            this.ComboFabricante.TabIndex = 25;
            // 
            // TipoServicio
            // 
            this.TipoServicio.AutoSize = true;
            this.TipoServicio.Location = new System.Drawing.Point(16, 186);
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.Size = new System.Drawing.Size(82, 13);
            this.TipoServicio.TabIndex = 22;
            this.TipoServicio.Text = "Tipo de servicio";
            // 
            // Matricula
            // 
            this.Matricula.AutoSize = true;
            this.Matricula.Location = new System.Drawing.Point(16, 147);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(50, 13);
            this.Matricula.TabIndex = 21;
            this.Matricula.Text = "Matricula";
            // 
            // Fabricante
            // 
            this.Fabricante.AutoSize = true;
            this.Fabricante.Location = new System.Drawing.Point(16, 67);
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.Size = new System.Drawing.Size(57, 13);
            this.Fabricante.TabIndex = 20;
            this.Fabricante.Text = "Fabricante";
            // 
            // Modelo
            // 
            this.Modelo.AutoSize = true;
            this.Modelo.Location = new System.Drawing.Point(16, 105);
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
            this.NumericKG.Location = new System.Drawing.Point(134, 215);
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
            this.KG.Location = new System.Drawing.Point(16, 215);
            this.KG.Name = "KG";
            this.KG.Size = new System.Drawing.Size(67, 13);
            this.KG.TabIndex = 23;
            this.KG.Text = "Cantidad KG";
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(488, 333);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 11;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(106, 333);
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
            this.tablaDatos.Location = new System.Drawing.Point(31, 410);
            this.tablaDatos.Name = "tablaDatos";
            this.tablaDatos.Size = new System.Drawing.Size(650, 156);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(28, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(657, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Se muestran solamente las aeronaves que no tienen viajes programados entre las fe" +
    "chas ingresadas anteriormente";
            // 
            // ListadoAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 583);
            this.Controls.Add(this.label4);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboModelo;
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
        private System.Windows.Forms.Label label4;
    }
}