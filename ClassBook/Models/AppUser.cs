﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassBook.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}