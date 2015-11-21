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
    }
}
