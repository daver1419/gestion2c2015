namespace AerolineaFrba.Abm_Aeronave
{
    partial class Indice
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
            this.AltaButton = new System.Windows.Forms.Button();
            this.ModificacionButton = new System.Windows.Forms.Button();
            this.BajaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AltaButton
            // 
            this.AltaButton.Location = new System.Drawing.Point(47, 47);
            this.AltaButton.Name = "AltaButton";
            this.AltaButton.Size = new System.Drawing.Size(188, 55);
            this.AltaButton.TabIndex = 0;
            this.AltaButton.Text = "Alta de aeronaves";
            this.AltaButton.UseVisualStyleBackColor = true;
            this.AltaButton.Click += new System.EventHandler(this.altaButton_Click);
            // 
            // ModificacionButton
            // 
            this.ModificacionButton.Location = new System.Drawing.Point(47, 108);
            this.ModificacionButton.Name = "ModificacionButton";
            this.ModificacionButton.Size = new System.Drawing.Size(188, 59);
            this.ModificacionButton.TabIndex = 1;
            this.ModificacionButton.Text = "Modificacion de aeronaves";
            this.ModificacionButton.UseVisualStyleBackColor = true;
            // 
            // BajaButton
            // 
            this.BajaButton.Location = new System.Drawing.Point(47, 173);
            this.BajaButton.Name = "BajaButton";
            this.BajaButton.Size = new System.Drawing.Size(188, 59);
            this.BajaButton.TabIndex = 2;
            this.BajaButton.Text = "Baja de aeronaves";
            this.BajaButton.UseVisualStyleBackColor = true;
            // 
            // Indice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.BajaButton);
            this.Controls.Add(this.ModificacionButton);
            this.Controls.Add(this.AltaButton);
            this.Name = "Indice";
            this.Text = "ABM Aeronaves";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AltaButton;
        private System.Windows.Forms.Button ModificacionButton;
        private System.Windows.Forms.Button BajaButton;
    }
}