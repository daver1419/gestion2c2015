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
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SaveEncomienda]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter outPutPrecio = new SqlParameter("@paramPrecio", SqlDbType.Money) { Direction = ParameterDirection.Output };
                com.Parameters.Add(outPutPrecio);
                com.Parameters.AddWithValue("@paramKg", unaEncomienda.Kg);
                com.Parameters.AddWithValue("@paramCompra", unaEncomienda.Compra.IdCompra);
                com.Parameters.AddWithValue("@paramCliente", unaEncomienda.Cliente.IdCliente);
                com.ExecuteNonQuery();

                EncomiendaDTO retValue = new EncomiendaDTO();
                retValue.Precio = (decimal)outPutPrecio.Value;

                return retValue;
            }
        }
    }
}
