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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class BajaVidaUtil : Form
    {
        private bool reemplazar;
        private AeronaveDTO aeronave;

        public BajaVidaUtil(bool reemplazo,AeronaveDTO unaAeronave)
        {
            InitializeComponent();
            this.reemplazar = reemplazo;
            this.aeronave = unaAeronave;
        }

        private void BajaVidaUtil_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private bool validarFecha()
        {
            bool retValue = true;
            if (dateTimePicker1.Value < DateTime.Now)
            {
                retValue = false;
                MessageBox.Show("La fecha de baja no puede ser anterior a la actual");
            }
            return retValue;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (validarFecha())
            {
                if (this.reemplazar)
                {
                    if (!AeronaveDAO.ReemplazarDefinitiva(this.aeronave,this.dateTimePicker1.Value))
                    {
                        MessageBox.Show("No se encontro una aeronave que pueda reemplazar los viajes programados. Debe dar de alta una nueva aeronave.");
                        AltaAeronave ventana = new AltaAeronave();
                        ventana.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("La aeronave se reemplazo por otra con exito reemplazando todos los viajes que tenia programados","Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }

                if (!AeronaveDAO.BajaDefCancelar(aeronave,this.dateTimePicker1.Value))
                {
                    MessageBox.Show("No se pudo dar de baja la aeronave", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("La aeronave se de baja por vida util con exito","Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
