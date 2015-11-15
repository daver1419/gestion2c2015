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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class AltaCiudad : Form
    {
        private CiudadDTO ciudad;

        public AltaCiudad()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxDescr.Text = "";
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (textBoxDescr.Text=="")
            {
                errorProvider1.SetError(textBoxDescr, "Ingrese una descripcion");
                ret = false;
            }
            return ret;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ciudad.Descripcion = textBoxDescr.Text;
                if (!CiudadDAO.Exist(ciudad))
                {
                    if (!CiudadDAO.CrearCiudad(ciudad))
                    {
                        MessageBox.Show("Error al guardar los datos");
                    }
                    else
                    {
                        MessageBox.Show("Se dio de alta la ciudad exitosamente");
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe una ciudad con esta descripcion");
                }
            }
        }

        private void AltaCiudad_Load(object sender, EventArgs e)
        {
            ciudad = new CiudadDTO();
        }
    }
}
