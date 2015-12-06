using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba.DAO
{
    public static class TipoPagoDAO
    {
        private static List<TipoPagoDTO> getTiposPago(SqlDataReader dataReader)
        {
            List<TipoPagoDTO> ListaTipoPago = new List<TipoPagoDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    TipoPagoDTO tipoPago = new TipoPagoDTO();

                    tipoPago.IdTipoPago = Convert.ToInt32(dataReader["Id"]);
                    tipoPago.Descripcion = Convert.ToString(dataReader["Descripcion"]);

                    ListaTipoPago.Add(tipoPago);
                }
                dataReader.Close();
                dataReader.Dispose();
            }
            return ListaTipoPago;
        }

        public static List<TipoPagoDTO> GetAll()
        {
            List<TipoPagoDTO> listaTiposPago;

            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetAllTipoPago_SEL]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                listaTiposPago = getTiposPago(reader);
            }
            return listaTiposPago;
        }
    }
}
