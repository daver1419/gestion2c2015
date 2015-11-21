using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;
using AerolineaFrba.Conexion;

namespace AerolineaFrba.DAO
{
    public class FabricanteDAO
    {
        private static List<FabricanteDTO> readerToListFabricante(SqlDataReader dataReader)
        {
            List<FabricanteDTO> listaFabs = new List<FabricanteDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    FabricanteDTO fab = new FabricanteDTO();
                    fab.IdFabricante = Convert.ToInt32(dataReader["Id"]);
                    fab.Nombre = Convert.ToString(dataReader["Nombre"]);

                    listaFabs.Add(fab);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaFabs;
        }

        public static List<FabricanteDTO> selectAll()
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                using (SqlCommand com = new SqlCommand("SELECT F.Id,F.Nombre FROM [NORMALIZADOS].Fabricante F", conn))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    List<FabricanteDTO> fabricantes = readerToListFabricante(reader);
                    return fabricantes;
                }
            }
        }
    }
}
