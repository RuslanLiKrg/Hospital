using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class PageInfoVisitHistoryViewModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }/// <summary>
                                             /// кол-во пунктов на странице
                                             /// </summary>
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
