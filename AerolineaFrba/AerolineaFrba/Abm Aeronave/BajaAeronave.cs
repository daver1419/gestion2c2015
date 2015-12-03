using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AerolineaFrba.DTO;
using AerolineaFrba.DAO;
using System.Text.RegularExpressions;
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class BajaAeronave : Form
    {
        AeronaveDTO aeronave;
        AeronaveFiltersDTO aeronaveFilters;

        public BajaAeronave()
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


            this.tablaDatos.DataSource = AeronaveDAO.GetByFiltersBaja(aeronaveFilters);
            if (Equals(this.tablaDatos.Rows.Count, 0))
            {
                MessageBox.Show("No se encontraron datos");
            }
            

        }

        private void tablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || tablaDatos.RowCount == e.RowIndex + 1 || (e.ColumnIndex != tablaDatos.Columns.IndexOf(tablaDatos.Columns["Baja_Temporal"]) && e.ColumnIndex != tablaDatos.Columns.IndexOf(tablaDatos.Columns["Baja_Def"])))
                return;

            AeronaveDTO aeronave = (AeronaveDTO)tablaDatos.Rows[e.RowIndex].DataBoundItem;
            bool reemplazar = false;

            if (AeronaveDAO.ViajesProgramados(aeronave))
            {
                var confirmResult = MessageBox.Show("Esta aeronave tiene viajes programados, desea reemplazar esta aeronave?",
                    "Confirmar Delete",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    reemplazar = true;
                }
            }

            if (e.ColumnIndex == tablaDatos.Columns.IndexOf(tablaDatos.Columns["Baja_Temporal"]))
            {
                var confirmResult = MessageBox.Show("Seguro que quieres dar de baja temporalmente?",
                    "Confirmar Delete",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    BajaTemporal vent = new BajaTemporal(aeronave, reemplazar);
                    vent.ShowDialog(this);
                    Reload();
                }
            }
            else
            {
                var confirmResult = MessageBox.Show("Seguro que quieres dar de baja definitiva?",
                    "Confirmar Delete",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    if (reemplazar)
                    {

                    }
                    else
                    {
                        AeronaveDAO.BajaDefCancelar(aeronave);
                    }
                    Reload();
                }
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

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if (!Utility.buenFormatoMatricula(this.TextMatricula) && !(this.TextMatricula.Text == ""))
            {
                errorProvider1.SetError(TextMatricula, "Debe ingresar una matricula en el formato XXX-000");
                ret = true;
            }
            return ret;
        }

        private void BajaAeronaves_Load(object sender, EventArgs e)
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
            this.tablaDatos.DataSource = AeronaveDAO.GetByFiltersBaja(aeronaveFilters);
        }
    }
}

