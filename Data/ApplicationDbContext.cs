using Microsoft.EntityFrameworkCore;
using WebApplicationRider.Models;

namespace WebApplicationRider.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }
    }
}