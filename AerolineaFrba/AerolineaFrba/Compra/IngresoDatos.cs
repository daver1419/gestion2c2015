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
    public partial class IngresoDatos : Form
    {
        private string DNI;

        public IngresoDatos(string unDNI)
        {
            InitializeComponent();
            this.DNI= unDNI;
        }

        private void IngresoDatos_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty( this.DNI))
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Dni =Convert.ToInt32( this.DNI);
                cliente = ClienteDAO.GetByDNI(cliente);

                textBoxNom.Text = cliente.Nombre;
                textBoxApe.Text = cliente.Apellido;
                textBoxDni.Text = cliente.Dni.ToString();
                textBoxDir.Text = cliente.Direccion;
                textBoxTel.Text = cliente.Telefono.ToString();
                textBoxMail.Text = cliente.Mail;
                dateTimePicker1.Value = cliente.Fecha_Nac;
            }
        }

        private bool validar()
        { 
            //AGREGAR VALIDACIONES
            return true;
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

                if (!ClienteDAO.Save(cliente))
                {
                    MessageBox.Show("No se pudo guardar el cliente");
                }
                else
                {
                    MessageBox.Show("Se guardo el cliente con exito");
                }

                SeleccionButaca ventana = new SeleccionButaca();
                ventana.ShowDialog(this);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
