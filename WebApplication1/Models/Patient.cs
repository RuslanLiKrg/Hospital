using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}