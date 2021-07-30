using Modelo;
using System.Data.Entity.ModelConfiguration;

namespace Persistencia.Config
{
    public class CargoConfig
    {
        public CargoConfig(EntityTypeConfiguration<Cargo>entityType)
        {
            entityType.Property(p => p.Descripcion).IsRequired().HasMaxLength(200);
            entityType.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
            entityType.Property(p => p.Estado).IsRequired().HasMaxLength(3);
        }
    }
}
