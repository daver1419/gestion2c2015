using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class EncomiendaDTO
    {
        public int IdEncomienda { get; set; }
        public int Codigo { get; set; }
        public decimal Precio { get; set; }
        public int Kg { get; set; }
        public ClienteDTO Cliente { get; set; }
        public CompraDTO Compra { get; set; }

        public EncomiendaDTO() { }
    }
}
