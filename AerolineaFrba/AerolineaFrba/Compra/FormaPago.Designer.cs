namespace AerolineaFrba.Compra
{
    partial class FormaPago
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxNro = new System.Windows.Forms.TextBox();
            this.textBoxCodSeg = new System.Windows.Forms.TextBox();
            this.textBoxFechVenc = new System.Windows.Forms.TextBox();
            this.comboBoxTipoTarj = new System.Windows.Forms.ComboBox();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAtras = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMedioPago = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI titular tarjeta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero de tarjeta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Codigo de seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo de tarjeta";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Enabled = false;
            this.textBoxDNI.Location = new System.Drawing.Point(188, 30);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(100, 20);
            this.textBoxDNI.TabIndex = 5;
            this.textBoxDNI.Leave += new System.EventHandler(this.textBoxDNI_Leave);
            // 
            // textBoxNro
            // 
            this.textBoxNro.Location = new System.Drawing.Point(188, 66);
            this.textBoxNro.Name = "textBoxNro";
            this.textBoxNro.Size = new System.Drawing.Size(100, 20);
            this.textBoxNro.TabIndex = 6;
            // 
            // textBoxCodSeg
            // 
            this.textBoxCodSeg.Location = new System.Drawing.Point(188, 99);
            this.textBoxCodSeg.Name = "textBoxCodSeg";
            this.textBoxCodSeg.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodSeg.TabIndex = 7;
            // 
            // textBoxFechVenc
            // 
            this.textBoxFechVenc.Location = new System.Drawing.Point(188, 131);
            this.textBoxFechVenc.Name = "textBoxFechVenc";
            this.textBoxFechVenc.Size = new System.Drawing.Size(100, 20);
            this.textBoxFechVenc.TabIndex = 8;
            // 
            // comboBoxTipoTarj
            // 
            this.comboBoxTipoTarj.FormattingEnabled = true;
            this.comboBoxTipoTarj.Location = new System.Drawing.Point(188, 190);
            this.comboBoxTipoTarj.Name = "comboBoxTipoTarj";
            this.comboBoxTipoTarj.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoTarj.TabIndex = 9;
            this.comboBoxTipoTarj.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoTarj_SelectedIndexChanged);
            // 
            // buttonComprar
            // 
            this.buttonComprar.Location = new System.Drawing.Point(515, 356);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(75, 23);
            this.buttonComprar.TabIndex = 10;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "FORMATO: MMAA";
            // 
            // buttonAtras
            // 
            this.buttonAtras.Location = new System.Drawing.Point(42, 356);
            this.buttonAtras.Name = "buttonAtras";
            this.buttonAtras.Size = new System.Drawing.Size(75, 23);
            this.buttonAtras.TabIndex = 12;
            this.buttonAtras.Text = "Atras";
            this.buttonAtras.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Numero de cuotas:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(38, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(31, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(329, 27);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 15;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(38, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(31, 17);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "6";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(38, 63);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(37, 17);
            this.radioButton3.TabIndex = 17;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "12";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(38, 86);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(37, 17);
            this.radioButton4.TabIndex = 18;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "18";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Location = new System.Drawing.Point(188, 233);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 126);
            this.panel1.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Medio de pago";
            // 
            // comboBoxMedioPago
            // 
            this.comboBoxMedioPago.FormattingEnabled = true;
            this.comboBoxMedioPago.Location = new System.Drawing.Point(188, 160);
            this.comboBoxMedioPago.Name = "comboBoxMedioPago";
            this.comboBoxMedioPago.Size = new System.Drawing.Size(100, 21);
            this.comboBoxMedioPago.TabIndex = 21;
            this.comboBoxMedioPago.SelectedIndexChanged += new System.EventHandler(this.comboBoxMedioPago_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 391);
            this.Controls.Add(this.comboBoxMedioPago);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonAtras);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.comboBoxTipoTarj);
            this.Controls.Add(this.textBoxFechVenc);
            this.Controls.Add(this.textBoxCodSeg);
            this.Controls.Add(this.textBoxNro);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormaPago";
            this.Text = "Forma de pago";
            this.Load += new System.EventHandler(this.FormaPago_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxNro;
        private System.Windows.Forms.TextBox textBoxCodSeg;
        private System.Windows.Forms.TextBox textBoxFechVenc;
        private System.Windows.Forms.ComboBox comboBoxTipoTarj;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAtras;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxMedioPago;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}