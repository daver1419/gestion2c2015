using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;

namespace AerolineaFrba.DAO
{
    public class TipoButacaDAO
    {
        private static List<TipoButacaDTO> readerToListTipoButaca(SqlDataReader dataReader)
        {
            List<TipoButacaDTO> listaTipoServicio = new List<TipoButacaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TipoButacaDTO tb = new TipoButacaDTO();
                    tb.IdTipoButaca = Convert.ToInt32(dataReader["Id"]);
                    tb.Descripcion = Convert.ToString(dataReader["Descripcion"]);

                    listaTipoServicio.Add(tb);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaTipoServicio;
        }

        public static List<TipoButacaDTO> selectAll()
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                using (SqlCommand com = new SqlCommand("SELECT TB.Id,TB.Descripcion FROM [NORMALIZADOS].Tipo_Butaca TB", conn))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    List<TipoButacaDTO> tb = readerToListTipoButaca(reader);
                    return tb;
                }
            }
        }
    }
}
