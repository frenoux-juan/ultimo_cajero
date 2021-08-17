using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ultimo_cajero.Models
{
    public class operacion
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public decimal saldo_previo { get; set; }
        public decimal saldo_actual { get; set; }
        public decimal saldo_operacion { get; set; }
        public transaccion transaccion { get; set; }

    }
}
