﻿using System;
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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class BajaTemporal : Form
    {
        AeronaveDTO Aeronave;
        bool Reemplazar;
        private BajaTemporalDTO bajaTemporal;

        public BajaTemporal(AeronaveDTO unaAeronave, bool reemplazar)
        {
            InitializeComponent();
            this.Aeronave = unaAeronave;
            this.Reemplazar = reemplazar;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (validar()) return;
            bajaTemporal.NroAeronave=Aeronave.Numero;
            bajaTemporal.FechaDesde=DateFuera.Value;
            bajaTemporal.FechaHasta=DateVuelta.Value;
            bajaTemporal.Motivo=TextMotivo.Text;
            if (Reemplazar)
            { 
                //NV SP que reemplaza aeronave
                if(1==1)
                {
                    
                }
                else
                {
                
                }
            }
            else
            {
                if(AeronaveDAO.BajaTempCancelar(bajaTemporal))
                {
                    MessageBox.Show("La aeronave quedo fuera de servicio exitosamente, los pasajes/encomiendas fueron cancelados");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo dar de baja la aeronave");
                }
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMotivo.Text = "";
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if (this.TextMotivo.Text == "")
            {
                errorProvider1.SetError(TextMotivo, "Debe ingresar un motivo");
                ret = true;
            }
            if (DateFuera.Value > DateVuelta.Value)
            {
                errorProvider1.SetError(DateFuera, "La fecha de fuera de servicio debe ser anterior a la de vuelta al servicio");
                errorProvider1.SetError(DateVuelta, "La fecha de fuera de servicio debe ser anterior a la de vuelta al servicio");
                ret = true;
            }
            if (DateFuera.Value < DateTime.Now)
            {
                errorProvider1.SetError(DateFuera, "La fecha de fuera de servicio debe ser a futuro");
                ret = true;
            }
            return ret;
        }

        
    }
}
