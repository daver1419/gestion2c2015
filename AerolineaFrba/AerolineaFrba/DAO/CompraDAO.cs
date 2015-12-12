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
    public static class CompraDAO
    {
        /// <summary>
        /// Registra una compra
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static CompraDTO Save(CompraDTO compra)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SaveCompra]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter outPutPNR = new SqlParameter("@paramPNR", SqlDbType.NVarChar, 255) { Direction=ParameterDirection.Output};
                com.Parameters.Add(outPutPNR);
                SqlParameter outPutIdCompra = new SqlParameter("@paramIdCompra", SqlDbType.Int) { Direction = ParameterDirection.Output };
                com.Parameters.Add(outPutIdCompra);

                com.Parameters.AddWithValue("@paramComprador", compra.Comprador.IdCliente);
                com.Parameters.AddWithValue("@paramMedioPago",compra.MedioPago.IdTipoPago);
                com.Parameters.AddWithValue("@paramTarjeta",compra.TarjetaCredito.Numero);
                com.Parameters.AddWithValue("@paramViaje",compra.Viaje.Id);
                com.ExecuteNonQuery();

                CompraDTO retValue = new CompraDTO();
                retValue.PNR = (string)outPutPNR.Value;
                retValue.IdCompra = (int)outPutIdCompra.Value;

                return retValue;
            }
        }
        private static List<PasajeDTO> getPasajes(SqlDataReader dataReader)
        {
            List<PasajeDTO> ListaPasajes = new List<PasajeDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    PasajeDTO pasaje = new PasajeDTO();

                    pasaje.IdPasaje = Convert.ToInt32(dataReader["Id"]);
                    pasaje.Codigo = Convert.ToInt32(dataReader["Codigo"]);
                    pasaje.Precio = Convert.ToDecimal(dataReader["Precio"]);

                    ListaPasajes.Add(pasaje);
                }
                dataReader.Close();
                dataReader.Dispose();

            }
            return ListaPasajes;
        }
        /// <summary>
        /// Devuelve una lista de pasajes a partir de un PNR
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static List<PasajeDTO> GetPasajesByPnr(CompraDTO compra)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetPasajesByPnr]", conn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@paramPnr", compra.PNR);
                SqlDataReader dataReader=com.ExecuteReader();

                return getPasajes(dataReader);
            }
        }
        private static List<EncomiendaDTO> getEncomiendas(SqlDataReader dataReader)
        {
            List<EncomiendaDTO> ListaEncomiendas = new List<EncomiendaDTO>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    EncomiendaDTO encomienda = new EncomiendaDTO();

                    encomienda.IdEncomienda = Convert.ToInt32(dataReader["Id"]);
                    encomienda.Codigo = Convert.ToInt32(dataReader["Codigo"]);
                    encomienda.Precio = Convert.ToDecimal(dataReader["Precio"]);
                    encomienda.Kg = Convert.ToInt32(dataReader["Kg"]);

                    ListaEncomiendas.Add(encomienda);
                }
                dataReader.Close();
                dataReader.Dispose();

            }
            return ListaEncomiendas;
        }
        /// <summary>
        /// Devuelve una encomienda con una compra con cierto PNR
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static EncomiendaDTO GetEncomiendaByPnr(CompraDTO compra)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[GetEncomiendaByPnr]", conn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@paramPnr", compra.PNR);
                SqlDataReader dataReader = com.ExecuteReader();

                return getEncomiendas(dataReader).FirstOrDefault();
            }
        }
        /// <summary>
        /// Cancela todos los pasajes y encomienda asociados a la compra
        /// </summary>
        /// <param name="unaCompra"></param>
        /// <returns></returns>
        public static bool Cancelar(CompraDTO unaCompra,string motivo)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[Cancelar_Compra]", conn);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@pnr", unaCompra.PNR);
                com.Parameters.AddWithValue("@motivo", motivo);
                return com.ExecuteNonQuery() > 0;
            }
        }
    }
}
