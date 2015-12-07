using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class CompraDTO
    {
        public int IdCompra { get; set; }
        public int PNR { get; set; }
        public ClienteDTO Comprador { get; set; }
        public TipoPagoDTO MedioPago { get; set; }
        public TarjetaCreditoDTO TarjetaCredito { get; set; }
        public ViajeDTO Viaje { get; set; }

        public CompraDTO() { }
    }
}
