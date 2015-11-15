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
            Aeronave = new AeronaveDTO();
            ComboFabricante.DataSource = FabricanteDAO.selectAll();
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.DataSource = TipoServicioDAO.selectAll();
            ComboTipoServicio.SelectedIndex = -1;
            TextMatricula.Text = Aeronave.Matricula;
            TextModelo.Text = Aeronave.Modelo;
            NumericKG.Value = Aeronave.KG;
            DateAlta.Value = Aeronave.FechaAlta;
            ButacaNumeric.Value = Aeronave.ListaButacas.Count;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMatricula.Text = Aeronave.Matricula;
            TextModelo.Text = Aeronave.Modelo;
            NumericKG.Value = Aeronave.KG;
            DateAlta.Value = Aeronave.FechaAlta;
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
            Aeronave.Modelo = TextModelo.Text;

            if (AeronaveDAO.AltaAeronave(Aeronave)) //Cambiar por modificar aeronave
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
            ListadoButacas vent = new ListadoButacas();
            vent.ShowDialog(this);
        }

        // estaba pensando en algo así para manejar las butacas que vamos a agregar eliminar o modificar.
        public void Cambiar_Butaca(ButacaDTO unaButaca)
        {
            if (Tiene_Butaca(unaButaca))
            {
                butacasModificadas.Add(unaButaca);

            }
            else
            {
                butacasNuevas.Add(unaButaca);
                Aeronave.ListaButacas.Add(unaButaca);
            }

            ButacaNumeric.Value = Aeronave.ListaButacas.Count;
            errorProvider1.Clear();
        }

        public void Eliminar_Butaca(ButacaDTO unaButaca)
        {
            if (Tiene_Butaca(unaButaca))
            {
                butacasModificadas.Add(unaButaca);

            }
            else
            {
                butacasNuevas.Add(unaButaca);
            }

            ButacaNumeric.Value = Aeronave.ListaButacas.Count + butacasNuevas.Count;
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
            if (DateAlta.Value < DateTime.Now)
            {
                errorProvider1.SetError(DateAlta, "La fecha debe ser posterior al momento de ser ingresada.");
                ret = true;
            }
            if (this.ComboFabricante.SelectedIndex == -1)
            {
                errorProvider1.SetError(ComboFabricante, "Debe seleccionar un fabricante.");
                ret = true;
            }
            if (this.TextModelo.Text == "")
            {
                errorProvider1.SetError(TextModelo, "Debe ingresar un modelo");
                ret = true;
            }
            if (this.TextMatricula.Text == "" || !buenFormatoMatricula(this.TextMatricula))
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

        private static bool buenFormatoMatricula(Control mitextbox)
        {
            Regex regex = new Regex(@"[a-zA-Z]{3}[\-]{1}[0-9]{3}$");
            return regex.IsMatch(mitextbox.Text);
        }


    }
}
