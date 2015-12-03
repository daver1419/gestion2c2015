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
using System.Text.RegularExpressions;
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ModificarAeronave : Form
    {
        private AeronaveDTO Aeronave;
        private List<ButacaDTO> butacasNuevas = new List<ButacaDTO>();
        private List<ButacaDTO> butacasModificadas = new List<ButacaDTO>();

        public ModificarAeronave(AeronaveDTO unaAeronave)
        {
            InitializeComponent();
            this.Aeronave = unaAeronave;
        }

        private void ModificarAeronave_Load(object sender, EventArgs e)
        {
            ComboFabricante.DataSource = FabricanteDAO.selectAll();
            ComboFabricante.SelectedItem = Aeronave.Fabricante;
            ComboTipoServicio.DataSource = TipoServicioDAO.selectAll();
            ComboTipoServicio.SelectedItem = Aeronave.TipoServicio;
            ModeloCombo.DataSource = ModeloDAO.selectAll();
            ModeloCombo.SelectedItem = Aeronave.Modelo;
            TextMatricula.Text = Aeronave.Matricula;
            NumericKG.Value = Aeronave.KG;
            Aeronave.ListaButacas = ButacaDAO.GetByAeronave(Aeronave);

            if (Aeronave.FechaAlta != null)
            {
                if (Aeronave.FechaAlta != DateTime.MinValue)
                    DateAlta.Value = Convert.ToDateTime(Aeronave.FechaAlta);
                else
                    DateAlta.Value = DateTime.Today;
            }
            else
                DateAlta.Value = DateTime.Today;

            ButacaNumeric.Value = Aeronave.ListaButacas.Count;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMatricula.Text = Aeronave.Matricula;
            NumericKG.Value = Aeronave.KG;
            
            if (Aeronave.FechaAlta != null)
            {
                if (Aeronave.FechaAlta != DateTime.MinValue)
                    DateAlta.Value = Convert.ToDateTime(Aeronave.FechaAlta);
                else
                    DateAlta.Value = DateTime.Today;
            }
            else
                DateAlta.Value = DateTime.Today;

            ModeloCombo.SelectedItem = Aeronave.Modelo;
            ComboFabricante.SelectedItem = Aeronave.Fabricante;
            ComboTipoServicio.SelectedItem = Aeronave.TipoServicio;
            Aeronave.ListaButacas = ButacaDAO.GetByAeronave(Aeronave);
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
            Aeronave.Modelo = ((ModeloDTO)ModeloCombo.SelectedValue);

            if (AeronaveDAO.ModificacionAeronave(Aeronave, butacasNuevas, butacasModificadas))
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
            ListadoButacas vent = new ListadoButacas(Aeronave);
            vent.ShowDialog(this);
        }

        // estaba pensando en algo así para manejar las butacas que vamos a agregar eliminar o modificar.
        public void Modificar_Butaca(ButacaDTO unaButaca)
        {
            butacasModificadas.Add(unaButaca);
            errorProvider1.Clear();
        }

        public void Agregar_Butaca(ButacaDTO unaButaca)
        {
            butacasNuevas.Add(unaButaca);
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
            if (this.ComboFabricante.SelectedIndex == -1)
            {
                errorProvider1.SetError(ComboFabricante, "Debe seleccionar un fabricante.");
                ret = true;
            }
            if (this.ModeloCombo.SelectedIndex == -1)
            {
                errorProvider1.SetError(ModeloCombo, "Debe seleccionar un modelo");
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
            return ret;
        }

        public void ReloadButacas()
        {
            ButacaNumeric.Value = Aeronave.ListaButacas.Count;
        }

        private void ModificarAeronave_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ListadoAeronaves)this.Owner).Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarButaca vent = new AgregarButaca(false);
            vent.ShowDialog(this);
        }


    }
}
