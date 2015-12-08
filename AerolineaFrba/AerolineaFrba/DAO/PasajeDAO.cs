﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AerolineaFrba.DTO;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba.DAO
{
    public static class PasajeDAO
    {
        public static PasajeDTO Save(PasajeDTO unPasaje)
        {
            using (SqlConnection conn = Conexion.Conexion.obtenerConexion())
            {
                SqlCommand com = new SqlCommand("[NORMALIZADOS].[SavePasaje]", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlParameter outPutPrecio = new SqlParameter("@paramPrecio", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                com.Parameters.Add(outPutPrecio);
                com.Parameters.AddWithValue("@paramPasajero", unPasaje.Pasajero.IdCliente);
                com.Parameters.AddWithValue("@paramCompra", unPasaje.Compra.IdCompra);
                com.Parameters.AddWithValue("@paramButaca", unPasaje.Butaca.IdButaca);
                com.ExecuteNonQuery();

                PasajeDTO retValue = new PasajeDTO();
                retValue.Precio = (decimal)outPutPrecio.Value;

                return retValue;
            }
        }
    }
}