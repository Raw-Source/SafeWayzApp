using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWayzApp.Models
{
    public class UserDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long Points { get; set; } = 200;
        public string Password { get; set; }

    }
}
