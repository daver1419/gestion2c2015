using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    class AeronaveDTO
    {
        public int Numero{get;set;}
        public string Matricula{get;set;}
        public string Modelo{get;set;}
        public int KG{get;set;}
        public TipoServicioDTO TipoServicio{get;set;}
        public FabricanteDTO Fabricante{get;set;}
        public DateTime FechaAlta{get;set;}

        public AeronaveDTO(){
        }

        public override string ToString()
        {
            return Matricula;
        }

        public override bool Equals(object obj)
        {
            var item = obj as AeronaveDTO;

            if (item == null)
            {
                return false;
            }

            return item.Matricula == this.Matricula;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
