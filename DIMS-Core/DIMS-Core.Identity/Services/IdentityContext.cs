using DIMS_Core.Identity.Configs;
using DIMS_Core.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.Identity.Services
{
    public class IdentityContext : IdentityDbContext<User, Role, int>
    {
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var configs = new IdentityConfiguration();

            optionsBuilder.UseSqlServer(configs.ConnectionString);
        }
    }
}