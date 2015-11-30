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

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class ListadoAeronaves : Form
    {
        AeronaveDTO aeronave;
        AeronaveFiltersDTO aeronaveFilters;
        GeneracionViaje FormPadre;

        public ListadoAeronaves(GeneracionViaje formPadre)
        {
            InitializeComponent();
            aeronave = new AeronaveDTO();
            aeronaveFilters = new AeronaveFiltersDTO();
            this.FormPadre = formPadre;
        }

        private static bool buenFormatoMatricula(Control mitextbox)
        {
            Regex regex = new Regex(@"[a-zA-Z]{3}[\-]{1}[0-9]{3}$");
            return regex.IsMatch(mitextbox.Text);
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if (!buenFormatoMatricula(this.TextMatricula) && !(this.TextMatricula.Text == ""))
            {
                errorProvider1.SetError(TextMatricula, "Debe ingresar una matricula en el formato XXX-000");
                ret = true;
            }
            if (DateAlta.Checked && DateAltaFin.Checked && DateAlta.Value > DateAltaFin.Value)
            {
                errorProvider1.SetError(DateAltaFin, "La fecha de fin debe ser posterior a la del comienzo");
                ret = true;
            }
            return ret;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (validar()) return;

            aeronave.Fabricante = ((FabricanteDTO)ComboFabricante.SelectedValue);
            aeronave.TipoServicio = ((TipoServicioDTO)ComboTipoServicio.SelectedValue);
            aeronave.KG = Decimal.ToInt32(NumericKG.Value);
            aeronave.Matricula = TextMatricula.Text;
            aeronave.Modelo = ((ModeloDTO)ComboModelo.SelectedValue);

            aeronaveFilters.Aeronave = aeronave;
            if (DateAlta.Checked) aeronaveFilters.Aeronave.FechaAlta = DateAlta.Value;
            else aeronaveFilters.Aeronave.FechaAlta = null;
            if (DateAltaFin.Checked) aeronaveFilters.Fecha_Alta_Fin = DateAltaFin.Value;
            else aeronaveFilters.Fecha_Alta_Fin = null;

            this.tablaDatos.DataSource = AeronaveDAO.GetByFiltersSinViajesProgramados(aeronaveFilters,this.FormPadre.dateTimePickerFechSal.Value,this.FormPadre.dateTimePickerFechLLEstim.Value);
            if (Equals(this.tablaDatos.Rows.Count, 0))
            {
                MessageBox.Show("No se encontraron datos");
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMatricula.Text = "";
            NumericKG.Value = 0;
            DateAlta.Value = DateTime.Now;
            DateAltaFin.Value = DateTime.Now;
            ComboModelo.SelectedIndex = -1;
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.SelectedIndex = -1;
            errorProvider1.Clear();
            DateAlta.Checked = false;
            DateAltaFin.Checked = false;
            tablaDatos.DataSource = null;
        }

        private void tablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != tablaDatos.Columns.IndexOf(tablaDatos.Columns["Seleccionar"]) || tablaDatos.DataSource == null)
                return;

            AeronaveDTO aeronave = (AeronaveDTO)tablaDatos.Rows[e.RowIndex].DataBoundItem;
            this.FormPadre.textBoxAeronave.Text = aeronave.Numero.ToString();
            this.Close();
        }

        private void ListadoAeronaves_Load(object sender, EventArgs e)
        {
            ComboFabricante.DataSource = FabricanteDAO.selectAll();
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.DataSource = TipoServicioDAO.selectAll();
            ComboTipoServicio.SelectedItem = this.FormPadre.TipoServicio;
            ComboTipoServicio.Enabled = false;
            ComboModelo.DataSource = ModeloDAO.selectAll();
            ComboModelo.SelectedIndex = -1;
        }

        public void Reload()
        {
            this.tablaDatos.DataSource = AeronaveDAO.GetByFilters(aeronaveFilters);
        }
    }
}
