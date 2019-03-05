using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using BusinessLayer;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using API.Models;
using API.Controllers;
using System.Web.Http.Results;

namespace API.Tests
{
    /// <summary>
    /// Description résumée pour CharactersTests
    /// </summary>
    [TestClass]
    public class CharactersTests
    {
        [TestMethod]
        public void GetAllCharacters_ShouldReturnAllCharacters()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<CharacterDTO> dtoCharacters = new List<CharacterDTO>();

            /* Récupération depuis la couche Business */
            var testCharacters = manager.GetAllCharacters();

            /* Récupération via API */
            var characterController = new CharactersController();
            dtoCharacters = characterController.GetAllCharacters() as List<CharacterDTO>;

            Assert.AreEqual(dtoCharacters.Count, testCharacters.Count);
        }

        [TestMethod]
        public void GetCharacter_ShouldReturnCorrectCharacter()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            /* Récupération depuis la couche Business */
            var testCharacter = manager.GetCharacter(1);

            /* Récupération via API */
            var characterController = new CharactersController();
            var dtoCharacter = characterController.Get(1) as OkNegotiatedContentResult<CharacterDTO>;

            Assert.IsNotNull(dtoCharacter);
            Assert.AreEqual(dtoCharacter.Content.FirstName, testCharacter.FirstName);
        }

        [TestMethod]
        public void GetCharacter_ShouldNotFindCharacter()
        {
            /* Récupération via API */
            var characterController = new CharactersController();
            var dtoCharacter = characterController.Get(999);

            Assert.IsInstanceOfType(dtoCharacter, typeof(NotFoundResult));
        }
    }
}
