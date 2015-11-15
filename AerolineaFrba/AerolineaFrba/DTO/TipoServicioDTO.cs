using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class TipoServicioDTO
    {
        public int IdTipoServicio{get;set;}
        public string Descripcion{get;set;}

        public TipoServicioDTO(){
        }

        public TipoServicioDTO(int id, string desc)
        {
            this.IdTipoServicio = id;
            Descripcion = desc;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            var item = obj as TipoServicioDTO;

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
