using API_Caching_p.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Caching_p.DataBaseAction
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        { }

        public DbSet<StudentMaster> StudentMaster { get; set; }
        public DbSet<MarkMaster> MarkMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MarkMaster>()
                .HasOne(m => m.StudentMaster)
                .WithMany()
                .HasForeignKey(m => m.SId);
        }
    }
}
