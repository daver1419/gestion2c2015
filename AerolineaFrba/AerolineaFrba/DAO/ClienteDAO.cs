using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data.SqlClient;
using System.Data;

namespace AerolineaFrba.DAO
{
    public static class ClienteDAO
    {
        /// <summary>
        /// Metodo que carga el contenido de dataReader con clientes
        /// en una lista
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        private static List<ClienteDTO> getClientes(SqlDataReader dataReader)
        {
            List<ClienteDTO> ListaClientes = new List<ClienteDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    ClienteDTO cliente = new ClienteDTO();

                    cliente.IdCliente = Convert.ToInt32(dataReader["Id"]);
                    cliente.Dni = Convert.ToInt32(dataReader["Dni"]);
                    cliente.Nombre = Convert.ToString(dataReader["Nombre"]);
                    cliente.Apellido = Convert.ToString(dataReader["Apellido"]);
                    cliente.Direccion = Convert.ToString(dataReader["Direccion"]);
                    cliente.Mail = Convert.ToString(dataReader["Mail"]);
                    cliente.Telefono = Convert.ToInt32(dataReader["Telefono"]);
                    cliente.Fecha_Nac = Convert.ToDateTime(dataReader["Fecha_Nac"]);

                    ListaClientes.Add(cliente);
                }
                dataReader.Close();
                dataReader.Dispose();
            }
            return ListaClientes;
        }
        /// <summary>
        /// Devuelve un cliente a traves de un DNI
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public static ClienteDTO GetByDNI(ClienteDTO cliente)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetCliente_SEL_ByDNI]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@paramDNI", cliente.Dni);

                SqlDataReader dataReader = com.ExecuteReader();
                return getClientes(dataReader).FirstOrDefault();
            }
        }
    }
}
