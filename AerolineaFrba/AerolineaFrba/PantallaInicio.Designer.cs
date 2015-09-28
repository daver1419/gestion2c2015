namespace AerolineaFrba
{
    partial class PantallaInicio
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
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelIniciarSesion = new System.Windows.Forms.Label();
            this.listBoxFunc = new System.Windows.Forms.ListBox();
            this.panelUsuario.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUsuario
            // 
            this.panelUsuario.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelUsuario.Controls.Add(this.comboBoxRoles);
            this.panelUsuario.Controls.Add(this.label1);
            this.panelUsuario.Controls.Add(this.label2);
            this.panelUsuario.Location = new System.Drawing.Point(2, 55);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(200, 278);
            this.panelUsuario.TabIndex = 0;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(24, 48);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoles.TabIndex = 2;
            this.comboBoxRoles.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoles_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione un rol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(10, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "[Cerrar sesion]";
            this.label2.Click += new System.EventHandler(this.EndSession_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.labelIniciarSesion);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 57);
            this.panel2.TabIndex = 1;
            // 
            // labelIniciarSesion
            // 
            this.labelIniciarSesion.AutoSize = true;
            this.labelIniciarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelIniciarSesion.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIniciarSesion.ForeColor = System.Drawing.SystemColors.Window;
            this.labelIniciarSesion.Location = new System.Drawing.Point(20, 17);
            this.labelIniciarSesion.Name = "labelIniciarSesion";
            this.labelIniciarSesion.Size = new System.Drawing.Size(153, 22);
            this.labelIniciarSesion.TabIndex = 2;
            this.labelIniciarSesion.Text = "INICIO SESION";
            this.labelIniciarSesion.Click += new System.EventHandler(this.OpenSession_Click);
            // 
            // listBoxFunc
            // 
            this.listBoxFunc.FormattingEnabled = true;
            this.listBoxFunc.Location = new System.Drawing.Point(199, 55);
            this.listBoxFunc.Name = "listBoxFunc";
            this.listBoxFunc.Size = new System.Drawing.Size(489, 277);
            this.listBoxFunc.TabIndex = 2;
            this.listBoxFunc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxFunc_KeyDown);
            // 
            // PantallaInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 334);
            this.Controls.Add(this.listBoxFunc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelUsuario);
            this.Name = "PantallaInicio";
            this.Text = "PantallaInicio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PantallaInicio_Closed);
            this.Load += new System.EventHandler(this.PantallaInicio_Load);
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelIniciarSesion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxFunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRoles;
    }
}