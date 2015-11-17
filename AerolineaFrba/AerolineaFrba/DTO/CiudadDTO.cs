using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class CiudadDTO
    {
        public int IdCiudad { get; set; }
        public string Descripcion { get; set; }

        public CiudadDTO()
        {
        }

        public CiudadDTO(int id, string nom)
        {
            this.IdCiudad = id;
            this.Descripcion = nom;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            var item = obj as CiudadDTO;

            if (item == null)
            {
                return false;
            }

            return item.Descripcion == this.Descripcion;
        }
    }
}
