using System.Collections.Generic;
using System.Web.Http.Results;
using API.Controllers;
using API.Models;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace API.Tests
{
    [TestClass]
    public class FightsTests
    {
        [TestMethod]
        public void GetAllFights_ShouldReturnAllFights()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<FightDTO> dtoFights = new List<FightDTO>();

            /* Récupération depuis la couche Business */
            var testFights = manager.GetAllFights();

            /* Récupération via API */
            var fightController = new FightsController();
            dtoFights = fightController.GetAllFights() as List<FightDTO>;

            Assert.AreEqual(dtoFights.Count, testFights.Count);
        }

        [TestMethod]
        public void GetFight_ShouldReturnCorrectFight()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            /* Récupération depuis la couche Business */
            var testFight = manager.GetFight(1);

            /* Récupération via API */
            var fightController = new FightsController();
            var dtoFight = fightController.Get(1) as OkNegotiatedContentResult<FightDTO>;

            Assert.IsNotNull(dtoFight);
            Assert.AreEqual(dtoFight.Content.ID_Territory, testFight.ID_Territory);
            Assert.AreEqual(dtoFight.Content.ID_War, testFight.ID_War);
            Assert.AreEqual(dtoFight.Content.FirstCharacter.FirstName, testFight.FirstCharacter.FirstName);
        }

        [TestMethod]
        public void GetFight_ShouldNotFindFight()
        {
            /* Récupération via API */
            var fightController = new FightsController();
            var dtoFight = fightController.Get(999);

            Assert.IsInstanceOfType(dtoFight, typeof(NotFoundResult));
        }
    }
}
