using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;
using AerolineaFrba.DAO;

namespace AerolineaFrba.Login
{
    public class Sesion
    {
        private static RolDTO RolActual { get; set; }
        private static UsuarioDTO UsuarioActual;
        private static bool logued;

        private static UsuarioDTO DefaultUser()
        {
            return new UsuarioDTO()
            {
                Roles = new List<RolDTO>() { RolDAO.SelectById(1) }
            };
        }

        public static List<RolDTO> Roles
        {
            get { return Usuario.Roles; }
        }

        /// <summary>
        /// Rol seleccionado por el usuario.
        /// </summary>
        public static RolDTO Rol
        {
            get { if (RolActual == null) RolActual = Usuario.Roles[0]; return RolActual; }
            set
            {
                if (Roles.Contains(value))
                    RolActual = value;
                else
                    throw new ApplicationException("Intento de asignacion de rol no autorizado para el usuario.");
            }

        }

        public static UsuarioDTO Usuario
        {
            get
            {
                if (UsuarioActual == null) UsuarioActual = DefaultUser(); return UsuarioActual;
            }
        }

        public static bool Logued { get { return logued; } }


        public static void Login(string username, string password)
        {
            try
            {
                SHA256Managed crypt = new SHA256Managed();
                //string hash = String.Empty;
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
                /*
                foreach (byte bit in crypto)
                {
                    hash += bit.ToString("x2");
                }
                */
                using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
                {
                    SqlParameter returnValue = new SqlParameter() { Direction = ParameterDirection.ReturnValue };

                    SqlCommand com = new SqlCommand("[NORMALIZADOS].[Login]", conn);

                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Username", username);
                    com.Parameters.AddWithValue("@SHA256", crypto);
                    com.Parameters.Add(returnValue);

                    com.ExecuteScalar();

                    int id = Convert.ToInt32(returnValue.Value);

                    UsuarioDTO usuario = new UsuarioDTO() { ID_User = id, Username = username };

                    usuario.Roles = RolDAO.SelectByUser(usuario);

                    UsuarioActual = usuario;

                    Sesion.Rol = usuario.Roles.FirstOrDefault();

                    logued = true;

                }

            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) //Si es una exception que lancé yo.
                    throw new ApplicationException(ex.Message);
                else throw ex;
            }
        }

        public static void Logout()
        {
            logued = false;
            StartAsClient();
        }
        /*
        public static bool FuncionalidadHabilitada(ClaseFuncionalidad funcionalidad)
        {
            return RolActual.tienePermiso(funcionalidad);
        }
        */
        public static void Start(RolDTO rol)
        {
            if (rol == null)
                StartAsClient();
            else
                StartAsUser(rol);
        }

        public static void StartAsClient()
        {
            UsuarioActual = DefaultUser();
            RolActual = Roles[0];
        }

        public static void StartAsUser(RolDTO rol)
        {
            RolActual = rol;
        }

        public static void Reset_estado()
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Reset_Estado_Users]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.ExecuteNonQuery();
            }
        }

        public static void End()
        {
            //CERRAR CONEXION
        }
    }
}
