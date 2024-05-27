using Microsoft.EntityFrameworkCore;

namespace SOMA.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<UsersTable> Users { get; set; }
    }
}