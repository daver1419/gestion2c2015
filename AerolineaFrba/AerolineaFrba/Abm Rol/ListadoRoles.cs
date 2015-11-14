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

namespace AerolineaFrba.Abm_Rol
{
    public partial class ListadoRoles : Form
    {
        public ListadoRoles()
        {
            InitializeComponent();
        }

        private void ListadoRoles_Load(object sender, EventArgs e)
        {
            this.comboBox2.DataSource = RolDAO.SelectAllString();
            this.comboBox2.SelectedIndex = -1;
            this.dataGridView1.DataSource = null;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            //Ignora el buscar si no hay un rol que buscar.
            if (this.comboBox2.SelectedIndex == -1) return;

            RolDTO rol = new RolDTO();
            rol.NombreRol = comboBox2.SelectedItem as String;

            BindingSource bsA = RolDAO.getDataGrid(rol);
            BindingSource bsB = new BindingSource();
            this.dataGridView1.DataSource = bsA;
            this.dataGridView1.AutoGenerateColumns = true;

            // Set up data binding for the child
            bsB.DataSource = bsA; // chaining bsP to bsA
            bsB.DataMember = "ListaFunc";                 //** 
            listBox1.DataSource = bsB;
            listBox1.DisplayMember = "Descripcion";
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            listBox1.DataSource = null;
            dataGridView1.DataSource = null;
        }

        public void Reload()
        {
            this.comboBox2.DataSource = RolDAO.SelectAllString();
            this.comboBox2.SelectedIndex = -1;
            this.dataGridView1.DataSource = null;
            listBox1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || dataGridView1.RowCount == e.RowIndex + 1 || (e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["Seleccionar"]) && e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["Eliminar"])))
                return;

            RolDTO rol = (RolDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            if (e.ColumnIndex == dataGridView1.Columns.IndexOf(dataGridView1.Columns["Seleccionar"]))
            {
                ModificarRol vent = new ModificarRol(rol);
                vent.ShowDialog(this);
            }
            else
            {
                var confirmResult = MessageBox.Show("Seguro que quieres eliminar este rol?",
                                     "Confirmar Delete",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    RolDAO.delete(rol);
                    MessageBox.Show("El rol fue eliminado con exito");
                    Reload();
                }
            }
        }

        

    }
}
