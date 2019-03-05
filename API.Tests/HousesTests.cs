using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using API.Models;
using API.Controllers;
using System.Web.Http.Results;

namespace API.Tests
{
    /// <summary>
    /// Description résumée pour HousesTests
    /// </summary>
    [TestClass]
    public class HousesTests
    {
        [TestMethod]
        public void GetAllHouses_ShouldReturnAllHouses()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<HouseDTO> dtoHouses = new List<HouseDTO>();

            /* Récupération depuis la couche Business */
            var testHouses = manager.GetAllHouses();

            /* Récupération via API */
            var houseController = new HousesController();
            dtoHouses = houseController.GetAllHouses() as List<HouseDTO>;

            Assert.AreEqual(dtoHouses.Count, testHouses.Count);
        }

        [TestMethod]
        public void GetHouse_ShouldReturnCorrectHouse()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            /* Récupération depuis la couche Business */
            var testHouse = manager.GetHouse(1);

            /* Récupération via API */
            var houseController = new HousesController();
            var dtoHouse = houseController.Get(1) as OkNegotiatedContentResult<HouseDTO>;

            Assert.IsNotNull(dtoHouse);
            Assert.AreEqual(dtoHouse.Content.Name, testHouse.Name);
        }

        [TestMethod]
        public void GetHouse_ShouldNotFindHouse()
        {
            /* Récupération via API */
            var houseController = new HousesController();
            var dtoHouse = houseController.Get(999);

            Assert.IsInstanceOfType(dtoHouse, typeof(NotFoundResult));
        }
    }
}
