using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Hospital.Models
{
    public static class SeedData
    {
        public static void EnsureAdress(IApplicationBuilder app)
        {
            HospitalDBContext context = app.ApplicationServices.GetRequiredService<HospitalDBContext>();
            context.Database.Migrate();
            if (!context.Streets.Any())
            {
                context.Streets.AddRange(
                    );
                context.SaveChanges();
            }
           

        }
        public static void EnsureDoctors(IApplicationBuilder app)
        {
            HospitalDBContext context = app.ApplicationServices.GetRequiredService<HospitalDBContext>();
            context.Database.Migrate();
            if (!context.DoctorLists.Any())
            {
                context.DoctorLists.AddRange(
                    new Doctor { Name = "Игорь", Surname = "Иванов", SpecialityId = 1 },
                    new Doctor { Name = "Карина", Surname = "Сатанова", SpecialityId = 3 },
                    new Doctor { Name = "Ержан", Surname = "Оспанова", SpecialityId = 2 }
                    );
                context.SaveChanges();
            }

        }
    }
}
