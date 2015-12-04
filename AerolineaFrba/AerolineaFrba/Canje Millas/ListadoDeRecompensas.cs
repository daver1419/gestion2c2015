using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Helpers;
using AerolineaFrba.DAO;

namespace AerolineaFrba.Canje_Millas
{
    public partial class ListadoDeRecompensas : Form
    {
        public ListadoDeRecompensas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar()) return;
            this.textBox2.Text = MillasDAO.getMillas(this.textDNI.Text);
            UpdateDataGridViewRowColors();

        }

        private bool validar()
        {
            errorProvider1.Clear();
            bool ret = false;
            if ((!Utility.esDNI(this.textDNI) && !(this.textDNI.Text == "")) || (this.textDNI.Text == ""))
            {
                errorProvider1.SetError(this.textDNI, "Debe ingresar un DNI (no puede superar los 8 digitos).");
                ret = true;
            }
            return ret;
        }

        private void UpdateDataGridViewRowColors()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int MillasNecesarias = Convert.ToInt32(row.Cells[1].Value);
                int MillasDisponibles = Convert.ToInt32(this.textBox2.Text);

                if (MillasNecesarias > MillasDisponibles)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (MillasNecesarias < MillasDisponibles)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

            }
        }

        private void ListadoDeRecompensas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MillasDAO.getRecompensas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            dataGridView1.DataSource = MillasDAO.getRecompensas();
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.textBox2.Text = "";
            this.textDNI.Text = "";
        }
    }
}
