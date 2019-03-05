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
    public class WarsTests
    {
        [TestMethod]
        public void GetAllWars_ShouldReturnAllWars()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<WarDTO> dtoWars = new List<WarDTO>();

            /* Récupération depuis la couche Business */
            var testWars = manager.GetAllWars();

            /* Récupération via API */
            var warController = new WarsController();
            dtoWars = warController.GetAllWars() as List<WarDTO>;

            Assert.AreEqual(dtoWars.Count, testWars.Count);
        }

        [TestMethod]
        public void GetWar_ShouldReturnCorrectWar()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            /* Récupération depuis la couche Business */
            var testWar = manager.GetWar(1);

            /* Récupération via API */
            var warController = new WarsController();
            var dtoWar = warController.Get(1) as OkNegotiatedContentResult<WarDTO>;

            Assert.IsNotNull(dtoWar);
            Assert.AreEqual(dtoWar.Content.FirstHouse.Name, testWar.FirstHouse.Name);
            Assert.AreEqual(dtoWar.Content.SecondHouse.Name, testWar.SecondHouse.Name);
        }

        [TestMethod]
        public void GetWar_ShouldNotFindWar()
        {
            /* Récupération via API */
            var warController = new WarsController();
            var dtoWar = warController.Get(999);

            Assert.IsInstanceOfType(dtoWar, typeof(NotFoundResult));
        }
    }
}
