using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AerolineaFrba.DTO;

namespace AerolineaFrba.DAO
{
    public static class RegistroLlegadaDestinoDAO
    {
        /// <summary>
        /// Registra la llegada a destino
        /// </summary>
        /// <param name="aeronave"></param>
        /// <param name="fechaLlegada"></param>
        /// <param name="ciudadOrigen"></param>
        /// <param name="AeropuertoDestino"></param>
        /// <returns></returns>
        public static bool Save(AeronaveDTO aeronave,CiudadDTO ciudadOrigen,CiudadDTO AeropuertoDestino,DateTime fechaLlegada)
        {
            int retValue = 0;
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SaveRegistroLlegadaDestino]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@paramMatricula", aeronave.Matricula);
                comm.Parameters.AddWithValue("@paramAeropuertoDestino", AeropuertoDestino.IdCiudad);
                comm.Parameters.AddWithValue("@paramCiudadOrigen", ciudadOrigen.IdCiudad);
                comm.Parameters.AddWithValue("@paramFechaLlegada", fechaLlegada);
                retValue = comm.ExecuteNonQuery();
            }
            return retValue > 0;
        }
        /// <summary>
        /// Devuelve true si la aeronave arribo correctamente
        /// </summary>
        /// <param name="aeronave"></param>
        /// <param name="ciudadOrigen"></param>
        /// <param name="aeropDestino"></param>
        /// <returns></returns>
        public static bool ArriboCorrectamente(AeronaveDTO aeronave,CiudadDTO ciudadOrigen ,CiudadDTO aeropDestino)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SP_Arribo_OK]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@paramNroAeronave", aeronave.Numero);
                comm.Parameters.AddWithValue("@paramCiudadOrigen", ciudadOrigen.IdCiudad);
                comm.Parameters.AddWithValue("@paramAeropuertoDestino", aeropDestino.IdCiudad);
                return comm.ExecuteReader().HasRows;
            }
        }
    }
}
