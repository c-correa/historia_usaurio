using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace SOneWeb.Data
{
    public class DBConexion : DbContext
    {
        public DBConexion(DbContextOptions<DBConexion> options) : base(options)
        {
        }

        // Parameterless constructor for design-time tools if needed
        protected DBConexion()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Env.Load();
                var connectionString = Environment.GetEnvironmentVariable("URL_CONNECT_BD");
                optionsBuilder.UseNpgsql(connectionString);
            }
            
        }
        // Define your DbSets here
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}