using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Prestamo
    {
        public long idPrestamo { get; set; }

        public bool estado { get; set; } //0 si finalizo, 1 si esta activo

        public String estadoLindo { get; set; }

        public DateTime fecha { get; set; }

        public int monto { get; set; }

        public int cantCuotas { get; set; }

        public GastosAdministrativos gastosAdm { get; set; }

        public Producto prodGarantia { get; set; }

        public List<ValorCuota> datosCuota { get; set; }

        public Cliente cliente { get; set; }
    }
}
