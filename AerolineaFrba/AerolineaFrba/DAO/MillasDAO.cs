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
    public class MillasDAO
    {
        MillasDAO()
        {
        }

        public static bool doCanje(int dni, int id, int cantidad)
        {
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SP_Canje_Millas]", Conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@dni", dni);
                comm.Parameters.AddWithValue("@producto", id);
                comm.Parameters.AddWithValue("@cantidad", cantidad);

                return comm.ExecuteNonQuery() > 0;
            }
        }

        public static string getMillas(string dni)
        {
            string Millas = "0";
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SP_Get_Millas_By_Dni]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@dni", dni);
                SqlDataReader dataReaderPuntos = comm.ExecuteReader();
                if (dataReaderPuntos.HasRows)
                {
                    while (dataReaderPuntos.Read())
                    {
                        Millas = Convert.ToString(dataReaderPuntos["Millas"]);
                    }
                }
            }
            return Millas;
        }

        public static List<RecompensaDTO> getRecompensas()
        {
            using (SqlConnection Conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Get_Recompensas]", Conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReaderRecompensas = com.ExecuteReader();

                return getRecompensasFromReader(dataReaderRecompensas);
            }
        }

        private static List<RecompensaDTO> getRecompensasFromReader(SqlDataReader dataReader)
        {
            List<RecompensaDTO> ListaRecompensas = new List<RecompensaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    RecompensaDTO Recompensa = new RecompensaDTO();

                    Recompensa.Id = Convert.ToInt32(dataReader["Id"]);
                    Recompensa.Descripcion = Convert.ToString(dataReader["Descripcion"]);
                    Recompensa.Stock = Convert.ToInt32(dataReader["Stock"]);
                    Recompensa.Millas = Convert.ToInt32(dataReader["Puntos"]);

                    ListaRecompensas.Add(Recompensa);
                }
                dataReader.Close();
                dataReader.Dispose();
            }
            return ListaRecompensas;
        }

        public static List<MillasDTO> getListadoMillas(string dni)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SP_Get_Detalle_Puntos_By_Dni]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@dni", dni);
                SqlDataReader dataReaderPuntos = comm.ExecuteReader();

                using (SqlConnection conn2 = Conexion.Conexion.obtenerConexion())
                {
                    SqlCommand comm2 = new SqlCommand("[NORMALIZADOS].[SP_Get_Canjes_By_Dni]", conn2);
                    comm2.CommandType = CommandType.StoredProcedure;
                    comm2.Parameters.AddWithValue("@dni", dni);
                    SqlDataReader dataReaderCanjes = comm2.ExecuteReader();

                    return getMillas(dataReaderPuntos, dataReaderCanjes);
                }
            }
        }

        private static List<MillasDTO> getMillas(SqlDataReader dataReaderPuntos, SqlDataReader dataReaderCanjes)
        {
            List<MillasDTO> ListadoMillas = new List<MillasDTO>();
            if (dataReaderPuntos.HasRows)
            {
                while (dataReaderPuntos.Read())
                {
                    MillasDTO millas = new MillasDTO();

                    //En caso de generar. creo que haria falta saber si es pasaje o encomienda
                    //porque el codigo podria repetirse de otro modo

                    millas.Pasaje_Encomienda = Convert.ToString(dataReaderPuntos["Codigo"]);
                    millas.Fecha = Convert.ToDateTime(dataReaderPuntos["Fecha_De_Compra"]);
                    millas.Origen = Convert.ToString(dataReaderPuntos["Origen"]);
                    millas.Destino = Convert.ToString(dataReaderPuntos["Destino"]);
                    millas.Millas = Convert.ToInt32(dataReaderPuntos["Puntos"]);
                    millas.Tipo_Row = 1;

                    ListadoMillas.Add(millas);
                }
                dataReaderPuntos.Close();
                dataReaderPuntos.Dispose();

            }

            if (dataReaderCanjes.HasRows)
            {
                while (dataReaderCanjes.Read())
                {
                    MillasDTO millas = new MillasDTO();

                    //En caso de canje

                    millas.Recompensa = Convert.ToString(dataReaderCanjes["Descripcion"]);
                    millas.Cantidad = Convert.ToInt32(dataReaderCanjes["Cantidad"]);
                    millas.Fecha = Convert.ToDateTime(dataReaderCanjes["Fecha"]);
                    millas.Millas = Convert.ToInt32(dataReaderCanjes["Puntos"]);
                    millas.Tipo_Row = 2;

                    ListadoMillas.Add(millas);
                }
                dataReaderCanjes.Close();
                dataReaderCanjes.Dispose();

            }
            return ListadoMillas;
        }
    }
}
