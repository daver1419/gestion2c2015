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
                SqlParameter outPutPNR = new SqlParameter("@paramPNR", SqlDbType.NVarChar, 255) { Direction=ParameterDirection.Output};
                com.Parameters.Add(outPutPNR);
                SqlParameter outPutIdCompra = new SqlParameter("@paramIdCompra", SqlDbType.Int) { Direction = ParameterDirection.Output };
                com.Parameters.Add(outPutIdCompra);

                com.Parameters.AddWithValue("@paramComprador", compra.Comprador.IdCliente);
                com.Parameters.AddWithValue("@paramMedioPago",compra.MedioPago.IdTipoPago);
                com.Parameters.AddWithValue("@paramTarjeta",compra.TarjetaCredito.Numero);
                com.Parameters.AddWithValue("@paramViaje",compra.Viaje.Id);
                com.ExecuteNonQuery();

                CompraDTO retValue = new CompraDTO();
                retValue.PNR = (string)outPutPNR.Value;
                retValue.IdCompra = (int)outPutIdCompra.Value;

                return retValue;
            }
        }
    }
}
