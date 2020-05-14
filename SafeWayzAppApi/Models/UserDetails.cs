﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeWayzAppApi.Models
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Points { get; set; } = 200;
        public string Password { get; set; }

    }
}
