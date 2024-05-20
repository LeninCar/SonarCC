using backend_todo.Models;
using backend_todo.Models.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend_todo.Context
{
    public class TareasDbContext : IdentityDbContext<ApplicationUser>
    {
        public TareasDbContext(DbContextOptions<TareasDbContext> options)
       : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Categoria)
                .WithMany(c => c.Tareas)
                .HasForeignKey(t => t.CategoriaId);

            // Aplicar configuración del estado de tarea
            modelBuilder.ApplyConfiguration(new EstadoTareaConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userName = "system";

            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.Now;
                        entry.Entity.CreadoPor = userName;
                        break;

                    case EntityState.Modified:
                        entry.Entity.FechaModificacion = DateTime.Now;
                        entry.Entity.ActualizadoPor = userName;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
