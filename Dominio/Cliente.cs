using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public long idCliente { get; set; }

        public DateTime fechaRegistracion { get; set; }

        public Usuario usuario { get; set; }

        public String apellido { get; set; }

        public String nombre { get; set; }

        public String dni { get; set; }

        public String sexo { get; set; }

        public DateTime fechaNacimiento { get; set; }

        public Nacionalidad nacionalidad { get; set; }

        public DatosDomicilio datosDom { get; set; }

        public DatosContacto datosCont { get; set; }

        public DatosLaborales datosLab { get; set; }

        public List<Prestamo> cantidadPrestamos { get; set; }

        public bool activo { get; set; }

        public String activoLindo { get; set; }
    }
}
