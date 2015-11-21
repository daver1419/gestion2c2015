using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class ModeloDTO
    {
        public int Id{get;set;}
        public string Modelo{get;set;}

        public ModeloDTO(){
        }

        public ModeloDTO(int id, string mod)
        {
            this.Id = id;
            Modelo = mod;
        }

        public override string ToString()
        {
            return Modelo;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ModeloDTO;

            if (item == null)
            {
                return false;
            }

            return item.Modelo == this.Modelo;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
