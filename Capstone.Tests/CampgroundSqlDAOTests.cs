using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundSqlDAOTests : ReservationSystemTests
    {
        [TestMethod]
        public void GetCampgrounds_ShouldReturn_List_Of_CampgroundModels_Based_On_Park()
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(base.ConnectionString);

            IList<CampgroundModel> campgrounds = dao.GetCampgrounds(base.ParkId);

            Assert.AreEqual(base.CampgroundCount, campgrounds.Count);
        }

        [DataTestMethod]
        [DataRow(1, 2, false)]
        [DataRow(3, 5, true)]
        [DataRow(10, 11, false)]
        public void IsOpen_ShouldReturn_True_If_Campground_IsOpen(int startMonth, int endMonth, bool expected)
        {
            DateTime startDate = new DateTime(2019, startMonth, 1);
            DateTime endDate = new DateTime(2019, endMonth, 1);
            CampgroundSqlDAO dao = new CampgroundSqlDAO(base.ConnectionString);

            CampgroundModel campground = new CampgroundModel();
            campground.Open_From_MM = base.NewOpenFrom;
            campground.Open_To_MM = base.NewOpenTo;

            bool isOpen = dao.IsOpen(campground, startDate, endDate);

            Assert.AreEqual(expected, isOpen);
        }
    }
}
