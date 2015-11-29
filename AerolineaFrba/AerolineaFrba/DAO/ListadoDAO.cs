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
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[TOP5_Destinos_Con_Mas_Pasajes]", Conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@Anio", SqlDbType.Int).Value = Anio;
                com.Parameters.Add("@Trimestre", SqlDbType.Int).Value = Trimestre;
                da.SelectCommand = com;
                da.Fill(dt);
                return dt;
            }
        }
    }
}
