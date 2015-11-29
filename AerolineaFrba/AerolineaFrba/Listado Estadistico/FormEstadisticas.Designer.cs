namespace AerolineaFrba.Listado_Estadistico
{
    partial class FormEstadisticas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listOpciones = new System.Windows.Forms.ListBox();
            this.comboSemestre = new System.Windows.Forms.ComboBox();
            this.comboAnio = new System.Windows.Forms.ComboBox();
            this.Limpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccionar Semestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Seleccione el listado que desea visualizar";
            // 
            // listOpciones
            // 
            this.listOpciones.FormattingEnabled = true;
            this.listOpciones.Items.AddRange(new object[] {
            "Top 5 de los destinos con más pasajes comprados",
            "Top 5 de los destinos con aeronaves más vacías",
            "Top 5 de los Clientes con más puntos acumulados a la fecha",
            "Top 5 de los destinos con pasajes cancelados",
            "Top 5 de las aeronaves con mayor cantidad de días fuera de servicio"});
            this.listOpciones.Location = new System.Drawing.Point(50, 198);
            this.listOpciones.Name = "listOpciones";
            this.listOpciones.Size = new System.Drawing.Size(322, 95);
            this.listOpciones.TabIndex = 5;
            this.listOpciones.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboSemestre
            // 
            this.comboSemestre.FormattingEnabled = true;
            this.comboSemestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboSemestre.Location = new System.Drawing.Point(210, 100);
            this.comboSemestre.Name = "comboSemestre";
            this.comboSemestre.Size = new System.Drawing.Size(121, 21);
            this.comboSemestre.TabIndex = 3;
            // 
            // comboAnio
            // 
            this.comboAnio.FormattingEnabled = true;
            this.comboAnio.Items.AddRange(new object[] {
            "2030",
            "2029",
            "2028",
            "2027",
            "2026",
            "2025",
            "2024",
            "2023",
            "2022",
            "2021",
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000"});
            this.comboAnio.Location = new System.Drawing.Point(210, 53);
            this.comboAnio.Name = "comboAnio";
            this.comboAnio.Size = new System.Drawing.Size(121, 21);
            this.comboAnio.TabIndex = 2;
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(174, 302);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 8;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 337);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.listOpciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboSemestre);
            this.Controls.Add(this.comboAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormEstadisticas";
            this.Text = "Listados estadisticos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listOpciones;
        private System.Windows.Forms.ComboBox comboSemestre;
        private System.Windows.Forms.ComboBox comboAnio;
        private System.Windows.Forms.Button Limpiar;
    }
}