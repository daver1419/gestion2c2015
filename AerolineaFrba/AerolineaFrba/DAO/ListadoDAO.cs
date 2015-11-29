using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AerolineaFrba.DAO
{
    class ListadoDAO
    {

        public static DataTable DestinosConMasPasajes(int Anio, int Trimestre)
        {
            string llamado = "SELECT * FROM [NORMALIZADOS].[TOP5_Destinos_Con_Mas_Pasajes](" + Convert.ToString(Anio) + "," + Convert.ToString(Trimestre) + ")";
            return llamarTRF(llamado);
        }

        public static DataTable DestionsConMasAeronavesVacias(int Anio, int Trimestre)
        {
            string llamado = "SELECT * FROM [NORMALIZADOS].[TOP5_Destinos_Con_Aeronaves_Mas_Vacias](" + Convert.ToString(Anio) + "," + Convert.ToString(Trimestre) + ")";
            return llamarTRF(llamado);
        }

        public static DataTable ClientesConMasPuntos(int Anio, int Trimestre)
        {
            string llamado = "SELECT * FROM [NORMALIZADOS].[TOP5_Clientes_Puntos_a_la_Fecha](" + Convert.ToString(Anio) + "," + Convert.ToString(Trimestre) + ")";
            return llamarTRF(llamado);
        }

        public static DataTable DestinosConMasPasajesCancelados(int Anio, int Trimestre)
        {
            string llamado = "SELECT * FROM [NORMALIZADOS].[TOP5_Destinos_Pasajes_Cancelados](" + Convert.ToString(Anio) + "," + Convert.ToString(Trimestre) + ")";
            return llamarTRF(llamado);
        }

        public static DataTable AeronavesConMasDiasFueraServicio(int Anio, int Trimestre)
        {
            string llamado = "SELECT * FROM [NORMALIZADOS].[TOP5_Aeronaves_Dias_Fuera_De_Servicio](" + Convert.ToString(Anio) + "," + Convert.ToString(Trimestre) + ")";
            return llamarTRF(llamado);
        }

        private static DataTable llamarTRF(string llamado)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlDataAdapter da = new SqlDataAdapter(llamado, Conn);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                da.Fill(dt);
                return dt;
            }
        }
    }
}
