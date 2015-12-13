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
    public static class PasajeDAO
    {
        public static PasajeDTO Save(PasajeDTO unPasaje)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SavePasaje]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter outPutPrecio = new SqlParameter("@paramPrecio", SqlDbType.Money) { Direction = ParameterDirection.Output };
                com.Parameters.Add(outPutPrecio);
                com.Parameters.AddWithValue("@paramPasajero", unPasaje.Pasajero.IdCliente);
                com.Parameters.AddWithValue("@paramCompra", unPasaje.Compra.IdCompra);
                com.Parameters.AddWithValue("@paramButaca", unPasaje.Butaca.IdButaca);
                com.ExecuteNonQuery();

                PasajeDTO retValue = new PasajeDTO();
                retValue.Precio = (decimal)outPutPrecio.Value;

                return retValue;
            }
        }
        /// <summary>
        /// Cancela un pasaje
        /// </summary>
        /// <param name="unPasaje"></param>
        /// <returns></returns>
        public static bool Cancelar(PasajeDTO unPasaje, DetalleCancelacionDTO unDetalle)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[Cancelar_Pasaje]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@codigo", unPasaje.Codigo);
                com.Parameters.AddWithValue("@motivo", unDetalle.IdCancelacion);

                return com.ExecuteNonQuery() > 0;

            }
        }
    }
}
