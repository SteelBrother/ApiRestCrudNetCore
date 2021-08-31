using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalyCap.Entities;

namespace TalyCap.DataAccess
{
    public class ApiDbContext : IdentityDbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Entrega> Entrega { get; set; }
        public DbSet<LugarEntrega> LugarEntrega { get; set; }
        public DbSet<TipoLugarEntrega> TipoLugarEntrega { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<TipoEnvio> TipoEnvio { get; set; }
        public DbSet<VehiculoEntrega> VehiculoEntrega { get; set; }
        public DbSet<TipoVehiculoEntrega> TipoVehiculoEntrega { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
