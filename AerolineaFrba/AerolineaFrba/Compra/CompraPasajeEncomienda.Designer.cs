namespace AerolineaFrba.Compra
{
    partial class CompraPasajeEncomienda
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
            this.dateTimePickerEnt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCiudOrig = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCiudDest = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnCompra = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerSal = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCantPas = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerEnt
            // 
            this.dateTimePickerEnt.Location = new System.Drawing.Point(184, 36);
            this.dateTimePickerEnt.Name = "dateTimePickerEnt";
            this.dateTimePickerEnt.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEnt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha de salida";
            // 
            // comboBoxCiudOrig
            // 
            this.comboBoxCiudOrig.FormattingEnabled = true;
            this.comboBoxCiudOrig.Location = new System.Drawing.Point(184, 103);
            this.comboBoxCiudOrig.Name = "comboBoxCiudOrig";
            this.comboBoxCiudOrig.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCiudOrig.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ciudad de origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ciudad de destino";
            // 
            // comboBoxCiudDest
            // 
            this.comboBoxCiudDest.FormattingEnabled = true;
            this.comboBoxCiudDest.Location = new System.Drawing.Point(184, 141);
            this.comboBoxCiudDest.Name = "comboBoxCiudDest";
            this.comboBoxCiudDest.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCiudDest.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCompra});
            this.dataGridView1.Location = new System.Drawing.Point(50, 252);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(585, 147);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnCompra
            // 
            this.ColumnCompra.HeaderText = "Comprar";
            this.ColumnCompra.Name = "ColumnCompra";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(50, 202);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 7;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(560, 202);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 8;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha de llegada";
            // 
            // dateTimePickerSal
            // 
            this.dateTimePickerSal.Location = new System.Drawing.Point(184, 71);
            this.dateTimePickerSal.Name = "dateTimePickerSal";
            this.dateTimePickerSal.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerSal.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(658, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ingrese los siguientes datos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(658, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Cantidad Pasajes a comprar:";
            // 
            // comboBoxCantPas
            // 
            this.comboBoxCantPas.FormattingEnabled = true;
            this.comboBoxCantPas.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxCantPas.Location = new System.Drawing.Point(661, 307);
            this.comboBoxCantPas.Name = "comboBoxCantPas";
            this.comboBoxCantPas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCantPas.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(661, 354);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kgs a enviar:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(664, 379);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(707, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "y/o";
            // 
            // CompraPasajeEncomienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 423);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxCantPas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerSal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxCiudDest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCiudOrig);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEnt);
            this.Name = "CompraPasajeEncomienda";
            this.Text = "Compra de pasaje/encomienda";
            this.Load += new System.EventHandler(this.CompraPasajeEncomienda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerEnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCiudOrig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCiudDest;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dateTimePickerSal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxCantPas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label8;
    }
}