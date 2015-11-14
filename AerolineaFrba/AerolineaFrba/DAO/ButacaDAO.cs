using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba.DAO
{
    class ButacaDAO
    {
        public static void AltaButaca(ButacaDTO Butaca, SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Alta_Butaca]", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Transaction = tran;
            com.Parameters.AddWithValue("@Aeronave", Butaca.Aeronave);
            com.Parameters.AddWithValue("@Numero", Butaca.Numero);
            com.Parameters.AddWithValue("@Piso", Butaca.Piso);
            com.Parameters.AddWithValue("@Tipo_Butaca", Butaca.Tipo_Butaca.IdTipoButaca);
            com.ExecuteNonQuery();
        }
    }
}
