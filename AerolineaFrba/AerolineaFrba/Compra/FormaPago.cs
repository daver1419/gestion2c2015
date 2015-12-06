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
        }

        private void FormaPago_Load(object sender, EventArgs e)
        {
            comboBoxTipoTarj.DataSource = TipoTarjetaDAO.GetAll();
            comboBoxTipoTarj.SelectedIndex = -1;
            comboBoxMedioPago.DataSource = TipoPagoDAO.GetAll();
            comboBoxMedioPago.SelectedIndex = -1;

            panel1.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            radioButton4.Hide();
            label7.Hide();

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
                case 1: radioButton1.Show();
                    break;
                case 6: radioButton2.Show();
                    break;
                case 12: radioButton3.Show();
                    break;
                case 18: radioButton4.Show();
                    break;
            }
        }

        private void comboBoxMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMedioPago.SelectedItem.ToString() == "Tarjeta de credito")
            {
                panel1.Enabled=false;
                radioButton1.Enabled=false;
                radioButton2.Enabled=false;
                radioButton3.Enabled=false;
                radioButton4.Enabled=false;
                label7.Enabled = false;
            }
        }
    }
}
