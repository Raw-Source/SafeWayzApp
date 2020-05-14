using Microsoft.EntityFrameworkCore;
using SafeWayzAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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