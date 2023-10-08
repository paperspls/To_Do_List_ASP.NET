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
        }

        public DbSet<Tarefa> Tarefas { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insetedEntries = this.ChangeTracker.Entries()
                                .Where(x => x.State == EntityState.Added)
                                .Select(x => x.Entity);

            foreach (var insertedEntry  in insetedEntries)
            {
                if (insertedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = new DateTimeOffset(DateTime.Now, new TimeSpan(-3, 0, 0));
                }
            }

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry is Auditable auditableEntity)
                {
                    auditableEntity.Data = new DateTimeOffset(DateTime.Now, new TimeSpan(-3, 0, 0));
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}