using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class TipoPagoDTO
    {
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }

        public TipoPagoDTO(){
            
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            var item = obj as TipoPagoDTO;

            if (item == null)
            {
                return false;
            }

            return item.Descripcion == this.Descripcion;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
