using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    class AeronaveFiltersDTO
    {
        public AeronaveDTO Aeronave { get; set; }
        public int Catidad_Butacas { get; set; }
        public DateTime? Fecha_Alta_Fin { get; set; }
        public DateTime? Fecha_Baja_Def { get; set; }
        public DateTime? Fecha_Baja_Def_Fin { get; set; }
        public DateTime? Fecha_Baja_Temporal { get; set; }
        public DateTime? Fecha_Baja_Temporal_Fin { get; set; }
        public DateTime? Fecha_Vuelta_Servicio { get; set; }
        public DateTime? Fecha_Vuelta_Servicio_Fin { get; set; }
        public CiudadDTO CiudadOrigen { get; set; }
        public CiudadDTO CiudadDestino { get; set; }
        public DateTime FechaSalida { get; set; }
    }
}
