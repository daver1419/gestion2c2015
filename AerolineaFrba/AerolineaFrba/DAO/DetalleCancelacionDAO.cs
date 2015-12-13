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
    public static class DetalleCancelacionDAO
    {
        /// <summary>
        /// Graba un detalle de cancelacion
        /// </summary>
        /// <param name="motivo"></param>
        /// <returns></returns>
        public static DetalleCancelacionDTO Save(string motivo)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[Crear_Detalle_Cancelacion]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter outPutIdCancelacion = new SqlParameter("@idCancelacion", SqlDbType.Int) { Direction = ParameterDirection.Output };
                com.Parameters.Add(outPutIdCancelacion);

                com.Parameters.AddWithValue("@motivo",motivo );
                com.ExecuteNonQuery();

                DetalleCancelacionDTO retValue = new DetalleCancelacionDTO();
                retValue.IdCancelacion = (int)outPutIdCancelacion.Value;

                return retValue;
            }
        }
    }
}
