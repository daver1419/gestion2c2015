using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class TarjetaCreditoDTO
    {
        public long Numero { get; set; }
        public int Codigo { get; set; }
        public int FechaVencimiento { get; set; }
        public TipoTarjetaDTO TipoTarjeta { get; set; }

        public TarjetaCreditoDTO() { }
    }
}
