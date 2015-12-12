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
        private List<Tuple<ClienteDTO, ButacaDTO>> listaPasajeroButacas;
        private ClienteDTO clienteAcargoDeEncomienda;
        private int idViaje;
        private int KgsDeEncomienda;
        private decimal monto;
        private CompraDTO compra;

        public FormaPago(Int32 IdViaje,List<Tuple<ClienteDTO,ButacaDTO>> ListaTuplaPasajes,ClienteDTO clienteConEncomienda,Int32 KgEncomienda )
        {
            InitializeComponent();
            this.listaPasajeroButacas = ListaTuplaPasajes;
            this.clienteAcargoDeEncomienda = clienteConEncomienda;
            this.idViaje=IdViaje;
            this.KgsDeEncomienda = KgEncomienda;
        }

        private void textBoxDNI_Leave(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            DatosTitularTarjeta ventana = new DatosTitularTarjeta();
            ventana.ShowDialog(this);
        }

        private void FormaPago_Load(object sender, EventArgs e)
        {
            comboBoxTipoTarj.DataSource = TipoTarjetaDAO.GetAll();
            comboBoxMedioPago.DataSource = TipoPagoDAO.GetAll();

            if (Sesion.Rol.NombreRol == "Guest")
            {
                comboBoxMedioPago.SelectedItem = TipoPagoDAO.GetAll().ElementAt(0);
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
            bool retValue = true;
            ClienteDTO cliente=new ClienteDTO();
            cliente.Dni=Convert.ToInt32( textBoxDNI.Text);
            CompraDTO compra = new CompraDTO();
            compra.Comprador = ClienteDAO.GetByDNI(cliente);
            compra.MedioPago = (TipoPagoDTO)comboBoxMedioPago.SelectedItem;
            TarjetaCreditoDTO tarjeta = new TarjetaCreditoDTO();
            tarjeta.Numero =Convert.ToInt32( textBoxNro.Text);
            tarjeta.Codigo = Convert.ToInt32(textBoxCodSeg.Text);
            tarjeta.FechaVencimiento = Convert.ToInt32(textBoxFechVenc.Text);
            tarjeta.TipoTarjeta = (TipoTarjetaDTO)comboBoxTipoTarj.SelectedItem;
            compra.TarjetaCredito = tarjeta;
            ViajeDTO viaje = new ViajeDTO();
            viaje.Id = this.idViaje;
            compra.Viaje = viaje;
            compra.IdCompra = 0;
            compra.PNR = "0";

            TarjetaDAO.Save(tarjeta);
            this.compra =CompraDAO.Save(compra);

            if (string.IsNullOrEmpty( this.compra.PNR))
            {
                MessageBox.Show("No se pudo realizar la compra");
                retValue = false;
            }
            this.monto = 0;

            if (this.listaPasajeroButacas != null)
            {
                foreach (Tuple<ClienteDTO, ButacaDTO> tupla in this.listaPasajeroButacas)
                {
                    PasajeDTO pasaje = new PasajeDTO();
                    pasaje.Pasajero = tupla.Item1;
                    pasaje.Compra = this.compra;
                    pasaje.Butaca = tupla.Item2;
                    pasaje.Precio = 0;

                    this.monto = PasajeDAO.Save(pasaje).Precio + this.monto;
                }
            }
            if (this.clienteAcargoDeEncomienda != null)
            {
                EncomiendaDTO encomienda = new EncomiendaDTO();
                encomienda.Cliente = this.clienteAcargoDeEncomienda;
                encomienda.Compra = this.compra;
                encomienda.Precio = 0;
                encomienda.Kg = this.KgsDeEncomienda;

                this.monto = EncomiendaDAO.Save(encomienda).Precio + this.monto;
            }
            this.DialogResult = DialogResult.OK;
            return retValue;
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
            if (this.textBoxFechVenc.Text == "")
            {
                errorProvider1.SetError(this.textBoxFechVenc, "Ingrese mes y año de la fecha de nacimiento");
                retValue = false;
            }
            if (this.comboBoxMedioPago.SelectedItem == null)
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
                    if (!FinalizarTransaccion())
                    {
                        MessageBox.Show("Se ha producido un error. La transaccion no pudo ser finalizada");
                    }
                    else
                    {
                        MessageBox.Show(String.Format("La transaccion de la compra ha finalizado con exito. Monto a abonar: {0:f2}. PNR: {1}", this.monto, this.compra.PNR));
                        this.Close();
                    }
                }
            }

        private void buttonAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
