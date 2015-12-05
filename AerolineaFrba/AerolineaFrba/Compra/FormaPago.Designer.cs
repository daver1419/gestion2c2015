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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxNro = new System.Windows.Forms.TextBox();
            this.textBoxCodSeg = new System.Windows.Forms.TextBox();
            this.textBoxFechNac = new System.Windows.Forms.TextBox();
            this.comboBoxTipoTarj = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
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
            this.label5.Location = new System.Drawing.Point(39, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo de tarjeta";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(188, 30);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(100, 20);
            this.textBoxDNI.TabIndex = 5;
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
            // textBoxFechNac
            // 
            this.textBoxFechNac.Location = new System.Drawing.Point(188, 131);
            this.textBoxFechNac.Name = "textBoxFechNac";
            this.textBoxFechNac.Size = new System.Drawing.Size(100, 20);
            this.textBoxFechNac.TabIndex = 8;
            // 
            // comboBoxTipoTarj
            // 
            this.comboBoxTipoTarj.FormattingEnabled = true;
            this.comboBoxTipoTarj.Location = new System.Drawing.Point(188, 162);
            this.comboBoxTipoTarj.Name = "comboBoxTipoTarj";
            this.comboBoxTipoTarj.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoTarj.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Comprar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxTipoTarj);
            this.Controls.Add(this.textBoxFechNac);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxNro;
        private System.Windows.Forms.TextBox textBoxCodSeg;
        private System.Windows.Forms.TextBox textBoxFechNac;
        private System.Windows.Forms.ComboBox comboBoxTipoTarj;
        private System.Windows.Forms.Button button1;
    }
}