using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class GridViajesDTO
    {
        public int IdViaje { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegadaEstimada { get; set; }
        public int IdRuta { get; set; }
        public string DescrCiudadOrigen { get; set; }
        public string DescrCiudadDest { get; set; }
        public int NumeroAeronave { get; set; }
        public string MatriculaAeronave { get; set; }
        public int IdTipoServicio { get; set; }
        public string DescrServicio { get; set; }
        public int CantButacasDisp { get; set; }
        public int KgsDisponibles { get; set; }

    }
}
