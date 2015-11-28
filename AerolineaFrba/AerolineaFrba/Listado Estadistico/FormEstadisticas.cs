using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class FormEstadisticas : Form
    {
        private string listado;

        public FormEstadisticas()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listado = (string)listOpciones.SelectedItem;
            if (!(comboAnio.Text == "" || comboSemestre.Text == ""))
            {
                new ListadoFinal(Convert.ToInt32(comboAnio.Text), Convert.ToInt32(comboSemestre.Text), listado) { Icon = this.Icon }.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Complete el año y el semestre");
            }
        }
    }
}
