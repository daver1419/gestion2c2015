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
            com.Parameters.AddWithValue("@Habilitada", Butaca.Habilitada);
            com.ExecuteNonQuery();
        }

        public static void ModificarButaca(ButacaDTO Butaca, SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Modificar_Butaca]", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Transaction = tran;
            com.Parameters.AddWithValue("@Numero", Butaca.Numero);
            com.Parameters.AddWithValue("@Id", Butaca.IdButaca);
            com.Parameters.AddWithValue("@Piso", Butaca.Piso);
            com.Parameters.AddWithValue("@Tipo", Butaca.Tipo_Butaca.IdTipoButaca);
            com.Parameters.AddWithValue("@Habilitada", Butaca.Habilitada);
            com.ExecuteNonQuery();
        }

        public static bool delete(ButacaDTO butaca)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Baja_Butaca]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", butaca.IdButaca);
                return com.ExecuteNonQuery() > 0;
            }
        }

        private static List<ButacaDTO> getButacas(SqlDataReader dataReader)
        {
            List<ButacaDTO> ListaButacas = new List<ButacaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ButacaDTO butaca = new ButacaDTO();

                    butaca.Aeronave = Convert.ToInt32(dataReader["Aeronave"]);
                    butaca.IdButaca = Convert.ToInt32(dataReader["Id"]);
                    butaca.Numero = Convert.ToInt32(dataReader["Numero"]);
                    butaca.Piso = Convert.ToInt32(dataReader["Piso"]);
                    TipoButacaDTO tipoButaca = new TipoButacaDTO();
                    tipoButaca.IdTipoButaca = Convert.ToInt32(dataReader["Tipo_Butaca"]);
                    tipoButaca.Descripcion = Convert.ToString(dataReader["Descripcion"]);
                    butaca.Habilitada = Convert.ToBoolean(dataReader["Habilitada"]);
                    butaca.Tipo_Butaca = tipoButaca;

                    ListaButacas.Add(butaca);
                }
                dataReader.Close();
                dataReader.Dispose();

            }
            return ListaButacas;
        }

        public static List<ButacaDTO> GetByAeronave(AeronaveDTO aeronave)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Butacas_Aeronave]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Numero_Aeronave", aeronave.Numero);

                SqlDataReader dataReader = com.ExecuteReader();
                return getButacas(dataReader);
            }
        }
    }
}
