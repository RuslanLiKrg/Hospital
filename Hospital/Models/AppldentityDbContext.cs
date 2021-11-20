using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    /// <summary>
    /// IdentityUser - встроенный класс, применяемый для представления пользователей.
    /// </summary>
    public class AppldentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppldentityDbContext(DbContextOptions<AppldentityDbContext> options) : base(options)
        {

        }
    }
}
