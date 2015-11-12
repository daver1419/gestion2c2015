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
    public partial class AltaAeronave : Form
    {
        private AeronaveDTO Aeronave;

        public AltaAeronave()
        {
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            Aeronave = new AeronaveDTO();
            ComboFabricante.DataSource = FabricanteDAO.selectAll();
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.DataSource = TipoServicioDAO.selectAll();
            ComboTipoServicio.SelectedIndex = -1;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMatricula.Text = "";
            TextModelo.Text = "";
            NumericKG.Value = 0;
            DateAlta.Value = DateTime.Now;
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.SelectedIndex = -1;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            Aeronave.Fabricante = ((FabricanteDTO)ComboFabricante.SelectedValue);
            Aeronave.TipoServicio = ((TipoServicioDTO)ComboTipoServicio.SelectedValue);
            Aeronave.FechaAlta = DateAlta.Value;
            Aeronave.KG = Decimal.ToInt32(NumericKG.Value);
            Aeronave.Matricula = TextMatricula.Text;
            Aeronave.Modelo = TextModelo.Text;

            AeronaveDAO.AltaAeronave(Aeronave);
        }

    }
}
