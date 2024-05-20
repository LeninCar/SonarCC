using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace backend_todo.Models.Configuration
{
    public class EstadoTareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.Property(e => e.Estado).HasConversion(
                i => i.ToString(),
                i => (EstadoTarea)Enum.Parse(typeof(EstadoTarea), i)
            );
        }
    }
}
