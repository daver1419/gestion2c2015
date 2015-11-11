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
        public static void AltaAeronave(AeronaveDTO Aeronave)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SP_Alta_Aeronave]", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@matricula", Aeronave.Matricula);
                com.Parameters.AddWithValue("@modelo", Aeronave.Modelo);
                com.Parameters.AddWithValue("@kg_disponibles", Aeronave.KG);
                com.Parameters.AddWithValue("@fecha_alta", Aeronave.FechaAlta.ToString());
                com.Parameters.AddWithValue("@fabricante", Aeronave.Fabricante.IdFabricante);
                com.Parameters.AddWithValue("@tipo_servicio", Aeronave.TipoServicio.IdTipoServicio);
                com.ExecuteNonQuery();
            }
        }
    }
}
