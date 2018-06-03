using System;
using System.Linq;
using ControlScheduleKSTU.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlScheduleKSTU.WebAPI.Tests
{
    [TestClass]
    public class Auditorium
    {
        [TestMethod]
        public void TestSearchMethod()
        {
            AuditoriumService auditoriumService=new AuditoriumService();
            string expected = "1/152";
            var actual = auditoriumService.SearchByName(expected).Result.FirstOrDefault(c => c.Name.Equals(expected));
            Assert.AreEqual(expected, actual?.Name);

        }
        //Тест не должен пройти
        [TestMethod]
        public void TestSearchMethodNotItem()
        {
            AuditoriumService auditoriumService = new AuditoriumService();
            string expected = string.Empty;
            var actual = auditoriumService.SearchByName(expected).Result.FirstOrDefault(c => c.Name.Equals(expected));
            Assert.AreEqual(expected, actual?.Name);
        }
        //Тест не должен пройти
        [TestMethod]
        public void TestSearchMethodNotItem2()
        {
            AuditoriumService auditoriumService = new AuditoriumService();
            string expected = "1/785";
            var actual = auditoriumService.SearchByName(expected).Result.FirstOrDefault(c => c.Name.Equals(expected));
            Assert.AreEqual(expected, actual?.Name);
        }
    }
}
