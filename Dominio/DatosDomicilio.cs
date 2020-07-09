using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DatosDomicilio
    {
        public String  direccion { get; set; }

        public Ciudad ciudad { get; set; }

        public Provincia provincia { get; set; }

        public Pais pais { get; set; }
    }
}
