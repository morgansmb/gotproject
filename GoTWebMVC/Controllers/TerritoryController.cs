using GoTWebMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GoTWebMVC.Controllers
{
    public class TerritoryController : Controller
    {

        // GET: Territory
        public async Task<ActionResult> List()
        {
            List<DisplayTerritoryModel> displayTerritories = new List<DisplayTerritoryModel>();
            IEnumerable<TerritoryModel> territories = new List<TerritoryModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/territories");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    territories = JsonConvert.DeserializeObject<List<TerritoryModel>>(temp);
                }

                foreach (TerritoryModel model in territories)
                {
                    HouseModel houseModel = new HouseModel();
                    TerritoryTypeModel territoryType = new TerritoryTypeModel();

                    response = await client.GetAsync("api/houses/" + model.ID_House);
                    if (response.IsSuccessStatusCode)
                    {
                        string temp = await response.Content.ReadAsStringAsync();
                        houseModel = JsonConvert.DeserializeObject<HouseModel>(temp);
                    }

                    response = await client.GetAsync("api/territoriestypes/" + model.ID_Type);
                    if (response.IsSuccessStatusCode)
                    {
                        string temp = await response.Content.ReadAsStringAsync();
                        territoryType = JsonConvert.DeserializeObject<TerritoryTypeModel>(temp);
                    }

                    displayTerritories.Add(new DisplayTerritoryModel(model.ID, houseModel, territoryType));
                }
            }

            return View(displayTerritories);
        }

        // GET: Territory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Territory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Territory/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Territory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Territory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Territory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Territory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
