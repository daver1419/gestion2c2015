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
    public static class TipoTarjetaDAO
    {
        private static List<TipoTarjetaDTO> getTipoTarjetas(SqlDataReader dataReader)
        {
            List<TipoTarjetaDTO> ListaTarjetas = new List<TipoTarjetaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TipoTarjetaDTO tipoTarjeta = new TipoTarjetaDTO();

                    tipoTarjeta.IdTipoTarjeta= Convert.ToInt32(dataReader["Id"]);
                    tipoTarjeta.Nombre = Convert.ToString(dataReader["Nombre"]);
                    tipoTarjeta.NumeroCuotas = Convert.ToInt32(dataReader["Numero_Cuotas"]);

                    ListaTarjetas.Add(tipoTarjeta);
                }
                dataReader.Close();
                dataReader.Dispose();
            }
            return ListaTarjetas;
        }

        public static List<TipoTarjetaDTO> GetAll()
        {
            List<TipoTarjetaDTO> listaTarjetas;

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetAllTipoTarjeta_SEL]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                listaTarjetas = getTipoTarjetas(reader);
            }
            return listaTarjetas;
        }
    }
}
