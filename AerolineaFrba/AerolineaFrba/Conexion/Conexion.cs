using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AerolineaFrba.Conexion
{
    public static class Conexion
    {
        public static SqlConnection obtenerConexion()
        {
            SqlConnection Conn = new SqlConnection(@"Data source=(local)\SQLSERVER2012;Initial Catalog = GD2C2015;User ID=gd;Password=gd2015");
            Conn.Open();
            System.Console.WriteLine("Conexion exitosa");
            return Conn;

        }
    }
}
