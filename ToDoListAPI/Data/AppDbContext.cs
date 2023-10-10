using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Model;

namespace ToDoListAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>().ToTable("tb_tarefas");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");

            modelBuilder.Entity<Tarefa>()
                  .HasOne(t => t.Categoria)
                  .WithMany(c => c.Tarefa)
                  .HasForeignKey("CategoriaId")
                  .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento Postagem -> User
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefa)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insetedEntries = this.ChangeTracker.Entries()
                                .Where(x => x.State == EntityState.Added)
                                .Select(x => x.Entity);

            foreach (var insertedEntry  in insetedEntries)
            {
                if (insertedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = DateTimeOffset.UtcNow;
                }
            }

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = DateTimeOffset.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}