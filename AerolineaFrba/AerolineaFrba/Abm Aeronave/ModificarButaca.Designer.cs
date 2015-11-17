namespace AerolineaFrba.Abm_Aeronave
{
    partial class ModificarButaca
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
            this.PisoNumeric = new System.Windows.Forms.NumericUpDown();
            this.NumeroNumeric = new System.Windows.Forms.NumericUpDown();
            this.TipoButacaCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.HabilitadaCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PisoNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HabilitadaCheck);
            this.groupBox1.Controls.Add(this.PisoNumeric);
            this.groupBox1.Controls.Add(this.NumeroNumeric);
            this.groupBox1.Controls.Add(this.TipoButacaCombo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Butaca";
            // 
            // PisoNumeric
            // 
            this.PisoNumeric.Location = new System.Drawing.Point(107, 69);
            this.PisoNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PisoNumeric.Name = "PisoNumeric";
            this.PisoNumeric.Size = new System.Drawing.Size(216, 20);
            this.PisoNumeric.TabIndex = 6;
            this.PisoNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumeroNumeric
            // 
            this.NumeroNumeric.Location = new System.Drawing.Point(107, 32);
            this.NumeroNumeric.Name = "NumeroNumeric";
            this.NumeroNumeric.Size = new System.Drawing.Size(216, 20);
            this.NumeroNumeric.TabIndex = 5;
            // 
            // TipoButacaCombo
            // 
            this.TipoButacaCombo.FormattingEnabled = true;
            this.TipoButacaCombo.Location = new System.Drawing.Point(107, 100);
            this.TipoButacaCombo.Name = "TipoButacaCombo";
            this.TipoButacaCombo.Size = new System.Drawing.Size(216, 21);
            this.TipoButacaCombo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de Butaca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Piso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(47, 191);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(75, 23);
            this.Limpiar.TabIndex = 14;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(260, 191);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(75, 23);
            this.Guardar.TabIndex = 15;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // HabilitadaCheck
            // 
            this.HabilitadaCheck.AutoSize = true;
            this.HabilitadaCheck.Location = new System.Drawing.Point(9, 129);
            this.HabilitadaCheck.Name = "HabilitadaCheck";
            this.HabilitadaCheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HabilitadaCheck.Size = new System.Drawing.Size(73, 17);
            this.HabilitadaCheck.TabIndex = 16;
            this.HabilitadaCheck.Text = "Habilitada";
            this.HabilitadaCheck.UseVisualStyleBackColor = true;
            // 
            // ModificarButaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 232);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarButaca";
            this.Text = "Modificar Butaca";
            this.Load += new System.EventHandler(this.ModificarButaca_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PisoNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumeroNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TipoButacaCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown PisoNumeric;
        private System.Windows.Forms.NumericUpDown NumeroNumeric;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox HabilitadaCheck;
    }
}