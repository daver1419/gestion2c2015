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
        private bool clienteExistente;
        private AeronaveDTO aeronave;
        private bool compraEncomienda;

        public IngresoDatos(AeronaveDTO unaAeronave, bool esCompraEncomienda)
        {
            InitializeComponent();
            this.aeronave = unaAeronave;
            this.compraEncomienda = esCompraEncomienda;
        }

        private void IngresoDatos_Load(object sender, EventArgs e)
        {
            this.clienteExistente = false;
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
                    SeleccionButaca ventana = new SeleccionButaca(this.aeronave);
                    ventana.ShowDialog(this);
                }
                this.Close();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDni_Leave(object sender, EventArgs e)
        {
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
    }
}
