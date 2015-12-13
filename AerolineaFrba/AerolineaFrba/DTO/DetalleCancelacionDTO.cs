using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class DetalleCancelacionDTO
    {
        public int IdCancelacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
    }
}
