using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.DAO;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class AltaRuta : Form
    {
        public AltaRuta()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodigo.Text = "";
            comboBoxTipoServ.SelectedIndex = -1;
            comboBoxCiudadOrigen.SelectedIndex = -1;
            comboBoxCiudadDest.SelectedIndex = -1;
        }

        private void AltaRuta_Load(object sender, EventArgs e)
        {
            comboBoxTipoServ.DataSource = TipoServicioDAO.selectAll();
            comboBoxCiudadOrigen.DataSource = CiudadDAO.SelectAll();
            comboBoxCiudadDest.DataSource = CiudadDAO.SelectAll();
        }
    }
}
