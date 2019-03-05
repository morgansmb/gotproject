using API.Models;
using BusinessLayer;
using EntitiesLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class FightsController : ApiController
    {
        // GET: api/Fights
        public IEnumerable<FightDTO> GetAllFights()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<FightDTO> list = new List<FightDTO>();

            foreach (var element in manager.GetAllFights())
            {
                list.Add(new FightDTO(element));
            }

            return list;
        }

        // GET: api/Fights/{id}
        public IHttpActionResult Get(int id)
        {
            Fight result;
            ThronesTournamentManager manager = new ThronesTournamentManager();

            result = manager.GetFight(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(new FightDTO(result));
        }

        // POST: api/Fights
        public IHttpActionResult Post([FromBody]FightDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddFight(value.Transform());

            return Ok();
        }

        // PUT: api/Fights/{id}
        public IHttpActionResult Put(int id, [FromBody]FightDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.UpdateFight(value.Transform());

            return Ok();
        }

        // DELETE: api/Fights/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.DeleteFight(id);

            return Ok();
        }
    }
}
