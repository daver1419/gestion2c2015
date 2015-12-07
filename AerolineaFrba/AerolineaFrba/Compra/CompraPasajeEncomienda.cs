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

namespace AerolineaFrba.Compra
{
    public partial class CompraPasajeEncomienda : Form
    {
        public List<Tuple<ClienteDTO,ButacaDTO>> listaPasajerosButacas;
        public ClienteDTO clienteEncomienda;

        public CompraPasajeEncomienda()
        {
            InitializeComponent();
        }


        private void CompraPasajeEncomienda_Load(object sender, EventArgs e)
        {
            comboBoxCiudOrig.DataSource = CiudadDAO.SelectAll();
            comboBoxCiudDest.DataSource = CiudadDAO.SelectAll();
            comboBoxCiudOrig.SelectedIndex = -1;
            comboBoxCiudDest.SelectedIndex = -1;

            dateTimePickerEnt.Value = DateTime.Now;
            dateTimePickerSal.Value = DateTime.Now;

            label5.Hide();
            label6.Hide();
            label7.Hide();
            comboBoxCantPas.Hide();
            numericUpDown1.Hide();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dateTimePickerEnt.Value = DateTime.Now;
            dateTimePickerSal.Value = DateTime.Now;
            comboBoxCiudDest.SelectedIndex = -1;
            comboBoxCiudOrig.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            label5.Hide();
            label5.Hide();
            label7.Hide();
            comboBoxCantPas.Hide();
            comboBoxCantPas.SelectedIndex = -1;
            numericUpDown1.Hide();
            numericUpDown1.Value = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["ColumnCompra"]))
                return;
            GridViajesDTO gridViaje = (GridViajesDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (gridViaje.CantButacasDisp == 0 && (Int32)comboBoxCantPas.SelectedItem != 0)
            {
                MessageBox.Show("Todos los pasajes de este viaje estan vendidos");
                return;
            }
            if (gridViaje.KgsDisponibles == 0 && numericUpDown1.Value != 0)
            {
                MessageBox.Show("No quedan kgs disponibles");
                return;
            }
            if (numericUpDown1.Value > gridViaje.KgsDisponibles)
            {
                MessageBox.Show(string.Format("A la aeronave del viaje seleccionado solo le quedan: {0} Kgs disponibles",gridViaje.KgsDisponibles));
                return;
            }
            if((Int32)comboBoxCantPas.SelectedItem > gridViaje.CantButacasDisp)
            {
               MessageBox.Show(string.Format("A la aeronave del viaje seleccionado solo le quedan: {0} pasajes disponibles",gridViaje.CantButacasDisp)); 
                return;
            }

            bool compraEncomienda=false;

            if (numericUpDown1.Value > 0)
            {
                compraEncomienda = true;
                IngresoDatos vent = new IngresoDatos(gridViaje.NumeroAeronave, compraEncomienda);
            } 
            List<Tuple<ClienteDTO, ButacaDTO>> listaTupla = new List<Tuple<ClienteDTO, ButacaDTO>>();
            ClienteDTO clienteEnco = new ClienteDTO();
            this.listaPasajerosButacas = listaTupla;
            this.clienteEncomienda = clienteEnco;

            if (Convert.ToInt32(comboBoxCantPas.SelectedItem.ToString()) > 0 && comboBoxCantPas.SelectedItem != null)
            {
                for (int i = 1; i <= Convert.ToInt32(comboBoxCantPas.SelectedItem.ToString()); i++)
                {
                    compraEncomienda = false;
                    IngresoDatos ventana = new IngresoDatos(gridViaje.NumeroAeronave, compraEncomienda);
                    ventana.ShowDialog(this);
                }
            }
            FormaPago formPago = new FormaPago(gridViaje.IdViaje,this.listaPasajerosButacas,this.clienteEncomienda,Convert.ToInt32( numericUpDown1.Value));
            formPago.ShowDialog(this);

        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (dateTimePickerEnt.Value < DateTime.Now)
            {
                errorProvider1.SetError(dateTimePickerEnt, "La fecha debe ser posterior al actual.");
                ret = false;
            }
            if (this.dateTimePickerSal.Value < dateTimePickerEnt.Value)
            {
                errorProvider1.SetError(dateTimePickerSal, "La fecha de salida debe ser posterior a la de entrada");
                ret = false;
            }
            if (this.comboBoxCiudOrig.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxCiudOrig, "Debe seleccionar una ciudad");
                ret = false;
            }
            if (this.comboBoxCiudDest.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxCiudDest, "Debe seleccionar una ciudad");
                ret = false;
            }
            if (this.comboBoxCiudOrig.SelectedItem == this.comboBoxCiudDest.SelectedItem)
            {
                errorProvider1.SetError(comboBoxCiudDest,"La ciudad de destino no puede ser igual a la de origen");
                ret = false;
            }
            return ret;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ViajeDTO viaje = new ViajeDTO();
                viaje.FechaSalida = dateTimePickerEnt.Value;
                viaje.FechaLlegadaEstimada = dateTimePickerSal.Value;
                RutaDTO ruta = new RutaDTO();
                ruta.CiudadOrigen = (CiudadDTO)comboBoxCiudOrig.SelectedItem;
                ruta.CiudadDestino = (CiudadDTO)comboBoxCiudDest.SelectedItem;
                viaje.Ruta = ruta;
                dataGridView1.DataSource = ViajeDAO.GetByFechasCiudadesOrigenDestino(viaje);
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[9].Visible = false;
            }
            if (dataGridView1.DataSource != null)
            {
                label5.Show();
                label6.Show();
                label7.Show();
                comboBoxCantPas.Show();
                numericUpDown1.Show();
            }
        }
    }
}
