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

        public static List<FuncionalidadDTO> SelectAll()
        {
            SqlConnection conn = Conexion.Conexion.obtenerConexion();
            SqlCommand com = new SqlCommand("SELECT F.Id, Descripcion FROM [NORMALIZADOS].Funcionalidad F", conn);
            return readerToListFunc(com.ExecuteReader());
        }

        public static void InsertarFuncionalidades(List<FuncionalidadDTO> func, int rolId)
        {
            SqlConnection conn = Conexion.Conexion.obtenerConexion();
            foreach (FuncionalidadDTO fun in func)
            {
                SqlCommand com = new SqlCommand(string.Format("INSERT INTO [NORMALIZADOS].RolxFuncionalidad(Rol, Funcionalidad) VALUES ('{0}', '{1}')", rolId, fun.IdFuncionalidad), conn);
                com.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void RemoverFuncionalidades(List<FuncionalidadDTO> func, int rolId)
        {
            SqlConnection conn = Conexion.Conexion.obtenerConexion();
            foreach (FuncionalidadDTO fun in func)
            {
                SqlCommand com = new SqlCommand(string.Format("DELETE FROM [NORMALIZADOS].RolxFuncionalidad WHERE Funcionalidad = '{0}' AND Rol = '{1}'", fun.IdFuncionalidad, rolId), conn);
                com.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
