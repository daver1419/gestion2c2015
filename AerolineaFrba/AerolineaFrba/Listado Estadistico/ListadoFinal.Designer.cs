namespace AerolineaFrba.Listado_Estadistico
{
    partial class ListadoFinal
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
            this.gridListado = new System.Windows.Forms.DataGridView();
            this.txtListadoFinal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).BeginInit();
            this.SuspendLayout();
            // 
            // gridListado
            // 
            this.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListado.Location = new System.Drawing.Point(12, 57);
            this.gridListado.Name = "gridListado";
            this.gridListado.Size = new System.Drawing.Size(512, 271);
            this.gridListado.TabIndex = 0;
            // 
            // txtListadoFinal
            // 
            this.txtListadoFinal.Location = new System.Drawing.Point(94, 22);
            this.txtListadoFinal.Name = "txtListadoFinal";
            this.txtListadoFinal.Size = new System.Drawing.Size(346, 20);
            this.txtListadoFinal.TabIndex = 1;
            // 
            // ListadoFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 340);
            this.Controls.Add(this.txtListadoFinal);
            this.Controls.Add(this.gridListado);
            this.Name = "ListadoFinal";
            this.Text = "TOP 5";
            this.Load += new System.EventHandler(this.ListadoFinal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridListado;
        private System.Windows.Forms.TextBox txtListadoFinal;
    }
}