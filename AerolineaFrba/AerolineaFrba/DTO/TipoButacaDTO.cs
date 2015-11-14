using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class TipoButacaDTO
    {
        public int IdTipoButaca{get;set;}
        public string Descripcion{get;set;}

        public TipoButacaDTO(){
        }

        public TipoButacaDTO(int id, string desc)
        {
            this.IdTipoButaca = id;
            Descripcion = desc;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            var item = obj as TipoButacaDTO;

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
