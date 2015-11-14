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

namespace AerolineaFrba.Abm_Rol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            FuncionalidadesCombo.DataSource = FuncionalidadDAO.SelectAll();
            FuncionalidadesCombo.SelectedIndex = -1;
            ActivoCheck.Checked = true;
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            FuncionalidadesCombo.SelectedIndex = -1;
            NombreText.Text = "";
            ActivoCheck.Checked = true;
            errorProvider1.Clear();
        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if (this.NombreText.Text == "")
            {
                errorProvider1.SetError(NombreText, "El nombre del rol no puede ser vacio");
                ret = true;
            }
            if (this.FuncionalidadesCombo.SelectedIndex == -1)
            {
                errorProvider1.SetError(FuncionalidadesCombo, "Debe crear el rol con alguna funcionalidad");
                ret = true;
            }
            return ret;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (validar()) return;

            RolDTO rol = new RolDTO();
            RolxFuncDTO rolxfun = new RolxFuncDTO();
            rol.NombreRol = NombreText.Text;
            rol.Estado = ActivoCheck.Checked;
            rol.ListaFunc.Add(this.FuncionalidadesCombo.SelectedItem as FuncionalidadDTO);
            rolxfun.funcionalidad = (this.FuncionalidadesCombo.SelectedItem as FuncionalidadDTO).IdFuncionalidad;
            rolxfun.rol = rol.IdRol;

            if ((RolDAO.insertarRol(rol)) && (RolxFuncDAO.insertarRolxFuncionalidad(rolxfun)))
            {
                MessageBox.Show("Los datos se guardaron con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar los datos. El Cliente ya existe");
            }
        }
    }
}
