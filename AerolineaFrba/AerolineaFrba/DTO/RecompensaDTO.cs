using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class RecompensaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Millas { get; set; }
        public int Stock { get; set; }

        public RecompensaDTO()
        {
        }


    }
}
