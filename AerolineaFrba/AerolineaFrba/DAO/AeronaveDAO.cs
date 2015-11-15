using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AerolineaFrba.DTO;

namespace AerolineaFrba.DAO
{
    class AeronaveDAO
    {
        public static bool AltaAeronave(AeronaveDTO Aeronave)
        {
            int ret = 0;

            SqlConnection conn = Conexion.Conexion.obtenerConexion();

            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Alta_Aeronave]", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Transaction = tran;
                    com.Parameters.AddWithValue("@matricula", Aeronave.Matricula);
                    com.Parameters.AddWithValue("@modelo", Aeronave.Modelo);
                    com.Parameters.AddWithValue("@kg_disponibles", Aeronave.KG);
                    com.Parameters.AddWithValue("@fecha_alta", Aeronave.FechaAlta);
                    com.Parameters.AddWithValue("@fabricante", Aeronave.Fabricante.IdFabricante);
                    com.Parameters.AddWithValue("@tipo_servicio", Aeronave.TipoServicio.IdTipoServicio);
                    com.Parameters.AddWithValue("@cant_butacas", Aeronave.ListaButacas.Count);
                    com.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    com.ExecuteNonQuery();
                    Aeronave.Numero = Convert.ToInt32(com.Parameters["@Id"].Value);

                    foreach (ButacaDTO unaButaca in Aeronave.ListaButacas)
                    {
                        unaButaca.Aeronave = Aeronave.Numero;
                        ButacaDAO.AltaButaca(unaButaca, conn, tran);
                    }
                    tran.Commit();
                    ret = 1;
                }
                catch
                {
                    tran.Rollback();
                    ret = 0;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return ret > 0;
        }

        public static bool ViajesProgramados(AeronaveDTO Aeronave)
        {
            int ret = 0;

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Aeronave_Con_Viajes]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@aeronave", Aeronave.Numero);
                com.Parameters.Add("@tiene_viajes", SqlDbType.Bit).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                ret = (int) com.Parameters["@Id"].Value;
            }
            return ret == 1;
        }
    }
}
