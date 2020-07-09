using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public long idUsuario { get; set; }

        public String nombre { get; set; }

        public String contasenia { get; set; }

        public TipoUsuario tipoUsuario { get; set; }

        public bool activo { get; set; }
    }
}
