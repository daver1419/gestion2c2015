using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class RegistroLlegadaDestinoDTO
    {
        public ViajeDTO Viaje { get; set; }
        public CiudadDTO AeropuertoDestino { get; set; }
        public DateTime FechaLlegada { get; set; }

        public RegistroLlegadaDestinoDTO() { }
    }
}
