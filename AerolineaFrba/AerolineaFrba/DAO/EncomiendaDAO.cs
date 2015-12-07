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
    public static class EncomiendaDAO
    {
        /// <summary>
        /// Registra una encomienda
        /// </summary>
        /// <param name="unaEncomienda"></param>
        /// <returns></returns>
        public static EncomiendaDTO Save(EncomiendaDTO unaEncomienda)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SavePasaje]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@paramPrecio", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("@paramPrecio", unaEncomienda.Precio);
                com.Parameters.AddWithValue("@paramKg", unaEncomienda.Kg);
                com.Parameters.AddWithValue("@paramCompra", unaEncomienda.Compra.IdCompra);
                com.Parameters.AddWithValue("@paramCliente", unaEncomienda.Cliente.IdCliente);

                com.ExecuteNonQuery();

                decimal precioPasaje = Convert.ToDecimal(com.Parameters["@paramPrecio"].Value);

                EncomiendaDTO retValue = new EncomiendaDTO();
                retValue.Precio = precioPasaje;

                return retValue;
            }
        }
    }
}
