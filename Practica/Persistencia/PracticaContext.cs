using Modelo;
using Persistencia.Config;
using System.Data.Entity;

namespace Persistencia
{
    public class PracticaContext : DbContext
    {
        public PracticaContext() : base("name=PracticaContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CargoConfig(modelBuilder.Entity<Cargo>());
            new EmpleadoConfig(modelBuilder.Entity<Empleado>());
        }
        public DbSet<Cargo>Cargo { get; set; }
        public DbSet<Empleado>Empleado { get; set; }
    }
}