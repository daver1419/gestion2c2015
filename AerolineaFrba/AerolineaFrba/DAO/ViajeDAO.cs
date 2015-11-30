using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AerolineaFrba.DAO
{
    public static class ViajeDAO
    {
        public static bool Generar(ViajeDTO viaje)
        {
            int retValue=0;

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[GenerarViaje]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@fechaSalida", viaje.FechaSalida);
                comm.Parameters.AddWithValue("@fechaLlegadaEstimada", viaje.FechaLlegadaEstimada);
                comm.Parameters.AddWithValue("@rutaId", viaje.Ruta.IdRuta);
                comm.Parameters.AddWithValue("@nroAeronave", viaje.Aeronave.Numero);
                retValue= comm.ExecuteNonQuery();
            }
            return retValue > 0;
        }
    }
}
