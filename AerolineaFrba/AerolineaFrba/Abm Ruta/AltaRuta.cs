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
using AerolineaFrba.DTO;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class AltaRuta : Form
    {
        private RutaDTO ruta;

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
            comboBoxTipoServ.SelectedIndex = -1;
            comboBoxCiudadOrigen.SelectedIndex = -1;
            comboBoxCiudadDest.SelectedIndex = -1;
        }

        private void grabarRuta(RutaDTO ruta)
        {
            if (!RutaDAO.Save(ruta))
            {
                MessageBox.Show("No se pudo crear la ruta");
            }
            else
            {
                MessageBox.Show("Ruta grabada con exito");
                this.Close();
            }
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if (textBoxCodigo.Text==String.Empty)
            {
                errorProvider1.SetError(textBoxCodigo, "Ingrese codigo de ruta");
                ret = true;
            }
            if (comboBoxTipoServ.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxTipoServ, "Ingrese servicio");
                ret = true;
            }
            if (comboBoxCiudadOrigen.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxCiudadOrigen, "Ingrese ciudad de origen");
                ret = true;
            }
            if (comboBoxCiudadDest.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxCiudadDest, "Ingrese ciudad de destino");
                ret = true;
            }
            return ret;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ruta.Codigo =Int32.Parse( textBoxCodigo.Text);
                ruta.CiudadOrigen =(CiudadDTO)comboBoxCiudadOrigen.SelectedItem;
                ruta.CiudadDestino = (CiudadDTO)comboBoxCiudadDest.SelectedItem;
                ruta.Servicio = (TipoServicioDTO)comboBoxTipoServ.SelectedItem;
                ruta.PrecioBaseKg = numericUpDownPBKg.Value;
                ruta.PrecioBasePasaje = numericUpDownPBPas.Value;

                if (!RutaDAO.ExistTuplaRuta(ruta))
                {
                    if(!RutaDAO.ExistCodigoRuta(ruta))
                    {
                        grabarRuta(ruta);
                    }
                    else
                    {
                        if (RutaDAO.CheckRutaConMismoCodigo(ruta))
                        {
                            grabarRuta(ruta);
                        }
                        else
                        {
                            MessageBox.Show("Ya existe al menos una ruta con el mismo codigo y las ciudadades ingresadas no permiten generar un tramo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe una ruta con la misma ciudad de origen, destino y servicio");
                }
            }
        }
    }
}
