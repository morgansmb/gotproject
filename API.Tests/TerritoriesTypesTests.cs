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
    public class TerritoriesTypesTests
    {
        [TestMethod]
        public void GetAllTerritoriesTypes_ShouldReturnAllTerritoriesTypes()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<TerritoryTypeDTO> dtoTerritoriesTypes = new List<TerritoryTypeDTO>();

            /* Récupération depuis la couche Business */
            var testTerritoriesTypes = manager.GetAllTerritoriesTypes();

            /* Récupération via API */
            var territoryTypeController = new TerritoriesTypesController();
            dtoTerritoriesTypes = territoryTypeController.GetAllTerritoriesTypes() as List<TerritoryTypeDTO>;

            Assert.AreEqual(dtoTerritoriesTypes.Count, testTerritoriesTypes.Count);
        }

        [TestMethod]
        public void GetTerritoryType_ShouldReturnCorrectTerritoryType()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            /* Récupération depuis la couche Business */
            var testTerritoryType = manager.GetTerritoryType(1);

            /* Récupération via API */
            var territoryTypeController = new TerritoriesTypesController();
            var dtoTerritoryType = territoryTypeController.Get(1) as OkNegotiatedContentResult<TerritoryTypeDTO>;

            Assert.IsNotNull(dtoTerritoryType);
            Assert.AreEqual(dtoTerritoryType.Content.Type, testTerritoryType.Type);
        }

        [TestMethod]
        public void GetTerritoryType_ShouldNotFindTerritoryType()
        {
            /* Récupération via API */
            var territoryTypeController = new TerritoriesController();
            var dtoTerritoryType = territoryTypeController.Get(999);

            Assert.IsInstanceOfType(dtoTerritoryType, typeof(NotFoundResult));
        }
    }
}
