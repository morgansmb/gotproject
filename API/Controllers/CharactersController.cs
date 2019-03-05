using API.Models;
using BusinessLayer;
using EntitiesLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class CharactersController : ApiController
    {
        // GET: api/Characters
        public IEnumerable<CharacterDTO> GetAllCharacters()
        {
            List<CharacterDTO> list = new List<CharacterDTO>();
            ThronesTournamentManager m = new ThronesTournamentManager();

            foreach (var element in m.GetAllCharacters())
            {
                list.Add(new CharacterDTO(element));
            }
            return list;
        }

        // GET: api/Characters/{id}
        public IHttpActionResult Get(int id)
        {
            Character result;
            ThronesTournamentManager m = new ThronesTournamentManager();

            result = m.GetCharacter(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(new CharacterDTO(result));
        }

        // POST: api/Characters
        public IHttpActionResult Post([FromBody]CharacterDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddCharacter(value.Transform());

            return Ok();
        }

        // PUT: api/Characters/{id}
        public IHttpActionResult Put(int id, [FromBody]CharacterDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.UpdateCharacter(value.Transform());

            return Ok();
        }

        // DELETE: api/Characters/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.DeleteCharacter(id);

            return Ok();
        }
    }
}
