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
        private int NroAeronave;

        public SeleccionButaca(int nroAeronave)
        {
            InitializeComponent();
            this.NroAeronave = nroAeronave;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["ColumnSel"]))
                return;
            ButacaDTO unaButaca = (ButacaDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            //this.aeronave.ListaButacas.Add(unaButaca); CHEQUEAR QUE LE AÑADA ESTA COSA
            this.Close();
        }

        private void SeleccionButaca_Load(object sender, EventArgs e)
        {
            AeronaveDTO aeronave = new AeronaveDTO();
            aeronave.Numero = this.NroAeronave;
            this.dataGridView1.DataSource=ButacaDAO.GetByAeronave(aeronave);
        }
    }
}
