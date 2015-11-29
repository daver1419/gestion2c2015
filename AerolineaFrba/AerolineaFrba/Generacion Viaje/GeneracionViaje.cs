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

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class GeneracionViaje : Form
    {
        public TipoServicioDTO TipoServicio;
        private ViajeDTO Viaje;

        public GeneracionViaje()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dateTimePickerFechSal.Value = DateTime.Now;
            dateTimePickerFechLleg.Value = DateTime.Now;
            dateTimePickerFechLLEstim.Value = DateTime.Now;
            textBoxRuta.Text = "";
            textBoxAeronave.Text = "";
            buttonSelAeronave.Enabled = false;
            TipoServicio = null;
        }

        private void buttonSelRuta_Click(object sender, EventArgs e)
        {
            ListadoRutas Form = new ListadoRutas(this);
            Form.ShowDialog(this);
        }

        private void buttonSelAeronave_Click(object sender, EventArgs e)
        {
            ListadoAeronaves Form = new ListadoAeronaves(this);
            Form.ShowDialog(this);
        }

        private bool validarFechas()
        {
            errorProvider1.Clear();
            bool ret = true;
            if (dateTimePickerFechSal.Value < DateTime.Now)
            {
                errorProvider1.SetError(dateTimePickerFechSal, "Debe ingresar fecha de salida mayor al actual");
                ret = false;
            }
            if (dateTimePickerFechLleg.Value < dateTimePickerFechSal.Value)
            {
                errorProvider1.SetError(dateTimePickerFechLleg, "La fecha de llegada no puede ser menor a la de salida");
                ret = false;
            }
            if (dateTimePickerFechLLEstim.Value < dateTimePickerFechSal.Value)
            {
                errorProvider1.SetError(dateTimePickerFechLLEstim, "La fecha de llegada no puede ser menor a la de salida");
                ret = false;
            }
            return ret;
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            if (validarFechas())
            {
                Viaje.FechaSalida = dateTimePickerFechSal.Value;
                Viaje.FechaLlegada = dateTimePickerFechLleg.Value;
                Viaje.FechaLlegadaEstimada = dateTimePickerFechLLEstim.Value;
                RutaDTO ruta=new RutaDTO();
                ruta.IdRuta=Int32.Parse( textBoxRuta.Text);
                Viaje.Ruta = ruta;
                AeronaveDTO aeronave = new AeronaveDTO();
                aeronave.Numero =Int32.Parse( textBoxAeronave.Text);
                Viaje.Aeronave = aeronave;

                if (!ViajeDAO.Generar(Viaje))
                {
                    MessageBox.Show("No se pudo generar el viaje");
                }
                else
                {
                    MessageBox.Show("Se genero el viaje con exito");
                }
            }
        }

        private void textBoxRuta_TextChanged(object sender, EventArgs e)
        {
            this.buttonSelAeronave.Enabled = true;
        }

        private void GeneracionViaje_Load(object sender, EventArgs e)
        {

        }
    }
}
