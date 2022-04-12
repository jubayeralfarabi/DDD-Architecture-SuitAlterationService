namespace Suit.Infrastructure.Repository.RDBRepository.DbContexts
{
    using Microsoft.EntityFrameworkCore;
    using Suit.AlterationService.Domain;

    public class AlterationDbContext : DbContext
    {
        public AlterationDbContext(DbContextOptions<AlterationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<AlterationAggregate> AlterationAggregate { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}