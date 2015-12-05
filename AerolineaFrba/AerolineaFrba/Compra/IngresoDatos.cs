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
        private ViajeDTO viaje;
        private string DNI;

        public IngresoDatos(ViajeDTO unViaje,string unDNI)
        {
            InitializeComponent();
            this.viaje = unViaje;
            this.DNI= unDNI;
        }

        private void IngresoDatos_Load(object sender, EventArgs e)
        {
            labelKgs.Enabled = false;
            numericUpDown1.Enabled = false;

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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
