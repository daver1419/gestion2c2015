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
using AerolineaFrba.DTO;

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
            dataGridView1.Enabled = true;
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
                int MillasNecesarias = Convert.ToInt32(row.Cells[4].Value);
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
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            dataGridView1.DataSource = MillasDAO.getRecompensas();
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.textBox2.Text = "";
            this.textDNI.Text = "";
            dataGridView1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == null)
            {
                MessageBox.Show("Debe introducir una cantidad a canjear.");
                return;
            }
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["Seleccionar"]) || dataGridView1.DataSource == null)
                return;

            RecompensaDTO Recompensa = (RecompensaDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            int Cantidad = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

            if(Cantidad == 0)
            {
                MessageBox.Show("La cantidad a canjear debe ser mayor a 0.");
                return;
            }

            if (Recompensa.Stock > 0)
            {
                if (Recompensa.Millas * Cantidad < Convert.ToInt32(this.textBox2.Text))
                {
                    if (MillasDAO.doCanje(Convert.ToInt32(this.textDNI.Text), Recompensa.Id, Cantidad))
                    {
                        MessageBox.Show("Canje exitoso, imprima el comprobante y pase a retirar su recompensa por cualquiera de nuestras sucursales.");
                        Reload();
                    }
                    else
                    {
                        MessageBox.Show("Su canje no se ha efectuado con exito.");
                    }
                }
                else
                {
                    MessageBox.Show("No le alcanzan las millas para lo que intenta canjear.");
                }
            }
            else
            {
                MessageBox.Show("No hay stock suficiente del producto seleccionado.");
            }


        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Reload()
        {
            dataGridView1.DataSource = MillasDAO.getRecompensas();
            this.textBox2.Text = MillasDAO.getMillas(this.textDNI.Text);
            UpdateDataGridViewRowColors();
            dataGridView1.Enabled = true;
        }
    }
}
