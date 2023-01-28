using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EstefaniaVinueza_EjercicioCF.Models;

namespace EstefaniaVinueza_EjercicioCF.Data
{
    public class EstefaniaVinueza_EjercicioCFContext : DbContext
    {
        public EstefaniaVinueza_EjercicioCFContext (DbContextOptions<EstefaniaVinueza_EjercicioCFContext> options)
            : base(options)
        {
        }

        public DbSet<EstefaniaVinueza_EjercicioCF.Models.Pizza> Pizza { get; set; } = default!;
    }
}
