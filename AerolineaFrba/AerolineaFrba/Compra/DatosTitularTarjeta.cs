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
        private bool clienteExistente;

        public DatosTitularTarjeta()
        {
            InitializeComponent();
        }

        private void DatosTitularTarjeta_Load(object sender, EventArgs e)
        {
            this.clienteExistente = false;
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
                ClienteDTO cliente = new ClienteDTO();
                cliente.Nombre = textBoxNom.Text;
                cliente.Apellido = textBoxApe.Text;
                cliente.Direccion = textBoxDir.Text;
                cliente.Dni =Convert.ToInt32( textBoxDni.Text);
                cliente.Fecha_Nac = dateTimePicker1.Value;
                cliente.Mail = textBoxMail.Text;
                cliente.Telefono = Convert.ToInt32(textBoxTel.Text);

                if(this.clienteExistente)
                {
                    if (!ClienteDAO.Actualizar(cliente))
                    {
                        MessageBox.Show("No se pudieron actualizar los datos del titular");
                    }
                    else
                    {
                        MessageBox.Show("Se actualizaron los datos del titular con exito");
                        this.Close();
                    }
                }
                else
                {
                    if (!ClienteDAO.Save(cliente))
                    {
                        MessageBox.Show("No se pudieron guardar los datos del titular");
                    }
                    else
                    {
                        MessageBox.Show("Se guardaron los datos del titular con exito");
                        this.Close();
                    }
                }
                ((FormaPago)this.Owner).textBoxDNI.Text = this.textBoxDni.Text;
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
            cliente.Dni = Convert.ToInt32(textBoxDni.Text);
            cliente = ClienteDAO.GetByDNI(cliente);
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
    }
}
