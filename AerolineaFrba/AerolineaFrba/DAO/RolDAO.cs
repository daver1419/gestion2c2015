using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AerolineaFrba.Conexion;
using AerolineaFrba.DTO;

namespace AerolineaFrba.DAO
{
    public static class RolDAO
    {
        public static List<RolDTO> ReaderToListClaseRol(SqlDataReader dataReader)
        {
            List<RolDTO> listaRoles = new List<RolDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RolDTO rol = new RolDTO();
                    rol.IdRol = Convert.ToInt32(dataReader["Id"]);
                    rol.NombreRol = Convert.ToString(dataReader["Nombre"]);
                    rol.Estado = Convert.ToBoolean(dataReader["Activo"]);
                    rol.ListaFunc = FuncionalidadDAO.selectByRol(rol);

                    listaRoles.Add(rol);
                }
            }
            dataReader.Close();
            dataReader.Dispose();
            return listaRoles;

        }

        public static RolDTO SelectById(int Id)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("SELECT * FROM [NORMALIZADOS].Rol WHERE Id=" + Id, conn);
                SqlDataReader reader = com.ExecuteReader();
                List<RolDTO> Roles = ReaderToListClaseRol(reader);
                if (Roles.Count == 0) return null;
                return Roles[0];
            }
        }

        public static List<RolDTO> SelectByUser(UsuarioDTO usuario)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("SELECT R.Id,R.Nombre,R.Activo FROM [NORMALIZADOS].Usuario U JOIN [NORMALIZADOS].Rol R ON U.Rol=R.Id WHERE U.Id=" + usuario.ID_User, conn);
                SqlDataReader dataReader = com.ExecuteReader();
                return ReaderToListClaseRol(dataReader);
            }
        }
    }
}
