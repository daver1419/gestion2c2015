namespace AerolineaFrba.Abm_Aeronave
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
            this.tablaDatos = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Buscar = new System.Windows.Forms.Button();
            this.Limpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboTipoServicio = new System.Windows.Forms.ComboBox();
            this.TextMatricula = new System.Windows.Forms.TextBox();
            this.TextModelo = new System.Windows.Forms.TextBox();
            this.ComboFabricante = new System.Windows.Forms.ComboBox();
            this.TipoServicio = new System.Windows.Forms.Label();
            this.Matricula = new System.Windows.Forms.Label();
            this.Fabricante = new System.Windows.Forms.Label();
            this.Modelo = new System.Windows.Forms.Label();
            this.FechaAlta = new System.Windows.Forms.Label();
            this.DateAlta = new System.Windows.Forms.DateTimePicker();
            this.NumericKG = new System.Windows.Forms.NumericUpDown();
            this.KG = new System.Windows.Forms.Label();
            this.ButacaNumeric = new System.Windows.Forms.NumericUpDown();
            this.Butacas = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButacaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDatos
            // 
            this.tablaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.tablaDatos.Location = new System.Drawing.Point(12, 342);
            this.tablaDatos.Name = "tablaDatos";
            this.tablaDatos.Size = new System.Drawing.Size(557, 156);
            this.tablaDatos.TabIndex = 4;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(104, 313);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 6;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(409, 313);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 7;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ComboTipoServicio);
            this.groupBox1.Controls.Add(this.TextMatricula);
            this.groupBox1.Controls.Add(this.TextModelo);
            this.groupBox1.Controls.Add(this.ComboFabricante);
            this.groupBox1.Controls.Add(this.TipoServicio);
            this.groupBox1.Controls.Add(this.Matricula);
            this.groupBox1.Controls.Add(this.Fabricante);
            this.groupBox1.Controls.Add(this.Modelo);
            this.groupBox1.Controls.Add(this.FechaAlta);
            this.groupBox1.Controls.Add(this.DateAlta);
            this.groupBox1.Controls.Add(this.NumericKG);
            this.groupBox1.Controls.Add(this.KG);
            this.groupBox1.Controls.Add(this.ButacaNumeric);
            this.groupBox1.Controls.Add(this.Butacas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 295);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Búsqueda";
            // 
            // ComboTipoServicio
            // 
            this.ComboTipoServicio.FormattingEnabled = true;
            this.ComboTipoServicio.Location = new System.Drawing.Point(243, 166);
            this.ComboTipoServicio.Name = "ComboTipoServicio";
            this.ComboTipoServicio.Size = new System.Drawing.Size(200, 21);
            this.ComboTipoServicio.TabIndex = 28;
            // 
            // TextMatricula
            // 
            this.TextMatricula.Location = new System.Drawing.Point(243, 134);
            this.TextMatricula.Name = "TextMatricula";
            this.TextMatricula.Size = new System.Drawing.Size(200, 20);
            this.TextMatricula.TabIndex = 27;
            // 
            // TextModelo
            // 
            this.TextModelo.Location = new System.Drawing.Point(243, 103);
            this.TextModelo.Name = "TextModelo";
            this.TextModelo.Size = new System.Drawing.Size(200, 20);
            this.TextModelo.TabIndex = 26;
            // 
            // ComboFabricante
            // 
            this.ComboFabricante.FormattingEnabled = true;
            this.ComboFabricante.Location = new System.Drawing.Point(243, 76);
            this.ComboFabricante.Name = "ComboFabricante";
            this.ComboFabricante.Size = new System.Drawing.Size(200, 21);
            this.ComboFabricante.TabIndex = 25;
            // 
            // TipoServicio
            // 
            this.TipoServicio.AutoSize = true;
            this.TipoServicio.Location = new System.Drawing.Point(125, 169);
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.Size = new System.Drawing.Size(82, 13);
            this.TipoServicio.TabIndex = 22;
            this.TipoServicio.Text = "Tipo de servicio";
            // 
            // Matricula
            // 
            this.Matricula.AutoSize = true;
            this.Matricula.Location = new System.Drawing.Point(125, 141);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(50, 13);
            this.Matricula.TabIndex = 21;
            this.Matricula.Text = "Matricula";
            // 
            // Fabricante
            // 
            this.Fabricante.AutoSize = true;
            this.Fabricante.Location = new System.Drawing.Point(125, 79);
            this.Fabricante.Name = "Fabricante";
            this.Fabricante.Size = new System.Drawing.Size(57, 13);
            this.Fabricante.TabIndex = 20;
            this.Fabricante.Text = "Fabricante";
            // 
            // Modelo
            // 
            this.Modelo.AutoSize = true;
            this.Modelo.Location = new System.Drawing.Point(125, 110);
            this.Modelo.Name = "Modelo";
            this.Modelo.Size = new System.Drawing.Size(42, 13);
            this.Modelo.TabIndex = 19;
            this.Modelo.Text = "Modelo";
            // 
            // FechaAlta
            // 
            this.FechaAlta.AutoSize = true;
            this.FechaAlta.Location = new System.Drawing.Point(125, 56);
            this.FechaAlta.Name = "FechaAlta";
            this.FechaAlta.Size = new System.Drawing.Size(73, 13);
            this.FechaAlta.TabIndex = 18;
            this.FechaAlta.Text = "Fecha de Alta";
            // 
            // DateAlta
            // 
            this.DateAlta.Location = new System.Drawing.Point(243, 50);
            this.DateAlta.Name = "DateAlta";
            this.DateAlta.Size = new System.Drawing.Size(200, 20);
            this.DateAlta.TabIndex = 17;
            // 
            // NumericKG
            // 
            this.NumericKG.Location = new System.Drawing.Point(243, 198);
            this.NumericKG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericKG.Name = "NumericKG";
            this.NumericKG.Size = new System.Drawing.Size(200, 20);
            this.NumericKG.TabIndex = 29;
            // 
            // KG
            // 
            this.KG.AutoSize = true;
            this.KG.Location = new System.Drawing.Point(125, 198);
            this.KG.Name = "KG";
            this.KG.Size = new System.Drawing.Size(67, 13);
            this.KG.TabIndex = 23;
            this.KG.Text = "Cantidad KG";
            // 
            // ButacaNumeric
            // 
            this.ButacaNumeric.Enabled = false;
            this.ButacaNumeric.Location = new System.Drawing.Point(243, 224);
            this.ButacaNumeric.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ButacaNumeric.Name = "ButacaNumeric";
            this.ButacaNumeric.Size = new System.Drawing.Size(200, 20);
            this.ButacaNumeric.TabIndex = 30;
            // 
            // Butacas
            // 
            this.Butacas.AutoSize = true;
            this.Butacas.Location = new System.Drawing.Point(125, 226);
            this.Butacas.Name = "Butacas";
            this.Butacas.Size = new System.Drawing.Size(46, 13);
            this.Butacas.TabIndex = 24;
            this.Butacas.Text = "Butacas";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ListadoAeronaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.tablaDatos);
            this.Name = "ListadoAeronaves";
            this.Text = "Listado de Aeronaves";
            ((System.ComponentModel.ISupportInitialize)(this.tablaDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericKG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButacaNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDatos;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboTipoServicio;
        private System.Windows.Forms.TextBox TextMatricula;
        private System.Windows.Forms.TextBox TextModelo;
        private System.Windows.Forms.ComboBox ComboFabricante;
        private System.Windows.Forms.Label TipoServicio;
        private System.Windows.Forms.Label Matricula;
        private System.Windows.Forms.Label Fabricante;
        private System.Windows.Forms.Label Modelo;
        private System.Windows.Forms.Label FechaAlta;
        private System.Windows.Forms.DateTimePicker DateAlta;
        private System.Windows.Forms.NumericUpDown NumericKG;
        private System.Windows.Forms.Label KG;
        private System.Windows.Forms.NumericUpDown ButacaNumeric;
        private System.Windows.Forms.Label Butacas;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}