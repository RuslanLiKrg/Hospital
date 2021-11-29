using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class FilterViewModel
    {
        public string SelectedIIN { get; set; }
        public string SelectedSurname { get; set; }
        public FilterViewModel(string iin, string surname)
        {
            SelectedIIN = iin;
            SelectedSurname = surname;
        }

    }
}
