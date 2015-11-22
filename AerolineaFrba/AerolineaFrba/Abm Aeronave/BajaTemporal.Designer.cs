namespace AerolineaFrba.Abm_Aeronave
{
    partial class BajaTemporal
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
            this.label3 = new System.Windows.Forms.Label();
            this.DateVuelta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DateFuera = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.TextMotivo = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Limpiar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextMotivo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DateVuelta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DateFuera);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos baja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Fecha Vuelta Servicio";
            // 
            // DateVuelta
            // 
            this.DateVuelta.Checked = false;
            this.DateVuelta.Location = new System.Drawing.Point(158, 64);
            this.DateVuelta.Name = "DateVuelta";
            this.DateVuelta.Size = new System.Drawing.Size(193, 20);
            this.DateVuelta.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Fecha Fuera Servicio";
            // 
            // DateFuera
            // 
            this.DateFuera.Checked = false;
            this.DateFuera.Location = new System.Drawing.Point(158, 38);
            this.DateFuera.Name = "DateFuera";
            this.DateFuera.Size = new System.Drawing.Size(193, 20);
            this.DateFuera.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Motivo";
            // 
            // TextMotivo
            // 
            this.TextMotivo.Location = new System.Drawing.Point(158, 91);
            this.TextMotivo.Name = "TextMotivo";
            this.TextMotivo.Size = new System.Drawing.Size(193, 20);
            this.TextMotivo.TabIndex = 49;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(55, 155);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 1;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(288, 155);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 2;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // BajaTemporal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 187);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "BajaTemporal";
            this.Text = "Baja por fuera de servicio";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TextMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DateVuelta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DateFuera;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button Limpiar;
    }
}