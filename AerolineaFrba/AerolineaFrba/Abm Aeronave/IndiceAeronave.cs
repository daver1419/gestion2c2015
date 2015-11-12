using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class IndiceAeronave : Form
    {
        public IndiceAeronave()
        {
            InitializeComponent();
        }

        private void altaButton_Click(object sender, EventArgs e)
        {
            new AltaAeronave() { Icon = this.Icon }.ShowDialog(this);
        }
    }
}
