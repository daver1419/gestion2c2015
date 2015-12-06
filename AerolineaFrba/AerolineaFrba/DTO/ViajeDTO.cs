using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class ViajeDTO
    {
        public int Id { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegadaEstimada { get; set; }
        public RutaDTO Ruta { get; set; }
        public AeronaveDTO Aeronave { get; set; }
        public int CantButacasLibre { get; set; }

        public ViajeDTO(){}
    }
}
