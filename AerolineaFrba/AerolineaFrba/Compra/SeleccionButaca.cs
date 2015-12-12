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

namespace AerolineaFrba.Compra
{
    public partial class SeleccionButaca : Form
    {
        private GridViajesDTO gridViaje;

        public SeleccionButaca(GridViajesDTO unGridViaje)
        {
            InitializeComponent();
            this.gridViaje= unGridViaje;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["ColumnSel"]))
                return;
            ButacaDTO unaButaca = (ButacaDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            ((IngresoDatos)this.Owner).butaca = unaButaca;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SeleccionButaca_Load(object sender, EventArgs e)
        {
            List<ButacaDTO> listaButacas=((CompraPasajeEncomienda)((IngresoDatos)(this.Owner)).Owner).listaPasajerosButacas.Select(t => t.Item2).ToList<ButacaDTO>();
            this.dataGridView1.DataSource=ButacaDAO.GetDisponiblesByAeronave(this.gridViaje).Except(listaButacas).ToList();
        }
    }
}
