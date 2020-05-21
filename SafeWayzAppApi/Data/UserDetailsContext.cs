using Microsoft.EntityFrameworkCore;
using SafeWayzLibrary.Models;

namespace SafeWayzAppApi.Data
{
    public class UserDetailsContext : DbContext
    {
        public UserDetailsContext(DbContextOptions<UserDetailsContext> options)
            : base(options)
        {

        }

        public DbSet<UserDetails> UserDetail { get; set; }
    }
}