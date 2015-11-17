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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ListadoButacas : Form
    {
        AeronaveDTO Aeronave;

        public ListadoButacas(AeronaveDTO unaAeronave)
        {
            InitializeComponent();
            this.Aeronave = unaAeronave;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || dataGridView1.RowCount == e.RowIndex + 1 || (e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["Seleccionar"]) && e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["Eliminar"])))
                return;

            ButacaDTO butaca = (ButacaDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (e.ColumnIndex == dataGridView1.Columns.IndexOf(dataGridView1.Columns["Seleccionar"]))
            {
                ModificarButaca vent = new ModificarButaca(butaca);
                vent.ShowDialog(this);
            }
            else
            {
                var confirmResult = MessageBox.Show("Seguro que quieres eliminar esta butaca?",
                                     "Confirmar Delete",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    ButacaDAO.delete(butaca);
                    MessageBox.Show("La butaca fue eliminada con exito.");
                    Reload();
                }
            }
        }

        public void Reload()
        {
            dataGridView1.DataSource = Aeronave.ListaButacas;
        }

        private void ListadoButacas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Aeronave.ListaButacas;
        }

        private void ListadoButacas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((ModificarAeronave)this.Owner).ReloadButacas();
        }

    }
}
