using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.DAO;
using AerolineaFrba.DTO;
using System.Text.RegularExpressions;

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class RegistroLlegadaDestino : Form
    {
        public RegistroLlegadaDestino()
        {
            InitializeComponent();
        }

        private void RegistroLlegadaDestino_Load(object sender, EventArgs e)
        {
            comboBoxAeroOrigen.DataSource = CiudadDAO.SelectAll();
            comboBoxAeroDest.DataSource = CiudadDAO.SelectAll();
            comboBoxAeroOrigen.SelectedIndex = -1;
            comboBoxAeroDest.SelectedIndex = -1;
            labelInforme.Hide();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            textBoxMatricula.Text = "";
            comboBoxAeroDest.SelectedIndex = -1;
            comboBoxAeroOrigen.SelectedIndex = -1;
        }

        private static bool buenFormatoMatricula(Control mitextbox)
        {
            Regex regex = new Regex(@"[a-zA-Z]{3}[\-]{1}[0-9]{3}$");
            return regex.IsMatch(mitextbox.Text);
        }

        public bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;

            if (dateTimePicker1.Value < DateTime.Now)
            {
                errorProvider1.SetError(dateTimePicker1, "La fecha no puede ser anterior a la actual");
                ret = false;
            }

            if (this.textBoxMatricula.Text == "" || !buenFormatoMatricula(this.textBoxMatricula))
            {
                errorProvider1.SetError(textBoxMatricula, "Debe ingresar una matricula en el formato XXX-000");
                ret = false;
            }
            return ret;
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                AeronaveDTO aeronave = new AeronaveDTO();
                aeronave.Matricula = textBoxMatricula.Text;
                IList<AeronaveDTO> listaAeronaves=AeronaveDAO.GetByMatricula(aeronave);
                this.dataGridView1.DataSource = listaAeronaves;
                if (!AeronaveDAO.ArriboCorrectamente(listaAeronaves.FirstOrDefault(), (CiudadDTO)comboBoxAeroDest.SelectedItem))
                {
                    labelInforme.Show();
                    labelInforme.ForeColor = System.Drawing.Color.Red;
                    labelInforme.Text="La aeronave no llego al aeropuerto donde debia arribar correctamente";
                }
                else
                {
                    labelInforme.Show();
                    labelInforme.Text = "La aeronave llego al aeropuerto destino correctamente";
                }

            }
        }
    }
}
