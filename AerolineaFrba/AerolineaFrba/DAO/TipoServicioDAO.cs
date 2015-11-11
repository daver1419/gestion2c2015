using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;

namespace AerolineaFrba.DAO
{
    class TipoServicioDAO
    {
        private static List<TipoServicioDTO> readerToListTipoServicio(SqlDataReader dataReader)
        {
            List<TipoServicioDTO> listaFunc = new List<TipoServicioDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TipoServicioDTO ts = new TipoServicioDTO();
                    ts.IdTipoServicio = Convert.ToInt32(dataReader["Id"]);
                    ts.Descripcion = Convert.ToString(dataReader["Descripcion"]);

                    listaFunc.Add(ts);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaFunc;
        }

        public static List<TipoServicioDTO> selectAll()
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                using (SqlCommand com = new SqlCommand("SELECT TS.Id,TS.Descripcion FROM [NORMALIZADOS].Servicio TS", conn))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    List<TipoServicioDTO> ts = readerToListTipoServicio(reader);
                    return ts;
                }
            }
        }
    }
}
