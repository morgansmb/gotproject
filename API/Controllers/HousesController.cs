using API.Models;
using BusinessLayer;
using EntitiesLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class HousesController : ApiController
    {
        // GET: api/Houses
        public IEnumerable<HouseDTO> GetAllHouses()
        {
            ThronesTournamentManager manager = new ThronesTournamentManager();
            List<HouseDTO> list = new List<HouseDTO>();

            foreach (var element in manager.GetAllHouses())
            {
                list.Add(new HouseDTO(element));
            }

            return list;
        }

        // GET: api/Houses/{id}
        public IHttpActionResult Get(int id)
        {
            House result;
            ThronesTournamentManager manager = new ThronesTournamentManager();

            result = manager.GetHouse(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(new HouseDTO(result));
        }

        // POST: api/Houses
        public IHttpActionResult Post([FromBody]HouseDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.AddHouse(value.Transform());

            return Ok();
        }

        // PUT: api/Houses/{id}
        public IHttpActionResult Put(int id, [FromBody]HouseDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.UpdateHouse(value.Transform());

            return Ok();
        }

        // DELETE: api/Houses/{id}
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            ThronesTournamentManager m = new ThronesTournamentManager();
            m.DeleteHouse(id);

            return Ok();
        }
    }
}
