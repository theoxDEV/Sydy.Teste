using Microsoft.EntityFrameworkCore;
using SydyTeste.Data.Models;

namespace SydyTeste.Data.DB
{
    public class SydyDataContext : DbContext
    {
        public SydyDataContext(DbContextOptions<SydyDataContext> options) 
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MATHEUX-NOTE\\SQLEXPRESS;Database=SYDY;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Team> Teams { get; set; }
    }
}
