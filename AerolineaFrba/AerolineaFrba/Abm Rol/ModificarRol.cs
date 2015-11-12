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
    public partial class ModificarRol : Form
    {

        private RolDTO rol;
        private List<FuncionalidadDTO> Agregar;
        private List<FuncionalidadDTO> Eliminar;

        public ModificarRol(RolDTO unRol)
        {
            InitializeComponent();
            this.rol = unRol;
            this.Agregar = new List<FuncionalidadDTO>();
            this.Eliminar = new List<FuncionalidadDTO>();
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            this.txtBoxRol.Text = this.rol.NombreRol;
            this.txtBoxRol.Enabled = false;
            this.checkBox1.Checked = this.rol.Estado;
            this.checkBox1.Enabled = false;
            this.checkBox2.Checked = this.rol.Estado;
            this.FuncionalidadesCombo.DataSource = rol.ListaFunc;
            this.FuncionalidadesCombo.SelectedIndex = -1;
            this.checkedListBox1.SelectedIndex = -1;
            List<FuncionalidadDTO> funcionalidades = FuncionalidadDAO.SelectAll();
            this.checkedListBox1.DataSource = rol.ListaFunc;
            this.checkedListBox2.DataSource = funcionalidades.Except(rol.ListaFunc).ToList();
            this.textBox1.Text = this.rol.NombreRol;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (this.Eliminar.Contains(this.checkedListBox1.SelectedItem as FuncionalidadDTO))
            {
                this.Eliminar.Remove(this.checkedListBox1.SelectedItem as FuncionalidadDTO);
            }
            else
            {
                this.Eliminar.Add(this.checkedListBox1.SelectedItem as FuncionalidadDTO);
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

        private void LimpiarListado(object sender, FormClosingEventArgs e)
        {
            ((ListadoRoles)this.Owner).Reload();
        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            this.txtBoxRol.Text = this.rol.NombreRol;
            this.checkBox1.Checked = this.rol.Estado;
            this.checkBox2.Checked = this.rol.Estado;
            this.FuncionalidadesCombo.DataSource = rol.ListaFunc;
            this.FuncionalidadesCombo.SelectedIndex = -1;
            this.checkedListBox1.SelectedIndex = -1;
            List<FuncionalidadDTO> funcionalidades = FuncionalidadDAO.SelectAll();
            this.checkedListBox1.DataSource = rol.ListaFunc;
            this.checkedListBox2.DataSource = funcionalidades.Except(rol.ListaFunc).ToList();
            this.textBox1.Text = this.rol.NombreRol;
            this.errorProvider1.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            if (this.textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "El nombre del rol no puede ser vacio");
                return;
            }
            this.rol.NombreRol = textBox1.Text;
            this.rol.Estado = checkBox2.Checked;
            FuncionalidadDAO.InsertarFuncionalidades(this.Agregar, this.rol.IdRol);
            FuncionalidadDAO.RemoverFuncionalidades(this.Eliminar, this.rol.IdRol);
            RolDAO.update(this.rol);
            MessageBox.Show("El rol fue modificado con exito");
            this.Close();
        }

    }
}
