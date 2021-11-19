using Hospital.Models;
using Hospital.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.TagHelpers
{
    [HtmlTargetElement("table", Attributes = "patient-table")]

    public class PatientTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PatientTagHelper(IUrlHelperFactory _helperFactory)
        {
            urlHelperFactory = _helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public string PageAction { get; set; }
        public SortState  SortStateForSurname { get; set; }
        public SortState  SortStateForIIN { get; set; }
        public string Surname { get; set; }
        public string IIN{ get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "table";
            output.Attributes.SetAttribute("class", "table table-bordered table-striped table-primary table-hover ");
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder linkSottBySurname = new TagBuilder("a");
            TagBuilder linkSottByIIN = new TagBuilder("a");
            linkSottBySurname.InnerHtml.Append("ФИО");
            linkSottByIIN.InnerHtml.Append("ИИН");
            linkSottBySurname.Attributes["href"] = urlHelper.Action(PageAction, new { iin = IIN, surname = Surname, page = 1, sortState = SortStateForSurname});
            linkSottByIIN.Attributes["href"] = urlHelper.Action(PageAction, new { iin = IIN, surname = Surname, page = 1, sortState = SortStateForIIN });
            output.Content.AppendHtml($"<thead><tr><th>");
            output.Content.AppendHtml(linkSottBySurname);
            output.Content.AppendHtml($"</th><th>");
            output.Content.AppendHtml(linkSottByIIN);
            output.Content.AppendHtml($"</th></tr><tr></thead><tbody>");
            
            foreach (Patient p in Patients)
            {
                output.Content.AppendHtml($"<td>{p.Surname} {p.Name} {p.Patronymic}</td> <td> {p.IIN} </td></tr><tr>");
            }
            output.Content.AppendHtml($"</tr></tbody></table>");

        }
    }
}
