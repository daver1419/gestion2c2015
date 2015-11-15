using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class IndiceCiudad : Form
    {
        public IndiceCiudad()
        {
            InitializeComponent();
        }

        private void IndiceCiudad_Load(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            new AltaCiudad() { Icon = this.Icon }.ShowDialog(this);
        }

        private void btnModificacion_Click(object sender, EventArgs e)
        {
            new ModificacionListado() { Icon = this.Icon }.ShowDialog(this);
        }
    }
}
