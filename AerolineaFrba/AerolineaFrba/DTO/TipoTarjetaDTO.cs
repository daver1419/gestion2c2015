using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class TipoTarjetaDTO
    {
        public int IdTipoTarjeta { get; set; }
        public string Nombre { get; set; }
        public int NumeroCuotas { get; set; }

        public TipoTarjetaDTO() { }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            var item = obj as TipoTarjetaDTO;

            if (item == null)
            {
                return false;
            }

            return item.Nombre == this.Nombre;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
