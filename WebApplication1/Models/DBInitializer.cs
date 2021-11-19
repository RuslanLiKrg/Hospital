using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext context)//Данный метод будет добавлять все три строки в таблицу Phones, которая будет храниться в таблице PhoneContext
        {
            context.Phones.Add(new Phone() { Name = "Huawei", Price = 45000, Producer = "Chine" });
            context.Phones.Add(new Phone() { Name = "LG", Price = 56000, Producer = "Korea" });
            context.Phones.Add(new Phone() { Name = "SAM", Price = 10000, Producer = "Viet" });
            base.Seed(context);
        }
    }
}