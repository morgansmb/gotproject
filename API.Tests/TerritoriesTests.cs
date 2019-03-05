using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using API.Controllers;
using API.Models;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.Tests
{
    [TestClass]
    public class TerritoriesTests
    {
        [TestMethod]
        public void GetAllTerritories_ShouldReturnAllTerritories()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<TerritoryDTO> dtoTerritories = new List<TerritoryDTO>();

            /* Récupération depuis la couche Business */
            var testTerritories = manager.GetAllTerritories();

            /* Récupération via API */
            var territoryController = new TerritoriesController();
            dtoTerritories = territoryController.GetAllTerritories() as List<TerritoryDTO>;

            Assert.AreEqual(dtoTerritories.Count, testTerritories.Count);
        }

        [TestMethod]
        public void GetTerritory_ShouldReturnCorrectTerritory()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            /* Récupération depuis la couche Business */
            var testTerritory = manager.GetTerritory(1);

            /* Récupération via API */
            var territoryController = new TerritoriesController();
            var dtoTerritory = territoryController.Get(1) as OkNegotiatedContentResult<TerritoryDTO>;

            Assert.IsNotNull(dtoTerritory);
            Assert.AreEqual(dtoTerritory.Content.ID_Type, testTerritory.ID_Type);
            Assert.AreEqual(dtoTerritory.Content.ID_House, testTerritory.ID_House);
        }

        [TestMethod]
        public void GetTerritory_ShouldNotFindTerritory()
        {
            /* Récupération via API */
            var territoryController = new TerritoriesController();
            var dtoTerritory = territoryController.Get(999);

            Assert.IsInstanceOfType(dtoTerritory, typeof(NotFoundResult));
        }
    }
}
