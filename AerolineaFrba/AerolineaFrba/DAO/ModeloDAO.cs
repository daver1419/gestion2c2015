using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;

namespace AerolineaFrba.DAO
{
    class ModeloDAO
    {
        private static List<ModeloDTO> readerToListModelo(SqlDataReader dataReader)
        {
            List<ModeloDTO> listaMods = new List<ModeloDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ModeloDTO mod = new ModeloDTO();
                    mod.Id = Convert.ToInt32(dataReader["Id"]);
                    mod.Modelo = Convert.ToString(dataReader["Modelo_Desc"]);

                    listaMods.Add(mod);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaMods;
        }

        public static List<ModeloDTO> selectAll()
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                using (SqlCommand com = new SqlCommand("SELECT M.Id, M.Modelo_Desc FROM [NORMALIZADOS].Modelo M", conn))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    List<ModeloDTO> modelos = readerToListModelo(reader);
                    return modelos;
                }
            }
        }
    }
}
