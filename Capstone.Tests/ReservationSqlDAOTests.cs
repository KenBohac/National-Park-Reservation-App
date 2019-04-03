using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationSqlDAOTests : DALTestSetUp

    {
        [TestMethod]
        public void GetAllReservations_ShouldReturn1()
        {
            //Arrange
            ReservationSqlDAO dao = new ReservationSqlDAO(ConnectionString);
            //Act
            IList<Reservation> output = dao.GetAllReservations(this.SiteId);
            //Assert
            Assert.AreEqual(1, output.Count);
        }
        [TestMethod]
        public void GetReservation_ShouldReturnCorrectInformation_AndConvertReservationToReaderWorks()
        {
            ReservationSqlDAO dao = new ReservationSqlDAO(ConnectionString);
            Reservation reservation = dao.GetReservation(this.ReservationId);
            Assert.AreEqual("Flintstone", reservation.Name);
        }
        [TestMethod]
        public void CreateReservation_ShouldIncreaseCountby1()
        {
            Reservation reservation = new Reservation();
            reservation.FromDate = Convert.ToDateTime("2019-02-14");
            reservation.ToDate = Convert.ToDateTime("2019-02-16");
            reservation.Name = "Marky Mark and the Funky Bunch";
            reservation.SiteId = this.SiteId;
            ReservationSqlDAO dao = new ReservationSqlDAO(ConnectionString);
            dao.CreateReservation(reservation);
            
            IList<Reservation> reservationList = dao.GetAllReservations(this.SiteId);
            Assert.AreEqual(2, reservationList.Count);
        }
    }
}
