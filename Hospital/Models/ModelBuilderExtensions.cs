using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Street>().HasData(
                new Street { Id = 1, Name = "Гоголя"},
                new Street { Id = 2, Name = "Гулдер-1"},
                new Street { Id = 3, Name = "14 мкр"}
                );
           
            modelBuilder.Entity<Speciality>().HasData(
                new Speciality{ Id = 1, Name = "Терапевт"},
                    new Speciality{ Id = 2, Name = "Окулист"},
                    new Speciality{ Id = 3, Name = "Невропатолог"}
                );
            modelBuilder.Entity<DiagnozList>().HasData(
                    new DiagnozList{ Id = 1, Name = "Ангина"},
                    new DiagnozList{ Id = 2, Name = "Аппендицит"},
                    new DiagnozList{ Id = 3, Name = "Артроз"}
                );
            
        }
    }
}
