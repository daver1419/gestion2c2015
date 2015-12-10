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
            comboBoxCiudadOrigen.DataSource = CiudadDAO.SelectAll();
            comboBoxCiudadDest.DataSource = CiudadDAO.SelectAll();
            comboBoxTipoServ.DataSource = TipoServicioDAO.selectAll();
            comboBoxCiudadOrigen.SelectedItem = ruta.CiudadOrigen;
            comboBoxCiudadDest.SelectedItem = ruta.CiudadDestino;
            comboBoxTipoServ.SelectedItem = ruta.Servicio;
            textBoxPBKg.Text = ruta.PrecioBaseKg.ToString();
            textBoxPBPas.Text = ruta.PrecioBasePasaje.ToString();
            checkBoxAct.Checked = ruta.Habilitado;

            textBoxCodigo.Enabled = false;
            comboBoxCiudadOrigen.Enabled = false;
            comboBoxCiudadDest.Enabled = false;
            comboBoxTipoServ.Enabled = false;
            textBoxPBKg.Enabled = false;
            textBoxPBPas.Enabled = false;
            checkBoxAct.Enabled = false;

            comboBoxServMod.DataSource = TipoServicioDAO.selectAll();
            comboBoxCiudOrigMod.DataSource = CiudadDAO.SelectAll();
            comboBoxDestMod.DataSource = CiudadDAO.SelectAll();
            comboBoxServMod.SelectedIndex = -1;
            comboBoxCiudOrigMod.SelectedIndex = -1;
            comboBoxDestMod.SelectedIndex = -1;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodMod.Text = "";
            comboBoxCiudOrigMod.SelectedIndex = -1;
            comboBoxDestMod.SelectedIndex = -1;
            comboBoxServMod.SelectedIndex = -1;
            numericUpDownPBKgMod.Value = 0;
            numericUpDownPBPasMod.Value = 0;
        }

        private bool validarCampos()
        {
            bool retValue = true;
            if(string.IsNullOrEmpty( textBoxCodMod.Text))
            {
                retValue = false;
                errorProvider1.SetError(textBoxCodMod,"Por favor ingrese un codigo");
            }
            if (comboBoxServMod.SelectedIndex == -1)
            {
                retValue = false;
                errorProvider1.SetError(comboBoxServMod,"Por favor seleccionar un tipo de servicio");
            }
            if (comboBoxCiudOrigMod.SelectedIndex == -1)
            {
                retValue = false;
                errorProvider1.SetError(comboBoxCiudOrigMod,"Por favor seleccionar una ciudad de origen");
            }
            if (comboBoxDestMod.SelectedIndex == -1)
            {
                retValue = false;
                errorProvider1.SetError(comboBoxDestMod,"Por favor seleccionar una ciudad de destino");
            }
            if (numericUpDownPBKgMod.Value == 0)
            {
                retValue = false;
                errorProvider1.SetError(numericUpDownPBKgMod,"El precio base por Kg no puede ser 0");
            }
            if (numericUpDownPBPasMod.Value == 0)
            {
                retValue = false;
                errorProvider1.SetError(numericUpDownPBPasMod,"El precio base por pasaje no puede ser 0");
            }

            return retValue;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                ruta.Codigo = Int32.Parse(textBoxCodMod.Text);
                ruta.CiudadOrigen = (CiudadDTO)comboBoxCiudOrigMod.SelectedItem;
                ruta.CiudadDestino = (CiudadDTO)comboBoxDestMod.SelectedItem;
                ruta.Servicio = (TipoServicioDTO)comboBoxServMod.SelectedItem;
                ruta.PrecioBaseKg = numericUpDownPBKgMod.Value;
                ruta.PrecioBasePasaje = numericUpDownPBPasMod.Value;

                if (!RutaDAO.ExistTuplaRuta(ruta))
                {
                    if (!RutaDAO.ExistRutaEnAlgunViaje(ruta))
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
                        MessageBox.Show("No se puede modificar la ruta. Esta asociada al menos a un viaje");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe una ruta con la misma ciudad de origen,destino y servicio");
                }
            }
        }
    }
}
