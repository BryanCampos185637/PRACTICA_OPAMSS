using Modelo;
using System.Data.Entity.ModelConfiguration;

namespace Persistencia.Config
{
    public class EmpleadoConfig
    {
        public EmpleadoConfig(EntityTypeConfiguration<Empleado> entityType)
        {
            entityType.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
            entityType.Property(p => p.Apellido).IsRequired().HasMaxLength(200);
            entityType.Property(p => p.Edad).IsRequired();
            entityType.Property(p => p.FechaNacimiento).IsRequired().HasColumnType("date");
            entityType.Property(p => p.Estado).IsRequired().HasMaxLength(3);
        }
    }
}
