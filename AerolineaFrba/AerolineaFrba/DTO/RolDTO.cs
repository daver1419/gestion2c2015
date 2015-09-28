using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class RolDTO
    {
        public int IdRol{ get;set;}
        public string NombreRol{get;set;}
        public List<FuncionalidadDTO> ListaFunc{get;set;}
        public bool Estado{get;set;}

        //Constructor de rol
        public RolDTO(){
            this.ListaFunc = new List<FuncionalidadDTO>();
            this.Estado = true;
        }

        public override string ToString()
        {
            return this.NombreRol;
        }

        public override bool  Equals(object obj)
        {
            if (obj as RolDTO == null)
                return false;

            if(this.Estado == ((RolDTO)obj).Estado && this.NombreRol == ((RolDTO)obj).NombreRol)
            {
                return true;
            }
            else{
                return false;
            }

        }
    }
}
