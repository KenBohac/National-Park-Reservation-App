using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    public class SiteDAOTest: CapstoneTests
    {
        [TestClass]
        public class SiteSqlDAOTest : CapstoneTests
        {
            [TestMethod]
            public void GetAllSites_ShouldReturn1()
            {
                //Arrange
                SiteSqlDAO dao = new SiteSqlDAO(ConnectionString);
                //Act
                IList<Site> output = dao.GetAllSites(this.CampgroundId);
                //Assert
                Assert.AreEqual(1, output.Count);
            }
            [TestMethod]
            public void GetSite_ShouldReturnCorrectInformation_AndConvertSiteToReaderWorks()
            {
                SiteSqlDAO dao = new SiteSqlDAO(ConnectionString);
                Site site = dao.GetSite(this.SiteId);
                Assert.AreEqual(10, site.MaxOccupancy);
            }
            [TestMethod]
            public void SearchForOpenSites_ShouldReturn1()
            {
                SiteSqlDAO dao = new SiteSqlDAO(ConnectionString);
                IList <Site> sites = dao.SearchForOpenSites(this.CampgroundId, Convert.ToDateTime("2019-02-22"), Convert.ToDateTime("2019-02-24"));
                Assert.AreEqual(1, sites.Count);
            }
        }
    }
}
