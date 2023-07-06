using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<User> Users { get;set; }
    }
}
