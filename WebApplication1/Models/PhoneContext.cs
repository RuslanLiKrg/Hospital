using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class PhoneContext : DbContext//это БАЗА ДАННЫХ. Конте́кст = связь, соединение данных
    {
        public DbSet<Phone> Phones { get; set; }//это таблица
        public DbSet<Purchase> Purchases { get; set; } // это ТАБЛИЦА

    }
}