using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ValorCuota
    {
        public int numeroCuota { get; set; }

        public float valorCuota { get; set; }

        public float valorCuotaAtrasada { get; set; }

        public float valorCuotaVencida { get; set; }

        public DateTime fechaAtrasada { get; set; }

        public String fechaAtrasadaLinda { get; set; }

        public DateTime fechaVencida { get; set; }

        public String  fechaVencidaLinda { get; set; }

        public DateTime fechaPagoCliente { get; set; }

        public String fechaPagoClienteLinda { get; set; }

        public String comprobantePago { get; set; }     // si pago en efectivo, la url de la imagen del recibo que le firma al empleado
                                                        // si fue transferencia, el numero de operacion
    }
}
