using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class PasajeDTO
    {
        public int IdPasaje { get; set; }
        public int Codigo { get; set; }
        public decimal Precio { get; set; }
        public ClienteDTO Pasajero { get; set; }
        public CompraDTO Compra { get; set; }
        public ButacaDTO Butaca { get; set; }

        public PasajeDTO() { }
    }
}
