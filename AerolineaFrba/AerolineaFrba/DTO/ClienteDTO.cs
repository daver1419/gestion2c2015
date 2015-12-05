using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set;}
	    public string Nombre { get; set;}
	    public string Apellido { get; set;}
	    public int Dni { get; set;}
	    public int Telefono { get; set;}
	    public string Direccion { get; set;}
	    public DateTime Fecha_Nac { get; set;}
	    public string Mail { get; set;}

        public ClienteDTO(){}

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ClienteDTO;

            if (item == null)
            {
                return false;
            }

            return item.IdCliente == this.IdCliente;
        }
    }
}
