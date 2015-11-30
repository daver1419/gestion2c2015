namespace AerolineaFrba.Generacion_Viaje
{
    partial class GeneracionViaje
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonGenerar = new System.Windows.Forms.Button();
            this.dateTimePickerFechSal = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechLLEstim = new System.Windows.Forms.DateTimePicker();
            this.textBoxRuta = new System.Windows.Forms.TextBox();
            this.textBoxAeronave = new System.Windows.Forms.TextBox();
            this.buttonSelRuta = new System.Windows.Forms.Button();
            this.buttonSelAeronave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha salida";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha llegada estimada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Aeronave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ruta";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(36, 266);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 5;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonGenerar
            // 
            this.buttonGenerar.Location = new System.Drawing.Point(290, 266);
            this.buttonGenerar.Name = "buttonGenerar";
            this.buttonGenerar.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerar.TabIndex = 6;
            this.buttonGenerar.Text = "Generar";
            this.buttonGenerar.UseVisualStyleBackColor = true;
            this.buttonGenerar.Click += new System.EventHandler(this.buttonGenerar_Click);
            // 
            // dateTimePickerFechSal
            // 
            this.dateTimePickerFechSal.CustomFormat = "dd-MMM-yy hh:mm:ss";
            this.dateTimePickerFechSal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFechSal.Location = new System.Drawing.Point(169, 52);
            this.dateTimePickerFechSal.Name = "dateTimePickerFechSal";
            this.dateTimePickerFechSal.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechSal.TabIndex = 7;
            // 
            // dateTimePickerFechLLEstim
            // 
            this.dateTimePickerFechLLEstim.CustomFormat = "dd-MMM-yy hh:mm:ss";
            this.dateTimePickerFechLLEstim.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFechLLEstim.Location = new System.Drawing.Point(169, 96);
            this.dateTimePickerFechLLEstim.Name = "dateTimePickerFechLLEstim";
            this.dateTimePickerFechLLEstim.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechLLEstim.TabIndex = 9;
            // 
            // textBoxRuta
            // 
            this.textBoxRuta.Enabled = false;
            this.textBoxRuta.Location = new System.Drawing.Point(169, 141);
            this.textBoxRuta.Name = "textBoxRuta";
            this.textBoxRuta.Size = new System.Drawing.Size(100, 20);
            this.textBoxRuta.TabIndex = 10;
            this.textBoxRuta.TextChanged += new System.EventHandler(this.textBoxRuta_TextChanged);
            // 
            // textBoxAeronave
            // 
            this.textBoxAeronave.Enabled = false;
            this.textBoxAeronave.Location = new System.Drawing.Point(169, 185);
            this.textBoxAeronave.Name = "textBoxAeronave";
            this.textBoxAeronave.Size = new System.Drawing.Size(100, 20);
            this.textBoxAeronave.TabIndex = 11;
            // 
            // buttonSelRuta
            // 
            this.buttonSelRuta.Location = new System.Drawing.Point(290, 138);
            this.buttonSelRuta.Name = "buttonSelRuta";
            this.buttonSelRuta.Size = new System.Drawing.Size(75, 23);
            this.buttonSelRuta.TabIndex = 12;
            this.buttonSelRuta.Text = "Seleccionar";
            this.buttonSelRuta.UseVisualStyleBackColor = true;
            this.buttonSelRuta.Click += new System.EventHandler(this.buttonSelRuta_Click);
            // 
            // buttonSelAeronave
            // 
            this.buttonSelAeronave.Enabled = false;
            this.buttonSelAeronave.Location = new System.Drawing.Point(290, 182);
            this.buttonSelAeronave.Name = "buttonSelAeronave";
            this.buttonSelAeronave.Size = new System.Drawing.Size(75, 23);
            this.buttonSelAeronave.TabIndex = 13;
            this.buttonSelAeronave.Text = "Seleccionar";
            this.buttonSelAeronave.UseVisualStyleBackColor = true;
            this.buttonSelAeronave.Click += new System.EventHandler(this.buttonSelAeronave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GeneracionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 307);
            this.Controls.Add(this.buttonSelAeronave);
            this.Controls.Add(this.buttonSelRuta);
            this.Controls.Add(this.textBoxAeronave);
            this.Controls.Add(this.textBoxRuta);
            this.Controls.Add(this.dateTimePickerFechLLEstim);
            this.Controls.Add(this.dateTimePickerFechSal);
            this.Controls.Add(this.buttonGenerar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "GeneracionViaje";
            this.Text = "Generacion Viaje";
            this.Load += new System.EventHandler(this.GeneracionViaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonGenerar;
        public System.Windows.Forms.DateTimePicker dateTimePickerFechSal;
        public System.Windows.Forms.DateTimePicker dateTimePickerFechLLEstim;
        public System.Windows.Forms.TextBox textBoxRuta;
        public System.Windows.Forms.TextBox textBoxAeronave;
        private System.Windows.Forms.Button buttonSelRuta;
        private System.Windows.Forms.Button buttonSelAeronave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}