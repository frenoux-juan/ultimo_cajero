using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ultimo_cajero.Models
{
    public class usuarios
    {
        public int id { get; set; }
        public int numero_tarjeta { get; set; }
        public int cvv { get; set; }
        public int estado { get; set; }
        public decimal balance { get; set; }
        public List <transaccion> transaccciones { get; set; }

    }
}
