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
    public static class TarjetaDAO
    {
        /// <summary>
        /// Registra una tarjeta de credito
        /// </summary>
        /// <param name="tarjeta"></param>
        public static void Save(TarjetaCreditoDTO tarjeta)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SaveTarjeta]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@paramNro", tarjeta.Numero);
                com.Parameters.AddWithValue("@paramCodigo", tarjeta.Codigo);
                com.Parameters.AddWithValue("@paramFechaVencimiento", tarjeta.FechaVencimiento);
                com.Parameters.AddWithValue("@paramTipoTarjeta", tarjeta.TipoTarjeta.IdTipoTarjeta);
                com.ExecuteNonQuery();
            }
        }
    }
}
