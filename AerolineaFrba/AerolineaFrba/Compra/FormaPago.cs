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
using AerolineaFrba.Login;
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Compra
{
    public partial class FormaPago : Form
    {
        private ClienteDTO cliente;

        public FormaPago()
        {
            InitializeComponent();
        }

        private void textBoxDNI_Leave(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DatosTitularTarjeta ventana = new DatosTitularTarjeta(this.textBoxDNI.Text);
            ventana.ShowDialog(this);
        }

        private void FormaPago_Load(object sender, EventArgs e)
        {
            comboBoxTipoTarj.DataSource = TipoTarjetaDAO.GetAll();
            comboBoxMedioPago.DataSource = TipoPagoDAO.GetAll();

            if (Sesion.Rol.NombreRol == "Guest")
            {
                comboBoxMedioPago.SelectedText = "Tarjeta de credito";
                comboBoxMedioPago.Enabled = false;
            }
        }

        private void comboBoxTipoTarj_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((TipoTarjetaDTO)comboBoxTipoTarj.SelectedItem).NumeroCuotas)
            {
                case 1: radioButton1.Enabled = true;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    break;
                case 6: radioButton2.Enabled = true;
                    radioButton1.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    break;
                case 12: radioButton3.Enabled = true;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton4.Enabled = false;
                    break;
                case 18: radioButton4.Enabled = true;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    break;
            }
        }

        private void comboBoxMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TipoPagoDTO)comboBoxMedioPago.SelectedItem).Descripcion != "Tarjeta de credito")
            {
                panel1.Hide();
                radioButton1.Hide();
                radioButton2.Hide();
                radioButton3.Hide();
                radioButton4.Hide();
                label7.Hide();
            }
        }

        private bool FinalizarTransaccion()
        {
            return true;
        }

        private bool validarCampos()
        {
            bool retValue = true;

            if (this.textBoxDNI.Text == "")
            {
                errorProvider1.SetError(this.textBoxDNI,"Ingrese un DNI");
                retValue = false;
            }
            if (!Utility.esDNI(this.textBoxDNI))
            {
                errorProvider1.SetError(this.textBoxDNI,"Ingrese correctamente el DNI");
                retValue = false;
            }
            if (this.textBoxCodSeg.Text == "")
            {
                errorProvider1.SetError(this.textBoxCodSeg, "Ingrese el codigo de serguridad");
                retValue = false;
            }
            if (this.textBoxNro.Text == "")
            {
                errorProvider1.SetError(this.textBoxNro, "Ingrese el numero de la tarjeta");
                retValue = false;
            }
            if (this.textBoxFechNac.Text == "")
            {
                errorProvider1.SetError(this.textBoxFechNac, "Ingrese mes y año de la fecha de nacimiento");
                retValue = false;
            }
            if (this.comboBoxMedioPago.SelectedIndex == -1)
            {
                errorProvider1.SetError(this.comboBoxMedioPago, "Seleccione el medio de pago");
                retValue = false;
            }
            if (this.comboBoxTipoTarj.Text == "")
            {
                errorProvider1.SetError(this.comboBoxTipoTarj, "Seleccione el tipo de tarjeta");
                retValue = false;
            }
            if (this.comboBoxMedioPago.SelectedText == "Tarjeta de credito")
            {
                if (!(this.radioButton1.Checked ||
                    this.radioButton2.Checked ||
                    this.radioButton3.Checked ||
                    this.radioButton4.Checked))
                {
                    errorProvider1.SetError(this.comboBoxMedioPago,"Seleccione la cantidad un numero de cuotas");
                    retValue = false;
                }
            }

            return retValue;
        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            { 
                if(true)//VALIDAR PASAJEROS NO VIAJEN A MAS DE UNA DESTINO A LA VEZ
                {
                    if (!FinalizarTransaccion())
                    {
                        MessageBox.Show("Se ha producido un error. La transaccion no pudo ser finalizada");
                    }
                    else
                    {
                        MessageBox.Show("La compra fue realizada con exito");
                    }
                }
            }
        }
    }
}
