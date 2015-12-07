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
                com.Parameters.Add("@paramPrecio", SqlDbType.Int).Direction = ParameterDirection.Output;
                com.Parameters.AddWithValue("@paramPrecio", unPasaje.Precio);
                com.Parameters.AddWithValue("@paramPasajero", unPasaje.Pasajero.IdCliente);
                com.Parameters.AddWithValue("@paramCompra", unPasaje.Compra.IdCompra);
                com.Parameters.AddWithValue("@paramButaca", unPasaje.Butaca.IdButaca);

                com.ExecuteNonQuery();

                decimal precioPasaje = Convert.ToDecimal(com.Parameters["@paramPrecio"].Value);

                PasajeDTO retValue = new PasajeDTO();
                retValue.Precio = precioPasaje;

                return retValue;
            }
        }
    }
}
