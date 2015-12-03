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
    public class MillasDAO
    {
        MillasDAO()
        {
        }

        public static DataTable AeronavesConMasDiasFueraServicio(int Anio, int Trimestre)
        {
            string llamado = "SELECT * FROM [NORMALIZADOS].[](" + Convert.ToString(Anio) + "," + Convert.ToString(Trimestre) + ")";
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
