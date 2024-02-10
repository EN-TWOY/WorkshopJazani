using Jazani.Domain.Admins.Models;
using Jazani.Infrastructure.Admins.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AreaTypeConfiguration());
        }


        #region "DbSet"

        public DbSet<AreaType> AreaTypes { get; set; }
        #endregion


    }
}

