using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;


namespace Capstone.Tests
{
    [TestClass]
    public class ParkSqlDAOTest : CapstoneTests
    {
        [TestMethod]
        public void GetAllParks_ShouldReturn1()
        {
            //Arrange
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            //Act
            IList<Park> output = dao.GetAllParks();
            //Assert
            Assert.AreEqual(1, output.Count);
        }
        [TestMethod]
        public void GetPark_ShouldReturnCorrectInformation_AndConvertParkToReaderWorks()
        {
            ParkSqlDAO dao = new ParkSqlDAO(ConnectionString);
            Park park = dao.GetPark(this.ParkId);
            Assert.AreEqual("Test Park", park.Name);
        }
    }
}
