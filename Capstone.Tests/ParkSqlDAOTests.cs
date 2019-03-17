using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkSqlDAOTests : ReservationSystemTests
    {
        [TestMethod]
        public void GetParks_Should_Return_All_Parks()
        {
            ParkSqlDAO park = new ParkSqlDAO(this.ConnectionString);
            IList<ParkModel> parks = park.GetParks();
            Assert.AreEqual(ParkCount, parks.Count);

        }
    }
}
