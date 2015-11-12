using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AerolineaFrba.Conexion;
using AerolineaFrba.DTO;
using System.Windows.Forms;

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

        //Crear rol
        public static bool insertarRol(RolDTO rol)
        {
            int retorno = 0;
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("INSERT INTO [NORMALIZADOS].Rol(Nombre, Activo)VALUES('{0}', '{1}')", rol.NombreRol, rol.Estado), Conn);
                retorno = Comando.ExecuteNonQuery();
                return retorno > 0;
            }
        }

        public static bool delete(RolDTO rol)
        {
            int retorno = 0;
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                foreach (FuncionalidadDTO fun in rol.ListaFunc)
                {
                    RolxFuncDAO.delete(rol.IdRol, fun.IdFuncionalidad);
                }
                SqlCommand Comando = new SqlCommand(string.Format("DELETE [NORMALIZADOS].Rol WHERE Id = {0}", rol.IdRol), Conn);
                retorno = Comando.ExecuteNonQuery();
                return retorno > 0;
            }
        }

        public static bool update(RolDTO rol)
        {
            int retorno = 0;
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("UPDATE [NORMALIZADOS].Rol SET Nombre = '{0}', Activo = '{1}' WHERE Id = {2}", rol.NombreRol, rol.Estado, rol.IdRol), Conn);
                retorno = Comando.ExecuteNonQuery();
                return retorno > 0;
            }
        }

        public static List<String> SelectAllString()
        {
            SqlConnection conn = Conexion.Conexion.obtenerConexion();
            SqlCommand com = new SqlCommand("SELECT R.Id, R.Nombre FROM [NORMALIZADOS].Rol R", conn);
            return ReaderToListRolString(com.ExecuteReader());
        }

        public static List<String> ReaderToListRolString(SqlDataReader reader)
        {
            List<String> lista = new List<String>();
            while (reader.Read())
            {
                String nombre = Convert.ToString(reader["Nombre"]);
                lista.Add(nombre);

            }
            reader.Close();
            reader.Dispose();
            return lista;

        }

        public static BindingSource getRoles(SqlDataReader dataReader)
        {
            List<RolDTO> ListaRoles = new List<RolDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RolDTO rol = new RolDTO();

                    rol.IdRol = Convert.ToInt32(dataReader["Id"]);
                    rol.Estado = Convert.ToBoolean(dataReader["Activo"]);
                    rol.NombreRol = Convert.ToString(dataReader["Nombre"]);

                    if (ListaRoles.Contains(rol))
                    {
                        RolDTO rol1 = ListaRoles.Find(delegate(RolDTO rolcito)
                        {
                            return rolcito.Equals(rol);
                        });

                        rol1.ListaFunc.Add(new FuncionalidadDTO(Convert.ToInt32(dataReader["Funcionalidad"]), Convert.ToString(dataReader["Descripcion"])));
                    }
                    else
                    {
                        rol.ListaFunc.Add(new FuncionalidadDTO(Convert.ToInt32(dataReader["Funcionalidad"]), Convert.ToString(dataReader["Descripcion"])));

                        ListaRoles.Add(rol);
                    }
                }
            }
            BindingSource bs = new BindingSource();

            foreach (RolDTO rol in ListaRoles)
            {
                bs.Add(rol);
            }
            dataReader.Close();
            dataReader.Dispose();
            return bs;
        }

        public static BindingSource getDataGrid(RolDTO rol)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                using (SqlCommand com = new SqlCommand(string.Format("SELECT R.Id, R.Nombre, R.Activo, RxF.Funcionalidad, F.Descripcion FROM [NORMALIZADOS].Rol R, [NORMALIZADOS].RolxFuncionalidad RxF, [NORMALIZADOS].Funcionalidad F WHERE R.Id = RxF.Rol AND RxF.Funcionalidad = F.Id AND R.Nombre = '{0}'", rol.NombreRol), conn))
                {
                    SqlDataReader dataReader = com.ExecuteReader();
                    return getRoles(dataReader);
                }
            }
        }

    }
}
