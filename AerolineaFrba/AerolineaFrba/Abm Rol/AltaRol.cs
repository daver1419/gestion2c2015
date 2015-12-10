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
        private List<FuncionalidadDTO> Agregar;

        public AltaRol()
        {
            InitializeComponent();
            this.Agregar = new List<FuncionalidadDTO>();
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            ActivoCheck.Checked = true;
            List<FuncionalidadDTO> funcionalidades = FuncionalidadDAO.SelectAll();
            this.checkedListBox2.DataSource = funcionalidades.ToList();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            NombreText.Text = "";
            ActivoCheck.Checked = true;
            errorProvider1.Clear();
            this.checkedListBox2.ClearSelected();
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
            if (this.checkedListBox2.SelectedIndex == -1)
            {
                errorProvider1.SetError(this.checkedListBox2, "Debe crear el rol con alguna funcionalidad");
                ret = true;
            }
            return ret;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (validar()) return;
            RolDTO rol = new RolDTO();
            //RolxFuncDTO rolxfun = new RolxFuncDTO();
            rol.NombreRol = NombreText.Text;
            rol.Estado = ActivoCheck.Checked;
            //rol.ListaFunc.Add(this.FuncionalidadesCombo.SelectedItem as FuncionalidadDTO);
            //rolxfun.funcionalidad = (this.FuncionalidadesCombo.SelectedItem as FuncionalidadDTO).IdFuncionalidad;
            //rolxfun.rol = rol.IdRol;
            if (RolDAO.GetByNombre(rol) == null)
            {
                if (RolDAO.insertarRol(rol))
                {
                    rol=RolDAO.GetByNombre(rol);
                    FuncionalidadDAO.InsertarFuncionalidades(this.Agregar, rol.IdRol);
                    MessageBox.Show("Los datos se guardaron con exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos. El Cliente ya existe");
                }
            }
            else
            {
                MessageBox.Show(string.Format("Ya existe un rol con el nombre : {0}",rol.NombreRol));
            }
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.Agregar.Contains(this.checkedListBox2.SelectedItem as FuncionalidadDTO))
            {
                this.Agregar.Remove(this.checkedListBox2.SelectedItem as FuncionalidadDTO);
            }
            else
            {
                this.Agregar.Add(this.checkedListBox2.SelectedItem as FuncionalidadDTO);
            }
        }
    }
}
