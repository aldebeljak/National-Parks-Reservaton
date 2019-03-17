using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace Capstone.Tests
{
    [TestClass]
    public class CampsiteSqlDAOTests : ReservationSystemTests
    {
        [TestMethod]
        public void GetCampsites_Returns_All_Campsites()
        {
            CampsiteSqlDAO dao = new CampsiteSqlDAO(base.ConnectionString);
            IList<CampsiteModel> campsites = dao.GetCampsites(base.CampgroundId);
            Assert.AreEqual(base.CampsiteCount, campsites.Count);
        }

        [TestMethod]
        public void GetAvailableReservations_Returns_List_At_Most_5_Available_Campsites()
        {
            CampsiteSqlDAO dao = new CampsiteSqlDAO(base.ConnectionString);
            CampgroundModel campground = new CampgroundModel();
            campground.Campground_Id = base.CampgroundId;
            IList<CampsiteModel> availableSites = dao.GetAvailableReservations(campground, new DateTime(2019, 03, 01), new DateTime(2019, 03, 05));
            Assert.AreEqual(Math.Min(base.CampsiteCount, 5), availableSites.Count);
        }

        [TestMethod]
        public void GetAvailableReservations_Returns_0_Sites()
        {
            CampsiteSqlDAO dao = new CampsiteSqlDAO(base.ConnectionString);
            CampgroundModel campground = new CampgroundModel();
            campground.Campground_Id = base.CampgroundId;
            IList<CampsiteModel> availableSites = dao.GetAvailableReservations(campground, new DateTime(2019, 01, 01), new DateTime(2019, 02, 05));
            Assert.AreEqual(Math.Min(base.CampsiteCount, 5), availableSites.Count);
        }
    }
}
