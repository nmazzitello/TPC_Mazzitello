using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public long idProducto { get; set; }

        public String producto { get; set; }

        public String marca { get; set; }

        public String modelo { get; set; }

        public String detalles { get; set; }

        public String estado { get; set; } // si es nuevo o usado

        public String imagen { get; set; }

        public String precio { get; set; }

    }
}
