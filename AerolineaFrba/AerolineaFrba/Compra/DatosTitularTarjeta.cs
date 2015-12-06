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

namespace AerolineaFrba.Compra
{
    public partial class DatosTitularTarjeta : Form
    {
        private string Dni;
        private ClienteDTO cliente;

        public DatosTitularTarjeta(string unDNI)
        {
            InitializeComponent();
            this.Dni = unDNI;
        }

        private void DatosTitularTarjeta_Load(object sender, EventArgs e)
        {
            ClienteDTO uncliente = new ClienteDTO();
            uncliente.Dni =Convert.ToInt32( this.Dni);

            this.cliente = ClienteDAO.GetByDNI(uncliente);
            if (this.cliente != null)
            {
                this.textBoxNom.Text = this.cliente.Nombre;
                this.textBoxApe.Text = this.cliente.Apellido;
                this.textBoxDni.Text =this.cliente.Dni.ToString();
                this.textBoxMail.Text = this.cliente.Mail;
                this.textBoxDir.Text = this.cliente.Direccion;
                this.textBoxTel.Text = this.cliente.Telefono.ToString();
                this.dateTimePicker1.Value = this.cliente.Fecha_Nac;
            }
        }

        private bool validar()
        {
            //TERMINAR
            return true;
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                if (this.cliente == null)
                {
                    ClienteDTO unCliente = new ClienteDTO();

                    if (!ClienteDAO.Save(unCliente))
                    {
                        MessageBox.Show("No se pudo guardar los datos del titular");
                    }
                    else
                    {
                        MessageBox.Show("Se guardaron los datos del titular con exito");
                        this.Close();
                    }
                }
                else
                {
                    if (!ClienteDAO.Actualizar(this.cliente))
                    {
                        MessageBox.Show("No se pudieron actualizar los datos del titular");
                    }
                    else
                    {
                        MessageBox.Show("Se actualizaron los datos del titular con exito");
                        this.Close();
                    }
                }
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
