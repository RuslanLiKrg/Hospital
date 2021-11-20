using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class HospitalDBContext:DbContext
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<VisitHistory> VisitHistories { get; set; }
        public DbSet<Speciality> SpecialistLists { get; set; }

        public DbSet<Doctor> DoctorLists { get; set; }

        public DbSet<DiagnozList> DiagnozLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

        }
    }
}
