using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Epolis.Models;

namespace Epolis.Data
{
    public class EpolisContext : DbContext
    {
        public EpolisContext (DbContextOptions<EpolisContext> options)
            : base(options)
        {
        }

        public DbSet<Epolis.Models.Msysparam> Msysparam { get; set; }
        public DbSet<EPolis.Models.MJENISASURANSI> MJENISASURANSI { get; set; }
        public DbSet<EPolis.Models.PerusahaanAsuransi> PerusahaanAsuransi { get; set; }
        public DbSet<EPolis.Models.MOKUPASI> MOKUPASI { get; set; }
        public DbSet<EPolis.Models.MJENISPERTANGGUNGAN> MJENISPERTANGGUNGAN { get; set; }
        public DbSet<EpolisParam.Models.Mbroker> Mbroker { get; set; }
        public DbSet<EPolis.Models.MPERLUASAN> MPERLUASAN { get; set; }
        public DbSet<EpolisParam.Models.MRESIKO> MRESIKO { get; set; }
    }
}
