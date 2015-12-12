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
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Compra
{
    public partial class IngresoDatos : Form
    {
        public ButacaDTO butaca;
        private bool clienteExistente;
        private GridViajesDTO gridViaje;
        private bool compraEncomienda;

        public IngresoDatos(GridViajesDTO unGridViaje, bool esCompraEncomienda)
        {
            InitializeComponent();
            this.gridViaje = unGridViaje;
            this.compraEncomienda = esCompraEncomienda;
            if (this.compraEncomienda)
            {
                this.Text = "Ingreso de Datos para Encomienda";
            }
            else
            {
                this.Text = "Ingreso de Datos para Pasaje";
            }
        }

        private void IngresoDatos_Load(object sender, EventArgs e)
        {
            this.clienteExistente = false;
            ButacaDTO unaButaca = new ButacaDTO();
            this.butaca = unaButaca;
        }

        private bool validarPasajero()
        {
            ClienteDTO cliente = new ClienteDTO();
            cliente.Dni =Convert.ToInt32( textBoxDni.Text);
            cliente = ClienteDAO.GetByDNI(cliente);

             return ClienteDAO.ViajaAMasDeUnDestino(cliente, this.gridViaje.FechaSalida,this.gridViaje.FechaLlegadaEstimada);
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (!Utility.esDNI(this.textBoxDni))
            {
                errorProvider1.SetError(this.textBoxDni,"Ingresar correctamente");
                ret = false;
            }
            if (!Utility.esNumero(this.textBoxTel))
            {
                errorProvider1.SetError(textBoxTel,"Ingresar solo numeros");
                ret = false;
            }
            if (this.textBoxNom.Text == "")
            {
                errorProvider1.SetError(textBoxNom, "Ingrese un nombre.");
                ret = false;
            }
            if (this.textBoxApe.Text == "")
            {
                errorProvider1.SetError(textBoxApe, "Ingrese un apellido");
                ret = false;
            }
            if (this.textBoxDir.Text == "")
            {
                errorProvider1.SetError(this.textBoxDir, "Ingrese una direccion");
                ret = false;
            }
            if (this.textBoxDni.Text == "")
            {
                errorProvider1.SetError(this.textBoxDni, "Ingrese un DNI");
                ret = false;
            }
            if (this.textBoxTel.Text == "")
            {
                errorProvider1.SetError(this.textBoxTel, "Ingrese un telefono");
                ret = false;
            }
            if (this.clienteExistente)
            {
                if (!validarPasajero())
                {
                    ret = false;
                    MessageBox.Show("El pasajero ya compro un viaje entre las fechas ingresadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return ret;
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Nombre = textBoxNom.Text;
                cliente.Apellido = textBoxApe.Text;
                cliente.Direccion = textBoxDir.Text;
                cliente.Dni =Convert.ToInt32( textBoxDni.Text);
                cliente.Fecha_Nac = dateTimePicker1.Value;
                cliente.Mail = textBoxMail.Text;
                cliente.Telefono = Convert.ToInt32(textBoxTel.Text);

                if (this.clienteExistente)
                {
                    if (!ClienteDAO.Actualizar(cliente))
                    {
                        MessageBox.Show("No se pudo actualizar los datos del cliente");
                    }
                    else
                    {
                        MessageBox.Show("Datos del cliente actualizados con exito");
                    }
                }
                else
                {
                    if (!ClienteDAO.Save(cliente))
                    {
                        MessageBox.Show("No se pudo guardar el cliente");
                    }
                    else
                    {
                        MessageBox.Show("Se guardo el cliente con exito");
                    }
                }
                if (!this.compraEncomienda)
                {

                    SeleccionButaca ventana = new SeleccionButaca(this.gridViaje);
                    ventana.ShowDialog(this);
                    if(ventana.DialogResult == DialogResult.OK)
                    {
                        Tuple<ClienteDTO, ButacaDTO> tuple = new Tuple<ClienteDTO, ButacaDTO>(cliente, this.butaca);
                        ((CompraPasajeEncomienda)this.Owner).listaPasajerosButacas.Add(tuple);
                    }
                }
                else
                {
                    ((CompraPasajeEncomienda)this.Owner).clienteEncomienda = cliente;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxNom.Text = "";
            this.textBoxApe.Text = "";
            this.textBoxDir.Text = "";
            this.textBoxMail.Text = "";
            this.textBoxTel.Text = "";
            this.textBoxDni.Text = "";
            this.dateTimePicker1.Value = DateTime.Now;
        }

        private void textBoxDni_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDni.Text))
                return;
            ClienteDTO cliente = new ClienteDTO();
            cliente.Dni =Convert.ToInt32( textBoxDni.Text);
            cliente=ClienteDAO.GetByDNI(cliente);
            if (cliente != null)
            {
                textBoxNom.Text = cliente.Nombre;
                textBoxApe.Text = cliente.Apellido;
                textBoxDir.Text = cliente.Direccion;
                textBoxTel.Text = cliente.Telefono.ToString();
                textBoxMail.Text = cliente.Mail;
                dateTimePicker1.Value = cliente.Fecha_Nac;
                this.clienteExistente = true;
            }
        }

        private void textBoxTel_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
