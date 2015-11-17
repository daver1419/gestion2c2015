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
    public partial class ModificarButaca : Form
    {
        private ButacaDTO Butaca;

        public ModificarButaca(ButacaDTO unaButaca)
        {
            InitializeComponent();
            this.Butaca = unaButaca;
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (validar()) return;
            Butaca.Numero = (int) NumeroNumeric.Value;
            Butaca.Piso = (int) PisoNumeric.Value;
            Butaca.Tipo_Butaca = (TipoButacaDTO) TipoButacaCombo.SelectedValue;
            Butaca.Habilitada = HabilitadaCheck.Checked;
            ((ModificarAeronave)((ListadoButacas)this.Owner).Owner).Modificar_Butaca(Butaca);
            ((ListadoButacas)this.Owner).Reload();
            this.Close();
        }

        private void ModificarButaca_Load(object sender, EventArgs e)
        {
            NumeroNumeric.Value = Butaca.Numero;
            PisoNumeric.Value = Butaca.Piso;
            TipoButacaCombo.DataSource = TipoButacaDAO.selectAll();
            TipoButacaCombo.SelectedItem = Butaca.Tipo_Butaca;
            HabilitadaCheck.Checked = Butaca.Habilitada;
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            ButacaDTO unaButaca = new ButacaDTO();
            unaButaca.Numero = (int)NumeroNumeric.Value;
            if (this.TipoButacaCombo.SelectedIndex == -1)
            {
                errorProvider1.SetError(TipoButacaCombo, "La butaca debe tener un tipo.");
                ret = true;
            }
            return ret;
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            NumeroNumeric.Value = Butaca.Numero;
            PisoNumeric.Value = Butaca.Piso;
            TipoButacaCombo.DataSource = TipoButacaDAO.selectAll();
            TipoButacaCombo.SelectedItem = Butaca.Tipo_Butaca;
            HabilitadaCheck.Checked = Butaca.Habilitada;
            errorProvider1.Clear();
        }
    }
}
