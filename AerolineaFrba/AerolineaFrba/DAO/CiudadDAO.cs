using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AerolineaFrba.DTO;
using System.Windows.Forms;

namespace AerolineaFrba.DAO
{
    public static class CiudadDAO
    {
        public static bool CrearCiudad(CiudadDTO ciudad)
        { 
            int retValue;

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                    SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Alta_Ciudad]", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@descripcion", ciudad.Descripcion);

                     retValue=com.ExecuteNonQuery();
            }
            return retValue>0;
        }
        public static bool Exist(CiudadDTO ciudad)
        {

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[ExistCiudad_SEL_ByDescr]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@descripcion", ciudad.Descripcion);

                return com.ExecuteReader().HasRows;
            }
        }
        private static List<CiudadDTO> getCiudades(SqlDataReader dataReader)
        {
            List<CiudadDTO> ListaCiudades = new List<CiudadDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    CiudadDTO ciudad = new CiudadDTO();

                    ciudad.IdCiudad = Convert.ToInt32(dataReader["Id"]);
                    ciudad.Descripcion = Convert.ToString(dataReader["Nombre"]);

                    ListaCiudades.Add(ciudad);
                }
                dataReader.Close();
                dataReader.Dispose();
                
            }
            return ListaCiudades;
        }
        public static List<CiudadDTO> GetByDescripcion(CiudadDTO ciudad)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetCiudad_SEL_ByDescr]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@descripcion", ciudad.Descripcion);
                SqlDataReader dataReader = com.ExecuteReader();
                return getCiudades(dataReader);
            }
        }
        public static bool Actualizar(CiudadDTO ciudad)
        { 
            int retValue;

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                    SqlCommand com = new SqlCommand("[NORMALIZADOS].[ActualizarCiudad_UPD_ById]", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", ciudad.IdCiudad);
                    com.Parameters.AddWithValue("@nombre", ciudad.Descripcion);

                     retValue=com.ExecuteNonQuery();
            }
            return retValue>0;
        }
    }
}
