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

        private static List<AeronaveDTO> getAeronaves(SqlDataReader dataReader)
        {
            List<AeronaveDTO> ListaAeronaves = new List<AeronaveDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    AeronaveDTO aeronave = new AeronaveDTO();

                    aeronave.Numero = Convert.ToInt32(dataReader["Numero"]);
                    FabricanteDTO fabricante = new FabricanteDTO();
                    fabricante.IdFabricante = Convert.ToInt32(dataReader["Fabricante"]);
                    aeronave.Fabricante = fabricante;
                    aeronave.FechaAlta = Convert.ToDateTime(dataReader["Fecha_Alta"]);
                    aeronave.KG = Convert.ToInt32(dataReader["Kg_Disponibles"]);
                    aeronave.Matricula = Convert.ToString(dataReader["Matricula"]);
                    aeronave.Modelo = Convert.ToString(dataReader["Modelo"]);
                    TipoServicioDTO tipoServicio = new TipoServicioDTO();
                    tipoServicio.IdTipoServicio = Convert.ToInt32(dataReader["Tipo_Servicio"]);
                    aeronave.TipoServicio = tipoServicio;

                    ListaAeronaves.Add(aeronave);
                }
                dataReader.Close();
                dataReader.Dispose();

            }
            return ListaAeronaves;
        }
        public static List<AeronaveDTO> GetByFilters(AeronaveFiltersDTO aeronaveFilter)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Busqueda_Aeronave]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Modelo", aeronaveFilter.Aeronave.Modelo);
                com.Parameters.AddWithValue("@Matricula", aeronaveFilter.Aeronave.Matricula);
                com.Parameters.AddWithValue("@Kg_Disponibles", aeronaveFilter.Aeronave.KG);
                com.Parameters.AddWithValue("@Fabricante", aeronaveFilter.Aeronave.Fabricante.Nombre);
                com.Parameters.AddWithValue("@Tipo_Servicio", aeronaveFilter.Aeronave.TipoServicio.Descripcion);
                com.Parameters.AddWithValue("@Cantidad_Butacas", aeronaveFilter.Catidad_Butacas);
                com.Parameters.AddWithValue("@Fecha_Alta", aeronaveFilter.Aeronave.FechaAlta);
                com.Parameters.AddWithValue("@Fecha_Alta_Fin", aeronaveFilter.Fecha_Alta_Fin);
                com.Parameters.AddWithValue("@Fecha_Baja_Def", aeronaveFilter.Fecha_Baja_Def);
                com.Parameters.AddWithValue("@Fecha_Baja_Def_Fin", aeronaveFilter.Fecha_Baja_Def_Fin);
                com.Parameters.AddWithValue("@Fecha_Baja_Temporal", aeronaveFilter.Fecha_Baja_Temporal);
                com.Parameters.AddWithValue("@Fecha_Baja_Temporal_Fin", aeronaveFilter.Fecha_Baja_Temporal_Fin);
                com.Parameters.AddWithValue("@Fecha_Vuelta_Servicio", aeronaveFilter.Fecha_Vuelta_Servicio);
                com.Parameters.AddWithValue("@Fecha_Vuelta_Servicio_Fin", aeronaveFilter.Fecha_Vuelta_Servicio_Fin);
                SqlDataReader dataReader = com.ExecuteReader();
                return getAeronaves(dataReader);

            }
        }
    }
}
