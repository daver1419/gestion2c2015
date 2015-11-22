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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class ListadoRuta : Form
    {
        private RutaDTO ruta;

        public ListadoRuta()
        {
            InitializeComponent();
        }

        private void ListadoRuta_Load(object sender, EventArgs e)
        {
            comboBoxTipoServ.DataSource=TipoServicioDAO.selectAll();
            comboBoxCiudadOrig.DataSource = CiudadDAO.SelectAll();
            comboBoxCiudadDest.DataSource = CiudadDAO.SelectAll();
            comboBoxTipoServ.SelectedIndex = -1;
            comboBoxCiudadOrig.SelectedIndex = -1;
            comboBoxCiudadDest.SelectedIndex = -1;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodigo.Text = "";
            comboBoxTipoServ.SelectedIndex = -1;
            comboBoxCiudadOrig.SelectedIndex = -1;
            comboBoxCiudadDest.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["ColumnSel"]))
                return;
            RutaDTO unaRuta = (RutaDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            ModificacionRuta vent = new ModificacionRuta(unaRuta);
            vent.ShowDialog(this);
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (textBoxCodigo.Text == "")
            {
                errorProvider1.SetError(textBoxCodigo, "Ingrese un codigo");
                ret = false;
            }
            return ret;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ruta.Codigo =Int32.Parse( textBoxCodigo.Text);
                ruta.CiudadOrigen = (CiudadDTO)comboBoxCiudadOrig.SelectedItem;
                ruta.CiudadDestino = (CiudadDTO)comboBoxCiudadDest.SelectedItem;
                ruta.PrecioBaseKg = numericUpDown1.Value;
                ruta.PrecioBasePasaje = numericUpDown2.Value;
                ruta.Servicio = (TipoServicioDTO)comboBoxTipoServ.SelectedItem;
                this.dataGridView1.DataSource = RutaDAO.GetByFilters(ruta);
                
                if (Equals(this.dataGridView1.Rows.Count, 0))
                {
                    MessageBox.Show("No se encontraron datos");
                }
            }
        }
    }
}
