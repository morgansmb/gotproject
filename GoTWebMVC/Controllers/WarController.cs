using GoTWebMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GoTWebMVC.Controllers
{
    public class WarController : Controller
    {
        // GET: War
        public async Task<ActionResult> List()
        {
            IEnumerable<WarModel> wars = new List<WarModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/wars");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    wars = JsonConvert.DeserializeObject<List<WarModel>>(temp);
                }
            }

            return View(wars);
        }

        // GET: War/Details/{id}
        public async Task<ActionResult> Details(int id)
        {
            WarModel detailedWar = new WarModel();

            // Vérification que l'ID passé soit valide
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/wars/"+id);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    detailedWar = JsonConvert.DeserializeObject<WarModel>(temp);
                }
                else { return HttpNotFound(); }
            }

            return View(detailedWar);
        }

        // GET: War/Create
        public async Task<ActionResult> Create()
        {
            CreateWarModel warModel = new CreateWarModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/houses/");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    warModel.Houses = JsonConvert.DeserializeObject<List<HouseModel>>(temp);
                }
                else { return HttpNotFound(); }
            }

            return View(warModel);
        }

        // POST: War/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateWarModel fight)
        {
            WarModel warModel               = new WarModel();
            HttpWebResponse webResponse     = null;
            int idWar;

            if (fight.SelectedAllyHouse == fight.SelectedEnnemyHouse)
            {
                ModelState.AddModelError(string.Empty, "Vous devez sélectionner deux maisons différentes !");

                return View("Create");
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                /* Récupération première maison sélectionnée via API */
                HttpResponseMessage response = await client.GetAsync("api/houses/"+fight.SelectedAllyHouse);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    warModel.FirstHouse = JsonConvert.DeserializeObject<HouseModel>(temp);
                }
                else { return HttpNotFound(); }

                /* Récupération deuxième maison sélectionnée via API */
                response = await client.GetAsync("api/houses/" + fight.SelectedEnnemyHouse);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    warModel.SecondHouse = JsonConvert.DeserializeObject<HouseModel>(temp);
                }
                else { return HttpNotFound(); }
            
                /* Envoie de l'objet WarModel via API POST */
                var request = (HttpWebRequest)WebRequest.Create("http://localhost:62313/api/wars");
                request.Accept = "application/json; charset=utf-8";
                request.Method = "POST";

                var content = new JavaScriptSerializer().Serialize(warModel);
                var data = Encoding.ASCII.GetBytes(content);

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                webResponse = (HttpWebResponse)request.GetResponse();

                /* Récupération du nombre de War pour avoir l'ID pour redirection sur la page de Détails de la Guerre créee */
                response = await client.GetAsync("api/wars/");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    idWar = JsonConvert.DeserializeObject<List<WarModel>>(temp).Count;
                }
                else { return HttpNotFound(); }
            }

            return RedirectToAction("Details", new { id = idWar });
        }

        // GET: War/Update/{id}
        public async Task<ActionResult> Update(int id)
        {
            WarModel warModel = new WarModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/wars/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    warModel = JsonConvert.DeserializeObject<WarModel>(temp);
                }
                else { return HttpNotFound(); }
            }

            /* Vérification que la guerre comporte au moins 1 combat */
            if (warModel.Fights.Count == 0) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            /* Obtention de la maison vainqueure */
            warModel.ID_WinnerHouse = GetWarWinner(warModel);

            /* Envoie de l'objet WarModel via API POST */
            var request = (HttpWebRequest)WebRequest.Create("http://localhost:62313/api/wars/"+warModel.ID);
            request.Accept = "application/json; charset=utf-8";
            request.Method = "PUT";

            var content = new JavaScriptSerializer().Serialize(warModel);
            var data = Encoding.ASCII.GetBytes(content);

            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            return RedirectToAction("Details", new { id = warModel.ID });
        }

        /*
         * Méthode permettant de savoir qui à gagner la guerre
         * Renvoie l'ID de la maison vainqueure
         */
        private int GetWarWinner(WarModel war)
        {
            int ptsAlly = 0, ptsEnnemy = 0;
            int idWinner;

            foreach(FightModel fight in war.Fights)
            {
                if (fight.ID_Winner == fight.FirstCharacter.ID)
                    ptsAlly += 1;
                else
                    ptsEnnemy += 1;
            }

            if (ptsAlly > ptsEnnemy)
                idWinner = war.FirstHouse.ID;
            else if (ptsAlly < ptsEnnemy)
                idWinner = war.SecondHouse.ID;
            else
            {
                Random rnd = new Random();
                int winner = rnd.Next(1, 3);
                if (winner <= 1)
                    idWinner = war.FirstHouse.ID;
                else
                    idWinner = war.SecondHouse.ID;
            }

            return idWinner;
        }
    }
}
