using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using SOneWeb.Domain.Entities;

namespace SOneWeb.Infrastructure.Persistence
{
    // 👇 Aquí está el cambio importante
    public class DBConexion : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public DBConexion(DbContextOptions<DBConexion> options) : base(options)
        {
        }

        protected DBConexion() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Env.Load();
                var connectionString = Environment.GetEnvironmentVariable("URL_CONNECT_BD");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        // Aquí puedes registrar tus demás entidades
        // public DbSet<Product> Products { get; set; }
    }
}
