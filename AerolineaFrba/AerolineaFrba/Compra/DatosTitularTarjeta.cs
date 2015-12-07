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
            errorProvider1.Clear();
            bool ret = true;
            if (this.textBoxNom.Text=="")
            {
                errorProvider1.SetError(textBoxNom, "Ingrese un nombre.");
                ret = false;
            }
            if (this.textBoxApe.Text=="")
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
            if (this.textBoxTel.Text=="")
            {
                errorProvider1.SetError(this.textBoxTel, "Ingrese un telefono");
                ret = false;
            }
            return ret;
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
