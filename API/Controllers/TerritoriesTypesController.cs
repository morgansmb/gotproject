using API.Models;
using BusinessLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class TerritoriesTypesController : ApiController
    {
        // GET: api/TerritoriesTypes
        public IEnumerable<TerritoryTypeDTO> GetAllTerritoriesTypes()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<TerritoryTypeDTO> list = new List<TerritoryTypeDTO>();

            foreach (var element in manager.GetAllTerritoriesTypes())
            {
                list.Add(new TerritoryTypeDTO(element));
            }

            return list;
        }

        // GET: api/TerritoriesTypes/{id}
        public IHttpActionResult Get(int id)
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();

            var result = manager.GetTerritoryType(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(new TerritoryTypeDTO(result));
        }

        // POST: api/TerritoriesTypes
        public IHttpActionResult Post([FromBody]TerritoryTypeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddTerritoryType(value.Transform());

            return Ok();
        }

        // PUT: api/TerritoriesTypes/{id}
        public IHttpActionResult Put(int id, [FromBody]TerritoryTypeDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.UpdateTerritoryType(value.Transform());

            return Ok();
        }

        // DELETE: api/TerritoriesTypes/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.DeleteTerritoryType(id);

            return Ok();
        }
    }
}
