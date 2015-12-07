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
    public static class CompraDAO
    {
        /// <summary>
        /// Registra una compra
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static CompraDTO Save(CompraDTO compra)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SaveCompra]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@C_PNR", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("@paramComprador", compra.Comprador.IdCliente);
                com.Parameters.AddWithValue("@paramMedioPago",compra.MedioPago.IdTipoPago);
                com.Parameters.AddWithValue("@paramTarjeta",compra.TarjetaCredito.Numero);
                com.Parameters.AddWithValue("@paramViaje",compra.Viaje.Id);

                com.ExecuteNonQuery();
                int PNR = Convert.ToInt32(com.Parameters["@C_PNR"].Value);

                CompraDTO retValue = new CompraDTO();
                retValue.PNR = PNR;

                return retValue;
            }
        }
    }
}
