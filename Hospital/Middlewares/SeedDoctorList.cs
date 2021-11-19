using Hospital.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Middlewares
{
    public static class SeedDoctorList
    {
        public static void AddDoctor(IApplicationBuilder app)
        {
            HospitalDBContext context = app.ApplicationServices.GetRequiredService<HospitalDBContext>();
            context.Database.Migrate();
            if (!context.DoctorLists.Any())
            {
                context.AddRange(
                    new Doctor
                    {
                        Name = "Иванов",
                        Surname = "Сергей",
                        SpecialityId = 1
                        
                    },
                    new Doctor
                    {
                        Name = "Антошин",
                        Surname = "Денис",
                        SpecialityId = 3
                    },
                    new Doctor
                    {
                        Name = "Карпов",
                        Surname = "Станислав",
                        SpecialityId = 2
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
