namespace AerolineaFrba.Abm_Ruta
{
    partial class IndiceRuta
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
            this.btnCrearRuta = new System.Windows.Forms.Button();
            this.btnModRuta = new System.Windows.Forms.Button();
            this.btnEliminarRuta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearRuta
            // 
            this.btnCrearRuta.Location = new System.Drawing.Point(93, 41);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(122, 48);
            this.btnCrearRuta.TabIndex = 0;
            this.btnCrearRuta.Text = "Crear ruta";
            this.btnCrearRuta.UseVisualStyleBackColor = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // btnModRuta
            // 
            this.btnModRuta.Location = new System.Drawing.Point(93, 120);
            this.btnModRuta.Name = "btnModRuta";
            this.btnModRuta.Size = new System.Drawing.Size(122, 48);
            this.btnModRuta.TabIndex = 1;
            this.btnModRuta.Text = "Modificar ruta";
            this.btnModRuta.UseVisualStyleBackColor = true;
            this.btnModRuta.Click += new System.EventHandler(this.btnModRuta_Click);
            // 
            // btnEliminarRuta
            // 
            this.btnEliminarRuta.Location = new System.Drawing.Point(93, 202);
            this.btnEliminarRuta.Name = "btnEliminarRuta";
            this.btnEliminarRuta.Size = new System.Drawing.Size(122, 48);
            this.btnEliminarRuta.TabIndex = 2;
            this.btnEliminarRuta.Text = "Eliminar ruta";
            this.btnEliminarRuta.UseVisualStyleBackColor = true;
            this.btnEliminarRuta.Click += new System.EventHandler(this.btnEliminarRuta_Click);
            // 
            // IndiceRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 282);
            this.Controls.Add(this.btnEliminarRuta);
            this.Controls.Add(this.btnModRuta);
            this.Controls.Add(this.btnCrearRuta);
            this.Name = "IndiceRuta";
            this.Text = "ABM Ruta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearRuta;
        private System.Windows.Forms.Button btnModRuta;
        private System.Windows.Forms.Button btnEliminarRuta;
    }
}