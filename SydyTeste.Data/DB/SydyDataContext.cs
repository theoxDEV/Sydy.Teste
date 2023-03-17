using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SydyTeste.Data.Models;
using SydyTeste.Data.Models.Helpers;

namespace SydyTeste.Data.DB
{
    public class SydyDataContext : DbContext
    {
        private readonly SqlConnectSettings _formatSettings;
        public SydyDataContext(DbContextOptions<SydyDataContext> options, IOptions<SqlConnectSettings> appSettingsOptions) 
        : base(options)
        {
            _formatSettings = appSettingsOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_formatSettings.ConnectionString);
        }

        public DbSet<Team> Teams { get; set; }
    }
}
