namespace AerolineaFrba.Abm_Ruta
{
    partial class AltaRuta
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
            this.comboBoxTipoServ = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCiudadDest = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPrecioBaseKg = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.textBoxPrecioBasePasaje = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de servicio";
            // 
            // comboBoxTipoServ
            // 
            this.comboBoxTipoServ.FormattingEnabled = true;
            this.comboBoxTipoServ.Location = new System.Drawing.Point(181, 44);
            this.comboBoxTipoServ.Name = "comboBoxTipoServ";
            this.comboBoxTipoServ.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoServ.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ciudad de origen";
            // 
            // comboBoxCiudadOrigen
            // 
            this.comboBoxCiudadOrigen.FormattingEnabled = true;
            this.comboBoxCiudadOrigen.Location = new System.Drawing.Point(181, 83);
            this.comboBoxCiudadOrigen.Name = "comboBoxCiudadOrigen";
            this.comboBoxCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCiudadOrigen.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ciudad de destino";
            // 
            // comboBoxCiudadDest
            // 
            this.comboBoxCiudadDest.FormattingEnabled = true;
            this.comboBoxCiudadDest.Location = new System.Drawing.Point(181, 121);
            this.comboBoxCiudadDest.Name = "comboBoxCiudadDest";
            this.comboBoxCiudadDest.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCiudadDest.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio base por Kg";
            // 
            // textBoxPrecioBaseKg
            // 
            this.textBoxPrecioBaseKg.Location = new System.Drawing.Point(181, 161);
            this.textBoxPrecioBaseKg.Name = "textBoxPrecioBaseKg";
            this.textBoxPrecioBaseKg.Size = new System.Drawing.Size(121, 20);
            this.textBoxPrecioBaseKg.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Precio base por pasaje";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(39, 262);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(259, 262);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // textBoxPrecioBasePasaje
            // 
            this.textBoxPrecioBasePasaje.Location = new System.Drawing.Point(181, 202);
            this.textBoxPrecioBasePasaje.Name = "textBoxPrecioBasePasaje";
            this.textBoxPrecioBasePasaje.Size = new System.Drawing.Size(121, 20);
            this.textBoxPrecioBasePasaje.TabIndex = 11;
            // 
            // AltaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 297);
            this.Controls.Add(this.textBoxPrecioBasePasaje);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPrecioBaseKg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxCiudadDest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxCiudadOrigen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTipoServ);
            this.Controls.Add(this.label1);
            this.Name = "AltaRuta";
            this.Text = "AltaRuta";
            this.Load += new System.EventHandler(this.AltaRuta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTipoServ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCiudadOrigen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCiudadDest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPrecioBaseKg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox textBoxPrecioBasePasaje;
    }
}