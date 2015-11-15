using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class IndiceRol : Form
    {
        public IndiceRol()
        {
            InitializeComponent();
        }

        private void AltaButton_Click(object sender, EventArgs e)
        {
            new AltaRol() { Icon = this.Icon }.ShowDialog(this);
        }

        private void ModificacionButton_Click(object sender, EventArgs e)
        {
            new ListadoRoles() { Icon = this.Icon }.ShowDialog(this);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            new ListadoRoles() { Icon = this.Icon }.ShowDialog(this);
        }

        private void IndiceRol_Load(object sender, EventArgs e)
        {

        }
    }
}
