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
        /// <summary>
        /// Registra un viaje
        /// </summary>
        /// <param name="viaje"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Vuelca un dataReader en una lista de Viajes
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static List<GridViajesDTO> getViajes(SqlDataReader dataReader)
        {
            List<GridViajesDTO> ListaViajes = new List<GridViajesDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    GridViajesDTO viaje = new GridViajesDTO();

                    viaje.IdViaje = Convert.ToInt32(dataReader["Id"]);
                    viaje.FechaSalida = Convert.ToDateTime(dataReader["Fecha_Salida"]);
                    viaje.FechaLlegadaEstimada = Convert.ToDateTime(dataReader["Fecha_Llegada_Estimada"]);
                    viaje.IdRuta = Convert.ToInt32(dataReader["Ruta_Aerea"]);
                    viaje.DescrCiudadOrigen=Convert.ToString(dataReader["CiudadOrigenNombre"]);
                    viaje.DescrCiudadDest = Convert.ToString(dataReader["CiudadDestinoNombre"]);
                    viaje.NumeroAeronave=Convert.ToInt32(dataReader["Aeronave"]);
                    viaje.MatriculaAeronave = Convert.ToString(dataReader["Matricula"]);
                    viaje.DescrServicio = Convert.ToString(dataReader["Descripcion"]);
                    viaje.IdTipoServicio = Convert.ToInt32(dataReader["Tipo_Servicio"]);
                    viaje.KgsDisponibles =Convert.ToInt32( dataReader["KGs_Disponibles"]);
                    viaje.CantButacasDisp = Convert.ToInt32(dataReader["CantButacasDisponibles"]);

                    ListaViajes.Add(viaje);
                }
                dataReader.Close();
                dataReader.Dispose();

            }
            return ListaViajes;
        }
        /// <summary>
        /// Devuelve una lista de viajes a partir de la fecha de salida,
        /// fecha de llegada estimada, ciudad de origen y destino
        /// </summary>
        /// <param name="viaje"></param>
        /// <returns></returns>
        public static List<GridViajesDTO> GetByFechasCiudadesOrigenDestino(ViajeDTO viaje)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetViajes_SEL_ByFechasCiudades]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@paramFechaSalida", viaje.FechaSalida);
                com.Parameters.AddWithValue("@paramFechaLlegadaEstimada", viaje.FechaLlegadaEstimada);
                com.Parameters.AddWithValue("@paramCiudadOrigen", viaje.Ruta.CiudadOrigen.IdCiudad);
                com.Parameters.AddWithValue("@paramCiudadDestino", viaje.Ruta.CiudadDestino.IdCiudad);
                SqlDataReader dataReader = com.ExecuteReader();
                return getViajes(dataReader);
            }
        }
        /// <summary>
        /// Devuelve true si ya existe un viaje con la misma aeronave,ruta y fechas
        /// de salida y llegada estimada
        /// </summary>
        /// <param name="viaje"></param>
        /// <returns></returns>
        public static bool Exist(ViajeDTO viaje)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[ExistViaje]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@paramFechaSalida", viaje.FechaSalida);
                com.Parameters.AddWithValue("@paramFechaLlegadaEstimada", viaje.FechaLlegadaEstimada);
                com.Parameters.AddWithValue("@paramNroAeronave",viaje.Aeronave.Numero);
                return com.ExecuteReader().HasRows;
            }
        }
    }
}
