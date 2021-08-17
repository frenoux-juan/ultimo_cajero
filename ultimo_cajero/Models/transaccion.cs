using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ultimo_cajero.Models
{
    public class transaccion
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public int id_operacion { get; set; }
        public DateTime fecha_hora { get; set; }
        public usuarios usuarios { get; set; }
        public List<operacion> operaciones { get; set; }
    }
}
