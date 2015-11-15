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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class Modificacion : Form
    {
        private CiudadDTO ciudad;

        public Modificacion(CiudadDTO unaCiudad)
        {
            InitializeComponent();
            this.ciudad = unaCiudad;
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            textBoxDescrAct.Text = this.ciudad.Descripcion;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textBoxDescrAct.Text = "";
            textBoxDescrMod.Text = "";
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (textBoxDescrMod.Text == "")
            {
                errorProvider1.SetError(textBoxDescrMod, "Ingrese la nueva descripcion");
                ret = false;
            }
            return ret;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                this.ciudad.Descripcion = textBoxDescrMod.Text;

                if (!CiudadDAO.Actualizar(ciudad))
                {
                    MessageBox.Show("No se pudo modificar la ciudad");
                }
                else
                {
                    MessageBox.Show("Ciudad modificada exitosamente");
                }
            }
        }
    }
}
