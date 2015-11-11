using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.DTO
{
    public class FuncionalidadDTO
    {
        public enum Funcionalidad
        {
            ABM_ROL,
	        ABM_USUARIO,
	        ABM_CLIENTE,
	        ABM_CIUDAD,
	        ABM_RUTA_AEREA,
	        ABM_AERONAVE,
	        GENERAR_VIAJE,
	        REGISTRO_LLEGADA_DESTINO,
	        COMPRA_PASAJE_ENCOMIENDA,
	        CANCELAR_PASAJE_ENCOMIENDA,
	        CONSULTA_MILLAS,
	        CANJE_MILLAS,
	        LISTADO_ESTADISTICO
        }

        public Funcionalidad toFuncionalidad() { return (Funcionalidad)this.IdFuncionalidad; }

        public int IdFuncionalidad{get;set;}
        public string Descripcion{get;set;}

        public FuncionalidadDTO(){
        }

        public FuncionalidadDTO(int id, string desc)
        {
            this.IdFuncionalidad = id;
            Descripcion = desc;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public override bool Equals(object obj)
        {
            var item = obj as FuncionalidadDTO;

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
