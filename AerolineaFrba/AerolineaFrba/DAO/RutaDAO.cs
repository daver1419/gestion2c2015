using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data;
using System.Data.SqlClient;
using AerolineaFrba.Conexion;

namespace AerolineaFrba.DAO
{
    public static class RutaDAO
    {
        /// <summary>
        /// verifica si para un codigo de ruta ya existente
		///arma correctamente el tramo con las otras rutas con mismo codigo
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static bool CheckRutaConMismoCodigo(RutaDTO ruta)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[CheckRutaConMismoCodigo]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@codigoRuta", ruta.Codigo);
                comm.Parameters.AddWithValue("@ciudadOrigen", ruta.CiudadOrigen.IdCiudad);
                comm.Parameters.AddWithValue("@ciudadDestino", ruta.CiudadDestino.IdCiudad);
                return comm.ExecuteReader().HasRows;
            }
        }
        /// <summary>
        /// Verifica si ya existe una ruta con el mismo codigo
        /// </summary>
        /// <param name="ruta"></param>
        public static bool ExistCodigoRuta(RutaDTO ruta)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[ExistCodigoRuta]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@codigoRuta", ruta.Codigo);
                return comm.ExecuteReader().HasRows;
            }
        }
        /// <summary>
        /// Verifica si existe una ruta con cierto codigo de ruta
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static bool ExistTuplaRuta(RutaDTO ruta)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[ExistTuplaRuta]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@ciudadOrigen", ruta.CiudadOrigen.IdCiudad);
                comm.Parameters.AddWithValue("@ciudadDestino", ruta.CiudadDestino.IdCiudad);
                comm.Parameters.AddWithValue("@tipoServicio", ruta.Servicio.IdTipoServicio);
                return comm.ExecuteReader().HasRows;
            }
        }
        /// <summary>
        /// Graba una ruta
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static bool Save(RutaDTO ruta)
        {
            int retValue = 0;
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SaveRuta]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@codigoRuta", ruta.Codigo);
                comm.Parameters.AddWithValue("@ciudadOrigen", ruta.CiudadOrigen.IdCiudad);
                comm.Parameters.AddWithValue("@ciudadDestino", ruta.CiudadDestino.IdCiudad);
                comm.Parameters.AddWithValue("@precioBasePasaje", ruta.PrecioBasePasaje);
                comm.Parameters.AddWithValue("@precioBaseKg", ruta.PrecioBaseKg);
                comm.Parameters.AddWithValue("@tipoServicio", ruta.Servicio.IdTipoServicio);
                retValue=comm.ExecuteNonQuery();
            }
            return retValue > 0;
        }
        /// <summary>
        /// Devuelve una lista de rutas a partir de un dataReader
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static List<RutaDTO> getRutas(SqlDataReader dataReader)
        {
            List<RutaDTO> ListaRutas = new List<RutaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RutaDTO ruta = new RutaDTO();

                    ruta.IdRuta = Convert.ToInt32(dataReader["Id"]);
                    CiudadDTO ciudadOrigen = new CiudadDTO();
                    ciudadOrigen.IdCiudad = Convert.ToInt32(dataReader["CiudadOrigenId"]);
                    ciudadOrigen.Descripcion = Convert.ToString(dataReader["CiudadOrigenNombre"]);
                    ruta.CiudadOrigen = ciudadOrigen;
                    CiudadDTO ciudadDestino = new CiudadDTO();
                    ciudadDestino.IdCiudad = Convert.ToInt32(dataReader["CiudadDestinoId"]);
                    ciudadDestino.Descripcion = Convert.ToString(dataReader["CiudadDestinoNombre"]);
                    ruta.CiudadOrigen = ciudadDestino;
                    ruta.Codigo = Convert.ToInt32(dataReader["Codigo"]);
                    ruta.PrecioBaseKg = Convert.ToInt32(dataReader["PrecioBaseKg"]);
                    ruta.PrecioBasePasaje = Convert.ToInt32(dataReader["PrecioBasePasaje"]);
                    TipoServicioDTO servicio = new TipoServicioDTO();
                    servicio.IdTipoServicio = Convert.ToInt32(dataReader["ServicioId"]);
                    servicio.Descripcion = Convert.ToString(dataReader["ServicioDescr"]);
                    ruta.Servicio = servicio;

                    ListaRutas.Add(ruta);
                }
                dataReader.Close();
                dataReader.Dispose();

            }
            return ListaRutas;
        }
        /// <summary>
        /// Devuelve una lista de rutas a partir de los filtros
        /// </summary>
        /// <param name="unaRuta"></param>
        /// <returns></returns>
        public static List<RutaDTO> GetByFilters(RutaDTO unaRuta)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetRutaByFilters]", conn);
                com.CommandType = CommandType.StoredProcedure;

                if (unaRuta.Codigo != null)
                    com.Parameters.AddWithValue("@codigo", unaRuta.Codigo);
                else
                    com.Parameters.AddWithValue("@codigo", DBNull.Value);

                if (unaRuta.CiudadOrigen != null)
                    com.Parameters.AddWithValue("@ciudadOrigen", unaRuta.CiudadOrigen.IdCiudad);
                else
                    com.Parameters.AddWithValue("@ciudadOrigen", DBNull.Value);

                if (unaRuta.CiudadDestino != null)
                    com.Parameters.AddWithValue("@ciudadDestino", unaRuta.CiudadDestino.IdCiudad);
                else
                    com.Parameters.AddWithValue("@ciudadDestino", DBNull.Value);

                if (unaRuta.Servicio != null)
                    com.Parameters.AddWithValue("@servicio", unaRuta.Servicio.IdTipoServicio);
                else
                    com.Parameters.AddWithValue("@servicio", DBNull.Value);

                if (unaRuta.PrecioBaseKg != null)
                    com.Parameters.AddWithValue("@precioBaseKg", unaRuta.PrecioBaseKg);
                else
                    com.Parameters.AddWithValue("@precioBaseKg", DBNull.Value);

                if (unaRuta.PrecioBasePasaje != null)
                    com.Parameters.AddWithValue("@precioBasePasaje", unaRuta.PrecioBasePasaje);
                else
                    com.Parameters.AddWithValue("@precioBasePasaje", DBNull.Value);

                SqlDataReader dataReader = com.ExecuteReader();
                return getRutas(dataReader);

            }
        }
        /// <summary>
        /// Modificar una ruta
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static bool Actualizar(RutaDTO ruta)
        {
            int retValue = 0;
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[ActualizarRuta]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@codigoRuta", ruta.Codigo);
                comm.Parameters.AddWithValue("@ciudadOrigen", ruta.CiudadOrigen.IdCiudad);
                comm.Parameters.AddWithValue("@ciudadDestino", ruta.CiudadDestino.IdCiudad);
                comm.Parameters.AddWithValue("@precioBasePasaje", ruta.PrecioBasePasaje);
                comm.Parameters.AddWithValue("@precioBaseKg", ruta.PrecioBaseKg);
                comm.Parameters.AddWithValue("@tipoServicio", ruta.Servicio.IdTipoServicio);
                retValue = comm.ExecuteNonQuery();
            }
            return retValue > 0;
        }
    }
}
