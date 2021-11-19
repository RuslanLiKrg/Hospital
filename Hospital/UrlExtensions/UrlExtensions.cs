using Hospital.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.UrlExtensions
{
    public static class UrlExtensions
    {
        public static SortState PathAndQueryForSurname(this HttpRequest request)
        {
            var d = request.RouteValues["sortState"];
            SortState sortState;
            if (request.RouteValues.ContainsKey("sortState"))
            {
                sortState = request.RouteValues["sortState"].ToString() == SortState.NAME_ASC.ToString() ? SortState.NAME_DESC : SortState.NAME_ASC;
            }
            else
            {
                sortState = SortState.NAME_DESC;
            }

            return sortState;
        }
        public static SortState PathAndQueryForIIN(this HttpRequest request)
        {
            var d = request.RouteValues["sortState"];
            SortState sortState;
            if (request.RouteValues.ContainsKey("sortState"))
            {
                if (request.RouteValues["sortState"].ToString() == SortState.IIN_ASC.ToString() || request.RouteValues["sortState"].ToString() == SortState.IIN_DESC.ToString())
                {
                    sortState = request.RouteValues["sortState"].ToString() == SortState.IIN_ASC.ToString() ? SortState.IIN_DESC : SortState.IIN_ASC;
                    return sortState;

                }
                sortState = SortState.IIN_DESC;
            }
            else
            {
                sortState = SortState.IIN_DESC;
            }
            var s = SortState.NAME_ASC.ToString();
            return sortState;
        }
    }
}
