using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AerolineaFrba.DTO;

namespace AerolineaFrba.DAO
{
    class RolxFuncDAO
    {
        public static bool insertarRolxFuncionalidad(RolxFuncDTO rolxfun)
        {
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                int retornoExecuteNonQuery;
                //Creo el comand para recuperar el proximo idRol
                SqlCommand com = new SqlCommand(string.Format("SELECT TOP 1 R.Id FROM [NORMALIZADOS].Rol R ORDER BY R.Id DESC"), Conn);
                //Recupero el ultimo idRol y le sumo 1
                rolxfun.rol = int.Parse(string.Format("{0}", com.ExecuteScalar()));
                //Command para insertar un Rol por Funcionalidad
                SqlCommand comandCliente = new SqlCommand(string.Format("INSERT INTO [NORMALIZADOS].RolxFuncionalidad(Rol, Funcionalidad)VALUES('{0}','{1}')", rolxfun.rol, rolxfun.funcionalidad), Conn);
                retornoExecuteNonQuery = comandCliente.ExecuteNonQuery();
                Conn.Close();
                return retornoExecuteNonQuery > 0;
            }
        }

        public static bool delete(int rol, int fun)
        {
            int retorno = 0;
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("DELETE [NORMALIZADOS].RolxFuncionalidad WHERE Rol = {0} AND Funcionalidad = {1}", rol, fun), Conn);
                retorno = Comando.ExecuteNonQuery();
                return retorno > 0;
            }
        }
    }
}
