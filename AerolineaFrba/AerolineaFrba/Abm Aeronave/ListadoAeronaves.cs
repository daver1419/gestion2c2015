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
        public ListadoAeronaves()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (validar()) return;
            // hay que traer el datagrid view con el [SP_Busqueda_Aeronave]

        }

        private void tablaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != tablaDatos.Columns.IndexOf(tablaDatos.Columns["Seleccionar"]) || tablaDatos.DataSource == null)
                return;

            AeronaveDTO aeronave = (AeronaveDTO)tablaDatos.Rows[e.RowIndex].DataBoundItem;

            if (AeronaveDAO.ViajesProgramados(aeronave))
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
            TextModelo.Text = "";
            NumericKG.Value = -1;
            ButacaNumeric.Value = -1;
            DateAlta.Value = DateTime.Now;
            ComboFabricante.SelectedIndex = -1;
            ComboTipoServicio.SelectedIndex = -1;
            errorProvider1.Clear();
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if (!buenFormatoMatricula(this.TextMatricula))
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
    }
}
