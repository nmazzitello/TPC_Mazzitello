using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Solicitud
    {
        public long idSolicitud { get; set; }

        public DateTime fecha { get; set; }

        public GastosAdministrativos gastosAdm { get; set; }

        public Cliente cliente { get; set; }

        public String montoSolicitado { get; set; }

        public int cantidadCuotas { get; set; }

        public Producto producto { get; set; }

        public int estado { get; set; }  //si es 0, se rechazo. si es 1, se aprobo. si es 2, esta en revision del adm

        public String estadoLindo { get; set; }

        public String observacion { get; set; }
    }
}
