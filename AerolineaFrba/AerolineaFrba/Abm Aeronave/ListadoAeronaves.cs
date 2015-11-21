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
    public partial class ListadoAeronaves : Form
    {
        AeronaveDTO aeronave;
        AeronaveFiltersDTO aeronaveFilters;

        public ListadoAeronaves()
        {
            InitializeComponent();
            aeronave = new AeronaveDTO();
            aeronaveFilters = new AeronaveFiltersDTO();
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
            if (DateBaja.Checked) aeronaveFilters.Fecha_Baja_Def = DateBaja.Value;
            else aeronaveFilters.Fecha_Baja_Def = null;
            if (DateBajaFin.Checked) aeronaveFilters.Fecha_Baja_Def_Fin = DateBajaFin.Value;
            else aeronaveFilters.Fecha_Alta_Fin = null;
            if (DateFuera.Checked) aeronaveFilters.Fecha_Baja_Temporal = DateFuera.Value;
            else aeronaveFilters.Fecha_Baja_Temporal = null;
            if (DateFueraFin.Checked) aeronaveFilters.Fecha_Baja_Temporal_Fin = DateFueraFin.Value;
            else aeronaveFilters.Fecha_Baja_Temporal_Fin = null;
            if (DateVuelta.Checked) aeronaveFilters.Fecha_Vuelta_Servicio = DateVuelta.Value;
            else aeronaveFilters.Fecha_Vuelta_Servicio = null;
            if (DateVueltaFin.Checked) aeronaveFilters.Fecha_Vuelta_Servicio_Fin = DateVueltaFin.Value;
            else aeronaveFilters.Fecha_Vuelta_Servicio_Fin = null;


            this.tablaDatos.DataSource = AeronaveDAO.GetByFilters(aeronaveFilters);
            if (Equals(this.tablaDatos.Rows.Count, 0))
            {
                MessageBox.Show("No se encontraron datos");
            }
            

        }

        private void tablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != tablaDatos.Columns.IndexOf(tablaDatos.Columns["Seleccionar"]) || tablaDatos.DataSource == null)
                return;

            AeronaveDTO aeronave = (AeronaveDTO)tablaDatos.Rows[e.RowIndex].DataBoundItem;

            if (!AeronaveDAO.ViajesProgramados(aeronave))
            {
                ModificarAeronave vent = new ModificarAeronave(aeronave);
                vent.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No se puede modificar la Aeronave porque tiene viajes planificados.");
            }
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            TextMatricula.Text = "";
            NumericKG.Value = 0;
            DateAlta.Value = DateTime.Now;
            DateAltaFin.Value = DateTime.Now;
            DateBaja.Value = DateTime.Now;
            DateBajaFin.Value = DateTime.Now;
            DateFuera.Value = DateTime.Now;
            DateFueraFin.Value = DateTime.Now;
            DateVuelta.Value = DateTime.Now;
            DateVueltaFin.Value = DateTime.Now;
            ComboModelo.SelectedIndex = -1;
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.SelectedIndex = -1;
            errorProvider1.Clear();
            DateAlta.Checked = false;
            DateAltaFin.Checked = false;
            DateBaja.Checked = false;
            DateBajaFin.Checked = false;
            DateFuera.Checked = false;
            DateFueraFin.Checked = false;
            DateVuelta.Checked = false;
            DateVueltaFin.Checked = false;
            tablaDatos.DataSource = null;
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
            return ret;
        }

        private static bool buenFormatoMatricula(Control mitextbox)
        {
            Regex regex = new Regex(@"[a-zA-Z]{3}[\-]{1}[0-9]{3}$");
            return regex.IsMatch(mitextbox.Text);
        }

        private void ListadoAeronaves_Load(object sender, EventArgs e)
        {
            ComboFabricante.DataSource = FabricanteDAO.selectAll();
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.DataSource = TipoServicioDAO.selectAll();
            ComboTipoServicio.SelectedIndex = -1;
            ComboModelo.DataSource = ModeloDAO.selectAll();
            ComboModelo.SelectedIndex = -1;

        }

        public void Reload()
        {
            this.tablaDatos.DataSource = AeronaveDAO.GetByFilters(aeronaveFilters);
        }
    }
}
