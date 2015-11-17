using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class ButacaDTO
    {
        public int IdButaca { get; set; }
        public int Numero { get; set; }
        public TipoButacaDTO Tipo_Butaca { get; set; }
        public int Piso { get; set; }
        public bool Habilitada { get; set; }
        public int Aeronave { get; set; }

        public ButacaDTO(){
        }

        public override string ToString()
        {
            return Convert.ToString(Numero);
        }

        public override bool Equals(object obj)
        {
            if (obj.ToString() == this.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return 1;
        }

    }
}
