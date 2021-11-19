using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class PatientContext: DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}