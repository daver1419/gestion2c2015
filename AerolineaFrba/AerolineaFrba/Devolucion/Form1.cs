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

namespace AerolineaFrba.Devolucion
{
    public partial class Form1 : Form
    {
        private List<PasajeDTO> listaPasajes;
        private CompraDTO compra;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<PasajeDTO> lista = new List<PasajeDTO>();
            this.listaPasajes = lista;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxPnr.Text = "";
            this.dataGridView1.DataSource = null;
            this.textBoxCodigo.Text = "";
            this.textBoxKgs.Text = "";
            this.textBoxPrecio.Text = "";
            errorProvider1.Clear();
            this.listaPasajes.Clear();
        }
        private bool validarCampos()
        {
            this.errorProvider1.Clear();
            bool retValue = true;
            
            if (this.textBoxPnr.Text == "")
            {
                retValue = false;
                errorProvider1.SetError(this.textBoxPnr,"Ingresar PNR");
            }
            if(!Utility.esNumero(this.textBoxPnr))
            {
                retValue = false;
                errorProvider1.SetError(this.textBoxPnr,"Solo se admiten numeros");
            }
            return retValue;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.listaPasajes.Clear();
            this.textBoxCodigo.Text = "";
            this.textBoxKgs.Text = "";
            this.textBoxPrecio.Text = "";

            if (validarCampos())
            { 
                CompraDTO compra = new CompraDTO();
                compra.PNR =this.textBoxPnr.Text;
                this.dataGridView1.DataSource = CompraDAO.GetPasajesByPnr(compra);
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                EncomiendaDTO unaEncomienda = new EncomiendaDTO();
                this.compra = compra;
                unaEncomienda = CompraDAO.GetEncomiendaByPnr(this.compra);
                if (unaEncomienda != null)
                {
                    this.textBoxCodigo.Text = unaEncomienda.Codigo.ToString();
                    this.textBoxKgs.Text = unaEncomienda.Kg.ToString();
                    this.textBoxPrecio.Text = unaEncomienda.Precio.ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Ignora los clicks que no son sobre los elementos de la columna de botones
            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns.IndexOf(dataGridView1.Columns["ColumnSel"]))
                return;
            if (!String.IsNullOrEmpty(textBoxMot.Text))
            {
                PasajeDTO unPasaje = (PasajeDTO)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                if (listaPasajes.Contains(unPasaje))
                {
                    listaPasajes.Remove(unPasaje);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    return;
                }
                else
                {
                    listaPasajes.Add(unPasaje);
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            else
            {
                errorProvider1.SetError(textBoxMot, "Ingrese un motivo");
            }
        }

        private bool validarCargaEncomienda()
        {
            bool retValue = true;

            if (string.IsNullOrEmpty(textBoxCodigo.Text) ||
                string.IsNullOrEmpty(textBoxKgs.Text) ||
                string.IsNullOrEmpty(textBoxPrecio.Text))
            {
                retValue = false;
                errorProvider1.SetError(textBoxCodigo, "Debe estar cargada la encomienda con los 3 campos");
            }
            return retValue;
        }
        private bool validarCargaDatos()
        {
            bool retValue = true;
            
            if (string.IsNullOrEmpty(textBoxMot.Text))
            {
                retValue = false;
                errorProvider1.SetError(textBoxMot, "Ingrese un motivo");
            }
            return retValue && validarCargaEncomienda();
        }

        private void buttonCancEnco_Click(object sender, EventArgs e)
        {
            if (validarCargaDatos())
            {
                DetalleCancelacionDTO unDetalle = new DetalleCancelacionDTO();
                EncomiendaDTO encomienda = new EncomiendaDTO();
                encomienda.Codigo =Convert.ToInt32( textBoxCodigo.Text);
                encomienda.Precio =Convert.ToDecimal( textBoxPrecio.Text);
                encomienda.Kg = Convert.ToInt32(textBoxKgs.Text);
                unDetalle=DetalleCancelacionDAO.Save(this.textBoxMot.Text);

                if (EncomiendaDAO.Cancelar(encomienda,unDetalle))
                {
                    MessageBox.Show("Se cancelo la encomienda con exito");
                    this.textBoxCodigo.Text = "";
                    this.textBoxKgs.Text = "";
                    this.textBoxPrecio.Text = "";
                    this.textBoxMot.Text = "";
                }
                else
                {
                    MessageBox.Show("No se pudo cancelar la encomienda");
                }
            }
        }

        private void buttonCancTodo_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (!String.IsNullOrEmpty(textBoxMot.Text))
                {
                    CompraDTO compra=new CompraDTO();
                    compra.PNR=textBoxPnr.Text;
                    if (CompraDAO.Cancelar(compra, this.textBoxMot.Text))
                    {
                        MessageBox.Show("Se produjo la cancelacion total de la compra con exito");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cancelar la compra de forma total");
                    }
                    this.Close();
                }
                else
                {
                    errorProvider1.SetError(textBoxMot,"Ingrese un motivo");
                }
            }
        }

        private void buttonCancelPasajes_Click(object sender, EventArgs e)
        {
            if (this.listaPasajes.Count > 0)
            {
                DetalleCancelacionDTO unDetalle = new DetalleCancelacionDTO();
                unDetalle = DetalleCancelacionDAO.Save(this.textBoxMot.Text);
                foreach (PasajeDTO unPasaje in this.listaPasajes)
                {
                    PasajeDAO.Cancelar(unPasaje, unDetalle);
                }
                MessageBox.Show("Los pasajes  se cancelaron exitosamente");
                this.dataGridView1.DataSource = CompraDAO.GetPasajesByPnr(this.compra);
                this.textBoxMot.Text = "";
            }
            else
            {
                MessageBox.Show("Debe ingresar al menos un pasaje para cancelar");
            }
        }
    }
}
