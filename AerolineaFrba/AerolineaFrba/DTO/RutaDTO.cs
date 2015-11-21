using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class RutaDTO
    {
        public int IdRuta { get; set; }
        public int Codigo { get; set; }
        public CiudadDTO CiudadOrigen{get;set;}
        public CiudadDTO CiudadDestino { get; set; }
        public decimal PrecioBasePasaje { get; set; }
        public decimal PrecioBaseKg { get; set; }
        public TipoServicioDTO Servicio { get; set; }
        public bool Habilitado { get; set; }

        public override string ToString()
        {
            return Codigo.ToString();
        }

        public override bool Equals(object obj)
        {
            var item = obj as RutaDTO;

            if (item == null)
            {
                return false;
            }

            return item.Codigo == this.Codigo;
        }
    }
}
