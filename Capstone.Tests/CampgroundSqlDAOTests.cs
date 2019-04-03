using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
   
    [TestClass]
    public class CampgroundSqlDAOTests : DALTestSetUp
    {
        [TestMethod]
        public void GetAllCampgrounds_ShouldReturn1()
        {
            //Arrange
            CampgroundSqlDAO dao = new CampgroundSqlDAO(ConnectionString);
            //Act
            IList<Campground> output = dao.GetAllCampgrounds(this.ParkId);
            //Assert
            Assert.AreEqual(1, output.Count);
        }
        [TestMethod]
        public void GetCampground_ShouldReturnCorrectInformation_AndConvertParkToReaderWorks()
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(ConnectionString);
            Campground campground = dao.GetCampground(this.CampgroundId);
            Assert.AreEqual("LaLa Land", campground.Name );
        }
    }
}


