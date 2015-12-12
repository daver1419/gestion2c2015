namespace AerolineaFrba.Registro_Llegada_Destino
{
    partial class RegistroLlegadaDestino
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.comboBoxAeroOrigen = new System.Windows.Forms.ComboBox();
            this.comboBoxAeroDest = new System.Windows.Forms.ComboBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonMostrar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelInforme = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha y hora";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(243, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Matricula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aeropuerto origen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Aeropuerto destino";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Location = new System.Drawing.Point(243, 73);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(100, 20);
            this.textBoxMatricula.TabIndex = 5;
            // 
            // comboBoxAeroOrigen
            // 
            this.comboBoxAeroOrigen.FormattingEnabled = true;
            this.comboBoxAeroOrigen.Location = new System.Drawing.Point(243, 110);
            this.comboBoxAeroOrigen.Name = "comboBoxAeroOrigen";
            this.comboBoxAeroOrigen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAeroOrigen.TabIndex = 6;
            // 
            // comboBoxAeroDest
            // 
            this.comboBoxAeroDest.FormattingEnabled = true;
            this.comboBoxAeroDest.Location = new System.Drawing.Point(243, 148);
            this.comboBoxAeroDest.Name = "comboBoxAeroDest";
            this.comboBoxAeroDest.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAeroDest.TabIndex = 7;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(42, 207);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 35);
            this.buttonLimpiar.TabIndex = 8;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonMostrar
            // 
            this.buttonMostrar.Location = new System.Drawing.Point(463, 207);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(83, 35);
            this.buttonMostrar.TabIndex = 9;
            this.buttonMostrar.Text = "Registrar";
            this.buttonMostrar.UseVisualStyleBackColor = true;
            this.buttonMostrar.Click += new System.EventHandler(this.buttonMostrar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(42, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(504, 150);
            this.dataGridView1.TabIndex = 10;
            // 
            // labelInforme
            // 
            this.labelInforme.AutoSize = true;
            this.labelInforme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInforme.Location = new System.Drawing.Point(39, 259);
            this.labelInforme.Name = "labelInforme";
            this.labelInforme.Size = new System.Drawing.Size(35, 13);
            this.labelInforme.TabIndex = 11;
            this.labelInforme.Text = "label5";
            // 
            // RegistroLlegadaDestino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 447);
            this.Controls.Add(this.labelInforme);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonMostrar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.comboBoxAeroDest);
            this.Controls.Add(this.comboBoxAeroOrigen);
            this.Controls.Add(this.textBoxMatricula);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "RegistroLlegadaDestino";
            this.Text = "Registro de llegada destino";
            this.Load += new System.EventHandler(this.RegistroLlegadaDestino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.ComboBox comboBoxAeroOrigen;
        private System.Windows.Forms.ComboBox comboBoxAeroDest;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonMostrar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelInforme;
    }
}