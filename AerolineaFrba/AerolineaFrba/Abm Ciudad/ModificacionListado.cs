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

namespace AerolineaFrba.Abm_Ciudad
{
    public partial class ModificacionListado : Form
    {
        private CiudadDTO ciudad;

        public ModificacionListado()
        {
            InitializeComponent();
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }

        private void ModificacionCiudad_Load(object sender, EventArgs e)
        {
            textBoxDescr.Text = "";
            dataGridView1.DataSource = null;
            this.ciudad = new CiudadDTO();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxDescr.Text = "";
            dataGridView1.DataSource = null;
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (textBoxDescr.Text == "")
            {
                errorProvider1.SetError(textBoxDescr, "Ingrese una descripcion");
                ret = false;
            }
            return ret;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ciudad.Descripcion = textBoxDescr.Text;
                this.dataGridView1.DataSource= CiudadDAO.GetByDescripcion(ciudad);
                if (Equals(this.dataGridView1.Rows.Count, 0))
                {
                    MessageBox.Show("No se encontraron datos");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["ColumnSel"]))
                return;
            CiudadDTO unaCiudad = (CiudadDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            Modificacion vent = new Modificacion(unaCiudad);
            vent.ShowDialog(this);
        }
    }
}
