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
                    com.Parameters.AddWithValue("@modelo", Aeronave.Modelo.Id);
                    com.Parameters.AddWithValue("@kg_disponibles", Aeronave.KG);
                    com.Parameters.AddWithValue("@fecha_alta", Aeronave.FechaAlta);
                    com.Parameters.AddWithValue("@fabricante", Aeronave.Fabricante.IdFabricante);
                    com.Parameters.AddWithValue("@tipo_servicio", Aeronave.TipoServicio.IdTipoServicio);
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

        public static bool ModificacionAeronave(AeronaveDTO Aeronave, List<ButacaDTO> ButacasAgregar,
            List<ButacaDTO> ButacasModificar)
        {
            int ret = 0;

            SqlConnection conn = Conexion.Conexion.obtenerConexion();

            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Modificar_Aeronave]", conn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Transaction = tran;
                    com.Parameters.AddWithValue("@matricula", Aeronave.Matricula);
                    com.Parameters.AddWithValue("@modelo", Aeronave.Modelo.Id);
                    com.Parameters.AddWithValue("@kg_disponibles", Aeronave.KG);
                    com.Parameters.AddWithValue("@fecha_alta", Aeronave.FechaAlta);
                    com.Parameters.AddWithValue("@fabricante", Aeronave.Fabricante.IdFabricante);
                    com.Parameters.AddWithValue("@tipo_servicio", Aeronave.TipoServicio.IdTipoServicio);
                    com.Parameters.AddWithValue("@numero", Aeronave.Numero);
                    com.ExecuteNonQuery();

                    foreach (ButacaDTO unaButaca in ButacasAgregar)
                    {
                        unaButaca.Aeronave = Aeronave.Numero;
                        ButacaDAO.AltaButaca(unaButaca, conn, tran);
                    }
                    foreach (ButacaDTO unaButaca in ButacasModificar)
                    {
                        unaButaca.Aeronave = Aeronave.Numero;
                        ButacaDAO.ModificarButaca(unaButaca, conn, tran);
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
                ret = Convert.ToInt32(com.Parameters["@tiene_viajes"].Value);
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
                    fabricante.Nombre = Convert.ToString(dataReader["Nombre"]);
                    aeronave.Fabricante = fabricante;
                    if (dataReader["Fecha_Alta"] != DBNull.Value)
                        aeronave.FechaAlta = Convert.ToDateTime(dataReader["Fecha_Alta"]);
                    else
                        aeronave.FechaAlta = DateTime.MinValue;
                    aeronave.KG = Convert.ToInt32(dataReader["Kg_Disponibles"]);
                    aeronave.Matricula = Convert.ToString(dataReader["Matricula"]);
                    ModeloDTO modelo = new ModeloDTO();
                    modelo.Id = Convert.ToInt32(dataReader["Modelo"]);
                    modelo.Modelo = Convert.ToString(dataReader["Modelo_Desc"]);
                    aeronave.Modelo = modelo;
                    TipoServicioDTO tipoServicio = new TipoServicioDTO();
                    tipoServicio.IdTipoServicio = Convert.ToInt32(dataReader["Tipo_Servicio"]);
                    tipoServicio.Descripcion = Convert.ToString(dataReader["Descripcion"]);
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
                com.Parameters.AddWithValue("@Matricula", aeronaveFilter.Aeronave.Matricula);
                com.Parameters.AddWithValue("@Kg_Disponibles", aeronaveFilter.Aeronave.KG);

                if (aeronaveFilter.Aeronave.Modelo != null)
                    com.Parameters.AddWithValue("@Modelo", aeronaveFilter.Aeronave.Modelo.Modelo);
                else
                    com.Parameters.AddWithValue("@Modelo", DBNull.Value);

                if (aeronaveFilter.Aeronave.Fabricante != null)
                    com.Parameters.AddWithValue("@Fabricante", aeronaveFilter.Aeronave.Fabricante.Nombre);
                else
                    com.Parameters.AddWithValue("@Fabricante", DBNull.Value);

                if (aeronaveFilter.Aeronave.TipoServicio != null)
                    com.Parameters.AddWithValue("@Tipo_Servicio", aeronaveFilter.Aeronave.TipoServicio.Descripcion);
                else
                    com.Parameters.AddWithValue("@Tipo_Servicio", DBNull.Value);

                if (aeronaveFilter.Aeronave.FechaAlta != null)
                    com.Parameters.AddWithValue("@Fecha_Alta", aeronaveFilter.Aeronave.FechaAlta);
                else
                    com.Parameters.AddWithValue("@Fecha_Alta", DBNull.Value);

                if (aeronaveFilter.Fecha_Alta_Fin != null)
                    com.Parameters.AddWithValue("@Fecha_Alta_Fin", aeronaveFilter.Fecha_Alta_Fin);
                else
                    com.Parameters.AddWithValue("@Fecha_Alta_Fin", DBNull.Value);

                if (aeronaveFilter.Fecha_Baja_Def != null)
                    com.Parameters.AddWithValue("@Fecha_Baja_Def", aeronaveFilter.Fecha_Baja_Def);
                else
                    com.Parameters.AddWithValue("@Fecha_Baja_Def", DBNull.Value);

                if (aeronaveFilter.Fecha_Baja_Def_Fin != null)
                    com.Parameters.AddWithValue("@Fecha_Baja_Def_Fin", aeronaveFilter.Fecha_Baja_Def_Fin);
                else
                    com.Parameters.AddWithValue("@Fecha_Baja_Def_Fin", DBNull.Value);

                if (aeronaveFilter.Fecha_Baja_Temporal != null)
                    com.Parameters.AddWithValue("@Fecha_Baja_Temporal", aeronaveFilter.Fecha_Baja_Temporal);
                else
                    com.Parameters.AddWithValue("@Fecha_Baja_Temporal", DBNull.Value);

                if (aeronaveFilter.Fecha_Baja_Temporal_Fin != null)
                    com.Parameters.AddWithValue("@Fecha_Baja_Temporal_Fin", aeronaveFilter.Fecha_Baja_Temporal_Fin);
                else
                    com.Parameters.AddWithValue("@Fecha_Baja_Temporal_Fin", DBNull.Value);

                if (aeronaveFilter.Fecha_Vuelta_Servicio != null)
                    com.Parameters.AddWithValue("@Fecha_Vuelta_Servicio", aeronaveFilter.Fecha_Vuelta_Servicio);
                else
                    com.Parameters.AddWithValue("@Fecha_Vuelta_Servicio", DBNull.Value);

                if (aeronaveFilter.Fecha_Vuelta_Servicio_Fin != null)
                    com.Parameters.AddWithValue("@Fecha_Vuelta_Servicio_Fin", aeronaveFilter.Fecha_Vuelta_Servicio_Fin);
                else
                    com.Parameters.AddWithValue("@Fecha_Vuelta_Servicio_Fin", DBNull.Value);

                SqlDataReader dataReader = com.ExecuteReader();
                return getAeronaves(dataReader);

            }
        }

        public static List<AeronaveDTO> GetByFiltersBaja(AeronaveFiltersDTO aeronaveFilter)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Busqueda_Baja_Aeronave]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Matricula", aeronaveFilter.Aeronave.Matricula);
                com.Parameters.AddWithValue("@Kg_Disponibles", aeronaveFilter.Aeronave.KG);

                if (aeronaveFilter.Aeronave.Modelo != null)
                    com.Parameters.AddWithValue("@Modelo", aeronaveFilter.Aeronave.Modelo.Modelo);
                else
                    com.Parameters.AddWithValue("@Modelo", DBNull.Value);

                if (aeronaveFilter.Aeronave.Fabricante != null)
                    com.Parameters.AddWithValue("@Fabricante", aeronaveFilter.Aeronave.Fabricante.Nombre);
                else
                    com.Parameters.AddWithValue("@Fabricante", DBNull.Value);

                if (aeronaveFilter.Aeronave.TipoServicio != null)
                    com.Parameters.AddWithValue("@Tipo_Servicio", aeronaveFilter.Aeronave.TipoServicio.Descripcion);
                else
                    com.Parameters.AddWithValue("@Tipo_Servicio", DBNull.Value);

                if (aeronaveFilter.Aeronave.FechaAlta != null)
                    com.Parameters.AddWithValue("@Fecha_Alta", aeronaveFilter.Aeronave.FechaAlta);
                else
                    com.Parameters.AddWithValue("@Fecha_Alta", DBNull.Value);

                if (aeronaveFilter.Fecha_Alta_Fin != null)
                    com.Parameters.AddWithValue("@Fecha_Alta_Fin", aeronaveFilter.Fecha_Alta_Fin);
                else
                    com.Parameters.AddWithValue("@Fecha_Alta_Fin", DBNull.Value);

                SqlDataReader dataReader = com.ExecuteReader();
                return getAeronaves(dataReader);

            }
        }
        public static void BajaDefCancelar(AeronaveDTO aeronave)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SP_Baja_Def_Aeronave_Cancelar]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@nroAeronave", aeronave.Numero);
                comm.ExecuteNonQuery();
            }
        }
        public static bool BajaTempCancelar(BajaTemporalDTO BajaTemporal)
        {
            int retValue = 0;
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand comm = new SqlCommand("[NORMALIZADOS].[SP_Baja_Temporal_Aeronave_Cancelar]", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@nroAeronave", BajaTemporal.NroAeronave);
                comm.Parameters.AddWithValue("@fechaDesde", BajaTemporal.FechaDesde);
                comm.Parameters.AddWithValue("@fechaHasta", BajaTemporal.FechaHasta);
                comm.Parameters.AddWithValue("@motivo", BajaTemporal.Motivo);
                retValue=comm.ExecuteNonQuery();
            }
            return retValue > 0;
        }

    }
}
