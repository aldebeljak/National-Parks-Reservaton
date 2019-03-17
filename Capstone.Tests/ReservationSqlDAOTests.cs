using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationSqlDAOTests : ReservationSystemTests
    {
        [TestMethod]
        public void PlaceReservation_Should_Return_ReservationId()
        {
            ReservationSqlDAO dao = new ReservationSqlDAO(base.ConnectionString);

            int newReservationId = dao.PlaceReservation("doesn't matter", base.CampsiteId, DateTime.Now, DateTime.Now);

            Assert.AreEqual(base.NewReservationId + 1, newReservationId);
        }
    }
}
