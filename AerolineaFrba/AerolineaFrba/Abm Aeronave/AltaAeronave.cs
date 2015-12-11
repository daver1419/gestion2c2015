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
using AerolineaFrba.Helpers;

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
            ComboModelo.DataSource = ModeloDAO.selectAll();
            ComboModelo.SelectedIndex = -1;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMatricula.Text = "";
            ComboModelo.SelectedIndex = -1;
            NumericKG.Value = 0;
            DateAlta.Value = DateTime.Now;
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.SelectedIndex = -1;
            Aeronave.ListaButacas.Clear();
            ButacaNumeric.Value = Aeronave.ListaButacas.Count;
            errorProvider1.Clear();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {

            if (validar()) return;
            Aeronave.Fabricante = ((FabricanteDTO)ComboFabricante.SelectedValue);
            Aeronave.TipoServicio = ((TipoServicioDTO)ComboTipoServicio.SelectedValue);
            Aeronave.FechaAlta = DateAlta.Value;
            Aeronave.KG = Decimal.ToInt32(NumericKG.Value);
            Aeronave.Matricula = TextMatricula.Text;
            Aeronave.Modelo = ((ModeloDTO)ComboModelo.SelectedValue);

            if (AeronaveDAO.AltaAeronave(Aeronave))
            {
                MessageBox.Show("Los datos se guardaron con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar los datos. Se hará un rollback de la transacción.");
            }

            this.Close();
        }

        private void ButacaButton_Click(object sender, EventArgs e)
        {
            AgregarButaca vent = new AgregarButaca(true);
            vent.ShowDialog(this);
        }

        public void Agregar_Butaca(ButacaDTO unaButaca)
        {
            Aeronave.ListaButacas.Add(unaButaca);
            ButacaNumeric.Value = Aeronave.ListaButacas.Count;
            errorProvider1.Clear();
        }

        public bool Tiene_Butaca(ButacaDTO unaButaca)
        {
            return Aeronave.ListaButacas.Contains(unaButaca);
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            AeronaveDTO unaAero = new AeronaveDTO();
            unaAero.Matricula = TextMatricula.Text;
            if (DateAlta.Value < DateTime.Now)
            {
                errorProvider1.SetError(DateAlta, "La fecha debe ser posterior al momento de ser ingresada (al menos algunos minutos).");
                ret = true;
            }
            if (this.ComboFabricante.SelectedIndex == -1)
            {
                errorProvider1.SetError(ComboFabricante, "Debe seleccionar un fabricante.");
                ret = true;
            }
            if (this.ComboModelo.SelectedIndex == -1)
            {
                errorProvider1.SetError(ComboModelo, "Debe seleccionar un modelo");
                ret = true;
            }
            if (this.TextMatricula.Text == "" || !Utility.buenFormatoMatricula(this.TextMatricula))
            {
                errorProvider1.SetError(TextMatricula, "Debe ingresar una matricula en el formato XXX-000");
                ret = true;
            }
            if (this.ComboTipoServicio.SelectedIndex == -1)
            {
                errorProvider1.SetError(ComboTipoServicio, "Debe seleccionar un tipo de servicio.");
                ret = true;
            }
            if (this.ButacaNumeric.Value == 0)
            {
                errorProvider1.SetError(ButacaNumeric, "Debe ingresar butacas.");
                ret = true;
            }
            if (AeronaveDAO.GetByMatricula(unaAero).FirstOrDefault() != null)
            {
                errorProvider1.SetError(TextMatricula,"Matricula duplicada");
                ret = true;
            }
            return ret;
        }
    }
}
