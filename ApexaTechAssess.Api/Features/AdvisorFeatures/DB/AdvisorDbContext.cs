using ApexaTechAssess.Api.Features.AdvisorFeatures.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApexaTechAssess.Api.Features.AdvisorFeatures.DB
{
    /// <summary>
    /// This DB context servers as a datacontext for Advisor related information.
    /// </summary>
    public class AdvisorDbContext : DbContext
    {
        /// <summary>
        /// Initialize db context class
        /// </summary>
        /// <param name="options"></param>
        public AdvisorDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// DBset for advisor
        /// </summary>
        public DbSet<Advisor> Advisors { get; set; }
        /// <summary>
        /// model builder validations.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advisor>(advisor =>
            {

                advisor.Property(p => p.FullName).IsRequired(true).HasMaxLength(255); //full name required and max length 255
                advisor.Property(p => p.SIN).IsRequired(true).HasMaxLength(9);  //SIN required , fixed length=9
                advisor.Property(p => p.Address).HasMaxLength(255);  //Address max length
                advisor.Property(p => p.PhoneNumber).HasMaxLength(10); //phone number max length
            });
            modelBuilder.Entity<Advisor>().HasIndex(i => i.SIN).IsUnique(true);
            modelBuilder.Entity<Advisor>().HasKey(i => i.Id);
        }

        
    }


}
