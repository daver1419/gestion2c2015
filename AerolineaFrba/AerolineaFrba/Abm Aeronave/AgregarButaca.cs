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
    public partial class AgregarButaca : Form
    {
        private ButacaDTO Butaca;

        public AgregarButaca()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (validar()) return;
            Butaca.Numero = (int) NumeroNumeric.Value;
            Butaca.Piso = (int) PisoNumeric.Value;
            Butaca.Tipo_Butaca = (TipoButacaDTO) TipoButacaCombo.SelectedValue;
            ((AltaAeronave)this.Owner).Agregar_Butaca(Butaca);
            this.Close();
        }

        private void AgregarButaca_Load(object sender, EventArgs e)
        {
            Butaca = new ButacaDTO();
            TipoButacaCombo.DataSource = TipoButacaDAO.selectAll();
            TipoButacaCombo.SelectedIndex = -1;
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            ButacaDTO unaButaca = new ButacaDTO();
            unaButaca.Numero = (int)NumeroNumeric.Value;
            if (((AltaAeronave)this.Owner).Tiene_Butaca(unaButaca))
            {
                errorProvider1.SetError(NumeroNumeric, "El numero de esta butaca ya esta ocupado.");
                ret = true;
            }
            if (this.TipoButacaCombo.SelectedIndex == -1)
            {
                errorProvider1.SetError(TipoButacaCombo, "Debe crear la butaca con un tipo.");
                ret = true;
            }
            return ret;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            NumeroNumeric.Value = 0;
            PisoNumeric.Value = 1;
            TipoButacaCombo.SelectedIndex = -1;
            errorProvider1.Clear();
        }
    }
}
