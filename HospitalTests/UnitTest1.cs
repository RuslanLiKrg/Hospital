using Hospital.Controllers;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HospitalTests
{
    public class UnitTest1
    {
        [Fact]
        public void Can_Paginate()
        {
            //arrange
            int idPatient = 1;
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(v => v.GetAllVisitHistoriesByIdPatient(idPatient)).Returns(
                (new VisitHistory[]
                {
                    new VisitHistory{ Date = new DateTime(2020,02,01), PatientId = 1},
                    new VisitHistory{ Date = new DateTime(2021,03,02), PatientId = 1},
                    new VisitHistory{ Date = new DateTime(2021,04,12), PatientId = 1},
                    new VisitHistory{ Date = new DateTime(2021,05,25), PatientId = 1},
                    new VisitHistory{ Date = new DateTime(2021,06,14), PatientId = 1},
                }).AsQueryable<VisitHistory>()
                );
            VisitHistoryController controller = new VisitHistoryController(mock.Object);
            controller.countItemOnOnePage = 4;

            //act
            IEnumerable<VisitHistory> result = controller.ShowAllVisitHistoryByIdPatient(idPatient).ViewData.Model as IEnumerable<VisitHistory>;

            //assert
            VisitHistory[] visitHistories = result.ToArray();
            Assert.True(visitHistories.Length == 4);
            Assert.Equal(2020, visitHistories[0].Date.Year);
            Assert.Equal(2021, visitHistories[1].Date.Year);
        }

       

    }
}
