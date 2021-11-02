using Microsoft.EntityFrameworkCore;

namespace SunstoneProject.Infrastructure.Persistence.EntityFramework.Context
{
    public class SunstoneContext : DbContext
    {
        public SunstoneContext(DbContextOptions<SunstoneContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Entities.Gemstone> Gemstones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SunstoneContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
