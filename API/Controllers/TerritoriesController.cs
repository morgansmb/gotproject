using API.Models;
using BusinessLayer;
using EntitiesLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class TerritoriesController : ApiController
    {
        // GET: api/Territories
        public IEnumerable<TerritoryDTO> GetAllTerritories()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<TerritoryDTO> list = new List<TerritoryDTO>();

            foreach (var element in manager.GetAllTerritories())
            {
                list.Add(new TerritoryDTO(element));
            }

            return list;
        }

        // GET: api/Territories/{id}
        public IHttpActionResult Get(int id)
        {
            Territory result;
            ThronesTournamentManager manager = new ThronesTournamentManager();

            result = manager.GetTerritory(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(new TerritoryDTO(result));
        }

        // POST: api/Territories
        public IHttpActionResult Post([FromBody]TerritoryDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddTerritory(value.Transform());

            return Ok();
        }

        // PUT: api/Territories/{id}
        public IHttpActionResult Put(int id, [FromBody]TerritoryDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.UpdateTerritory(value.Transform());

            return Ok();
        }

        // DELETE: api/Territories/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.DeleteTerritory(id);

            return Ok();
        }
    }
}
