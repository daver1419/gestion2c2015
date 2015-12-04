using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class MillasDTO
    {

        //Compartido
        public int Tipo_Row { get; set; }
        public DateTime Fecha { get; set; }
        public int Millas { get; set; }

        //Para cuando generas millas
        public string Pasaje_Encomienda{get;set;}
        public string Origen{get;set;}
        public string Destino{get;set;}

        //Para canje
        public string Recompensa { get; set; }
        public int Cantidad { get; set; }

        public MillasDTO()
        {
            this.Pasaje_Encomienda = "N/A";
            this.Origen = "N/A";
            this.Destino = "N/A";
            this.Recompensa = "N/A";
        }
    }
}
