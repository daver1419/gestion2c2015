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
using AerolineaFrba.DAO;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class ModificacionRuta : Form
    {
        private RutaDTO ruta;

        public ModificacionRuta(RutaDTO unaRuta)
        {
            InitializeComponent();
            this.ruta = unaRuta;
        }

        private void ModificacionRuta_Load(object sender, EventArgs e)
        {
            textBoxCodigo.Text = ruta.Codigo.ToString();
            comboBoxCiudadOrigen.SelectedItem = ruta.CiudadOrigen;
            comboBoxCiudadDest.SelectedItem = ruta.CiudadDestino;
            comboBoxTipoServ.SelectedItem = ruta.Servicio;
            numericUpDownPBKg.Value = ruta.PrecioBaseKg;
            numericUpDownPBPas.Value = ruta.PrecioBasePasaje;

            textBoxCodigo.Enabled = false;
            comboBoxCiudadOrigen.Enabled = false;
            comboBoxCiudadDest.Enabled = false;
            comboBoxTipoServ.Enabled = false;
            numericUpDownPBKg.Enabled = false;
            numericUpDownPBPas.Enabled = false;

            comboBoxTipoServ.DataSource = TipoServicioDAO.selectAll();
            comboBoxCiudadOrigen.DataSource = CiudadDAO.SelectAll();
            comboBoxCiudadDest.DataSource = CiudadDAO.SelectAll();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodMod.Text = "";
            comboBoxCiudOrigMod.SelectedItem = -1;
            comboBoxDestMod.SelectedItem = -1;
            comboBoxServMod.SelectedItem = -1;
            numericUpDownPBKgMod.Value = 0;
            numericUpDownPBPasMod.Value = 0;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            ruta.Codigo = Int32.Parse(textBoxCodMod.Text);
            ruta.CiudadOrigen = (CiudadDTO)comboBoxCiudOrigMod.SelectedItem;
            ruta.CiudadDestino = (CiudadDTO)comboBoxDestMod.SelectedItem;
            ruta.Servicio = (TipoServicioDTO)comboBoxServMod.SelectedItem;
            ruta.PrecioBaseKg = numericUpDownPBKgMod.Value;
            ruta.PrecioBasePasaje = numericUpDownPBPasMod.Value;

            if (!RutaDAO.ExistTuplaRuta(ruta))
            {
                if (!RutaDAO.Actualizar(ruta))
                {
                    MessageBox.Show("No se pudo actualizar la ruta");
                }
                else
                {
                    MessageBox.Show("La ruta se ha actualizado exitosamente");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ya existe una ruta con la misma ciudad de origen,destino y servicio");    
            }

        }
    }
}
