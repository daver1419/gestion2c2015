using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.DTO;
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Compra
{
    public partial class IngresoDni : Form
    {

        public IngresoDni()
        {
            InitializeComponent();
        }

        private bool validar()
        {
            bool ret = true;
            if (this.textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Por favor ingrese el DNI");
                ret = false;
            }
            if (!Utility.esDNI(this.textBox1))
            {
                errorProvider1.SetError(textBox1, "Ingrese correctamente el DNI");
                ret = false;
            }
            return ret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                IngresoDatos ventana = new IngresoDatos(textBox1.Text);
            }
        }
    }
}
