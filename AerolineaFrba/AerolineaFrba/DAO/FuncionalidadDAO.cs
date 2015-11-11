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
    public static class FuncionalidadDAO
    {
        private static List<FuncionalidadDTO> readerToListFunc(SqlDataReader dataReader)
        {
            List<FuncionalidadDTO> listaFunc = new List<FuncionalidadDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    FuncionalidadDTO func = new FuncionalidadDTO();
                    func.IdFuncionalidad = Convert.ToInt32(dataReader["Id"]);
                    func.Descripcion = Convert.ToString(dataReader["Descripcion"]);

                    listaFunc.Add(func);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaFunc;
        }

        public static List<FuncionalidadDTO> selectByRol(RolDTO rol)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                using (SqlCommand com = new SqlCommand("SELECT F.Id,F.Descripcion FROM [NORMALIZADOS].Funcionalidad F JOIN [NORMALIZADOS].RolxFuncionalidad RxF ON RxF.Funcionalidad=F.Id AND RxF.Rol=" + rol.IdRol, conn))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    List<FuncionalidadDTO> funcionalidades = readerToListFunc(reader);
                    return funcionalidades;
                }
            }
        }
    }
}
