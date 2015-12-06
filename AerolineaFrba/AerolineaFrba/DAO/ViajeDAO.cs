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
        public static List<ViajeDTO> getViajes(SqlDataReader dataReader)
        {
            List<ViajeDTO> ListaViajes = new List<ViajeDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ViajeDTO viaje = new ViajeDTO();

                    viaje.FechaSalida = Convert.ToDateTime(dataReader["Fecha_Salida"]);
                    viaje.FechaLlegadaEstimada = Convert.ToDateTime(dataReader["Fecha_Llegada_Estimada"]);
                    CiudadDTO ciudadOrigen= new CiudadDTO();
                    ciudadOrigen.Descripcion=Convert.ToString(dataReader["CiudadOrigenNombre"]);
                    CiudadDTO ciudadDestino = new CiudadDTO();
                    ciudadDestino.Descripcion = Convert.ToString(dataReader["CiudadDestinoNombre"]);
                    RutaDTO ruta=new RutaDTO();
                    ruta.IdRuta=Convert.ToInt32(dataReader["Ruta_Aerea"]);
                    ruta.CiudadOrigen=ciudadOrigen;
                    ruta.CiudadDestino=ciudadDestino;
                    viaje.Ruta = ruta;
                    AeronaveDTO aeronave=new AeronaveDTO();
                    aeronave.Numero=Convert.ToInt32(dataReader["Aeronave"]);
                    aeronave.KG = Convert.ToInt32(dataReader["KgDisponibles"]);
                    TipoServicioDTO servicio = new TipoServicioDTO();
                    servicio.Descripcion = Convert.ToString(dataReader["Servicio"]);
                    aeronave.TipoServicio = servicio;
                    viaje.Aeronave = aeronave;

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
        public static List<ViajeDTO> GetByFechasCiudadesOrigenDestino(ViajeDTO viaje)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetRutaByFilters]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@paramFechaSalida", viaje.FechaSalida);
                com.Parameters.AddWithValue("@paramFechaLlegadaEstimada", viaje.FechaLlegadaEstimada);
                com.Parameters.AddWithValue("@paramCiudadOrigen", viaje.Ruta.CiudadOrigen);
                com.Parameters.AddWithValue("@paramCiudadDestino", viaje.Ruta.CiudadDestino);
                SqlDataReader dataReader = com.ExecuteReader();
                return getViajes(dataReader);

            }
        }
    }
}
