using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ultimo_cajero.Models;

namespace ultimo_cajero.Data
{
    public class ultimo_cajeroContext : DbContext
    {
        public ultimo_cajeroContext (DbContextOptions<ultimo_cajeroContext> options)
            : base(options)
        {
        }

        public DbSet<ultimo_cajero.Models.usuarios> usuarios { get; set; }

        public DbSet<ultimo_cajero.Models.transaccion> transaccion { get; set; }

        public DbSet<ultimo_cajero.Models.operacion> operacion { get; set; }
    }
}
