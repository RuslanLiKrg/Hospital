using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class History
    {
        public string SpesialistType { get; set; }
        public string FIODoctor { get; set; }
        public string Diagnose { get; set; }
        public string Complaints { get; set; }
        public DateTime Date_ { get; set; }
    }
}