using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class AeronaveDTO
    {
        public int Numero{get;set;}
        public string Matricula{get;set;}
        public string Modelo{get;set;}
        public int KG{get;set;}
        public TipoServicioDTO TipoServicio{get;set;}
        public FabricanteDTO Fabricante{get;set;}
        public DateTime? FechaAlta{get;set;}
        public List<ButacaDTO> ListaButacas { get; set; }

        public AeronaveDTO(){
            this.ListaButacas = new List<ButacaDTO>();
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
