using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class FabricanteDTO
    {
        public int IdFabricante{get;set;}
        public string Nombre{get;set;}

        public FabricanteDTO(){
        }

        public FabricanteDTO(int id, string nom)
        {
            this.IdFabricante = id;
            Nombre = nom;
        }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            var item = obj as FabricanteDTO;

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
