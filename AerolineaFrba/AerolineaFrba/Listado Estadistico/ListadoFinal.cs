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

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class ListadoFinal : Form
    {
        private string Listado;
        private int Anio;
        private int Semestre;

        public ListadoFinal(int AnioElegido, int SemestreElegido, string ListadoElegido)
        {

            InitializeComponent();
            Listado = ListadoElegido;
            Anio = AnioElegido;
            Semestre = SemestreElegido;
        }

        private void ListadoFinal_Load(object sender, EventArgs e)
        {
            txtListadoFinal.Text = Listado;
            switch (Listado)
            {
                case "Top 5 de los destinos con más pasajes comprados":
                    gridListado.DataSource = ListadoDAO.DestinosConMasPasajes(Anio, Semestre);
                    //gridListado.Columns[1].Width = 230;
                    //gridListado.Columns[0].Width = 230;
                    break;

                case "Top 5 de los destinos con aeronaves más vacías":
                    gridListado.DataSource = ListadoDAO.DestionsConMasAeronavesVacias(Anio, Semestre);
                    //gridListado.Columns[1].Width = 230;
                    //gridListado.Columns[0].Width = 230;
                    break;

                case "Top 5 de los Clientes con más puntos acumulados a la fecha":
                    gridListado.DataSource = ListadoDAO.ClientesConMasPuntos(Anio, Semestre);
                    break;

                case "Top 5 de los destinos con pasajes cancelados":
                    gridListado.DataSource = ListadoDAO.DestinosConMasPasajesCancelados(Anio, Semestre);
                    break;

                case "Top 5 de las aeronaves con mayor cantidad de días fuera de servicio":
                    gridListado.DataSource = ListadoDAO.AeronavesConMasDiasFueraServicio(Anio, Semestre);
                    //gridListado.Columns[1].Width = 230;
                    //gridListado.Columns[0].Width = 230;
                    break;


            }
        }
    }
}
