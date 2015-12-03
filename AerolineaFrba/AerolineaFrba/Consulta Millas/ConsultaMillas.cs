using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillas : Form
    {
        public ConsultaMillas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar()) return;
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if ((!Utility.esDNI(this.textDNI) && !(this.textDNI.Text == "")) || (this.textDNI.Text == ""))
            {
                errorProvider1.SetError(this.textDNI, "Debe ingresar un DNI (no puede superar los 8 digitos).");
                ret = true;
            }
            return ret;
        }

    }
}
