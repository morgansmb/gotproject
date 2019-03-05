using API.Models;
using BusinessLayer;
using EntitiesLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class WarsController : ApiController
    {
        // GET: api/Wars
        public IEnumerable<WarDTO> GetAllWars()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<WarDTO> list = new List<WarDTO>();

            foreach (var element in manager.GetAllWars())
            {
                list.Add(new WarDTO(element));
            }

            return list;
        }

        // GET: api/Wars/{id}
        public IHttpActionResult Get(int id)
        {
            War result;
            ThronesTournamentManager manager = new ThronesTournamentManager();

            result = manager.GetWar(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(new WarDTO(result));
        }

        // POST: api/Wars
        public IHttpActionResult Post([FromBody]WarDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddWar(value.Transform());

            return Ok();
        }

        // PUT: api/Wars/{id}
        public IHttpActionResult Put(int id, [FromBody]WarDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.UpdateWar(value.Transform());

            return Ok();
        }

        // DELETE: api/Wars/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.DeleteWar(id);

            return Ok();
        }
    }
}
