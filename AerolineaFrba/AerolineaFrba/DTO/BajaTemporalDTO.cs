using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class BajaTemporalDTO
    {
        public int NroAeronave { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Motivo { get; set; }

        public BajaTemporalDTO() { 
        
        }
    }
}
