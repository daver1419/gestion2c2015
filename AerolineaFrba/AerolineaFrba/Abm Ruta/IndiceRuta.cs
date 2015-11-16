using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class IndiceRuta : Form
    {
        public IndiceRuta()
        {
            InitializeComponent();
        }

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            new AltaRuta() { Icon = this.Icon }.ShowDialog(this);
        }

        private void btnModRuta_Click(object sender, EventArgs e)
        {
            new ListadoRuta() { Icon = this.Icon }.ShowDialog(this);
        }

        private void btnEliminarRuta_Click(object sender, EventArgs e)
        {
            new BajaRuta() { Icon = this.Icon }.ShowDialog(this);
        }
    }
}
