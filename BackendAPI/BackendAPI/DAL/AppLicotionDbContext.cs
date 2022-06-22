using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.DAL
{
    public class AppLicotionDbContext:DbContext
    {
        public AppLicotionDbContext(DbContextOptions<AppLicotionDbContext> options):base(options)
        {

        }

        public DbSet<Praduct> praducts { get; set; }
    }
}
