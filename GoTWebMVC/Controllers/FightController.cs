using GoTWebMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace GoTWebMVC.Controllers
{
    public class FightController : Controller
    {

        // GET: Fight/Details/{id}
        public async Task<ActionResult> Details(int id)
        {
            FightModel fightModel = new FightModel();

            if (id <= 0)
                return HttpNotFound();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                /* Récupération de la guerre sélectionnée via API */
                HttpResponseMessage response = await client.GetAsync("api/fights/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    fightModel = JsonConvert.DeserializeObject<FightModel>(temp);
                }
                else { return HttpNotFound(); }
            }

            return View(fightModel);
        }

        // GET: Fight/Create
        public async Task<ActionResult> Create(int id)
        {
            CreateFightModel fightModel                     = new CreateFightModel();
            List<CharacterModel> charactersModels           = new List<CharacterModel>();
            List<TerritoryModel> territoriesModels          = new List<TerritoryModel>();
            List<TerritoryTypeModel> territoriesTypesModel  = new List<TerritoryTypeModel>();
            TerritoryModel alliedTerritory                  = new TerritoryModel();
            TerritoryModel ennemyTerritory                  = new TerritoryModel();

            if (id <= 0)
                return HttpNotFound();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62313");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                /* Récupération de la guerre sélectionnée via API */
                HttpResponseMessage response = await client.GetAsync("api/wars/"+id);
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    fightModel.War = JsonConvert.DeserializeObject<WarModel>(temp);
                    
                    if (fightModel.War.ID_WinnerHouse != null)
                    {
                        return HttpNotFound();
                    }
                    
                }
                else { return HttpNotFound(); }

                /* Récupération des personnages via API */
                response = await client.GetAsync("api/characters/");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    charactersModels = JsonConvert.DeserializeObject<List<CharacterModel>>(temp);

                    /* Sélection des personnages associés à la première maison de la guerre */
                    fightModel.AlliesCharacters = charactersModels.Where(c => c.ID_House == fightModel.War.FirstHouse.ID);

                    /* Sélection des personnages associés à la deuxième maison de la guerre */
                    fightModel.EnnemiesCharacters = charactersModels.Where(c => c.ID_House == fightModel.War.SecondHouse.ID);
                }
                else { return HttpNotFound(); }

                /* Récupération des territoires */
                response = await client.GetAsync("api/territories/");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    territoriesModels = JsonConvert.DeserializeObject<List<TerritoryModel>>(temp);

                    alliedTerritory = territoriesModels.SingleOrDefault(t => t.ID_House == fightModel.War.FirstHouse.ID);
                    ennemyTerritory = territoriesModels.SingleOrDefault(t => t.ID_House == fightModel.War.SecondHouse.ID);
                }
                else { return HttpNotFound(); }

                /* Récupération des types de territoires */
                response = await client.GetAsync("api/territoriestypes/");
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    territoriesTypesModel = JsonConvert.DeserializeObject<List<TerritoryTypeModel>>(temp);

                    /* Récupération du type de territoire associé à la première maison */
                    fightModel.AlliesTerritory = territoriesTypesModel.SingleOrDefault(t => t.ID == alliedTerritory.ID);
                    fightModel.EnnemyTerritory = territoriesTypesModel.SingleOrDefault(t => t.ID == ennemyTerritory.ID);
                }
                else { return HttpNotFound(); }

            }

            return View(fightModel);
        }

        // POST: Fight/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateFightModel fight)
        {
            
            string responseString               = "";
            HttpWebResponse response            = null;
            CharacterModel ally                 = new CharacterModel();
            CharacterModel ennemy               = new CharacterModel();
            List<TerritoryModel> territories    = new List<TerritoryModel>();
            FightModel fightModel               = new FightModel();
            int idFight;


            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:62313");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    /* Récupération du première personnage via API */
                    HttpResponseMessage responseMessage = await client.GetAsync("api/characters/"+fight.SelectedAlly);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string temp = await responseMessage.Content.ReadAsStringAsync();
                        ally = JsonConvert.DeserializeObject<CharacterModel>(temp);

                        fightModel.FirstCharacter = ally;
                    }
                    else { return HttpNotFound(); }

                    /* Récupération du deuxième personnage via API */
                    responseMessage = await client.GetAsync("api/characters/" + fight.SelectedEnnemy);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string temp = await responseMessage.Content.ReadAsStringAsync();
                        ennemy = JsonConvert.DeserializeObject<CharacterModel>(temp);

                        fightModel.SecondCharacter = ennemy;
                    }
                    else { return HttpNotFound(); }

                    /* Récupération de l'ID du territoire du combat via API */
                    responseMessage = await client.GetAsync("api/territories/");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string temp = await responseMessage.Content.ReadAsStringAsync();
                        territories = JsonConvert.DeserializeObject<List<TerritoryModel>>(temp);

                        fightModel.ID_Territory = territories.SingleOrDefault(t => t.ID_House == fight.ID_HouseTerritory).ID;
                    }
                    else { return HttpNotFound(); }

                    fightModel.ID_War = fight.War.ID;
                    fightModel.ID_Winner = Fight(ally, ennemy);

                    var request = (HttpWebRequest)WebRequest.Create("http://localhost:62313/api/fights");
                    request.Accept = "application/json; charset=utf-8";
                    request.Method = "POST";

                    var content = new JavaScriptSerializer().Serialize(fightModel);
                    var data = Encoding.ASCII.GetBytes(content);

                    request.ContentType = "application/json";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    response = (HttpWebResponse)request.GetResponse();

                    responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    responseMessage = await client.GetAsync("api/fights/");
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string temp = await responseMessage.Content.ReadAsStringAsync();
                        idFight = JsonConvert.DeserializeObject<List<FightModel>>(temp).Count;

                        fightModel.FirstCharacter = ally;
                    }
                    else { return HttpNotFound(); }

                    return RedirectToAction("Details", new { id = idFight });
                }
            }
            catch
            {
                return View();
            }
        }


        /*
         * Méthode permettant de décider de l'issue d'un combat entre 2 personnages
         */
        private int Fight(CharacterModel ally, CharacterModel ennemy)
        {
            int ptsAlly = 0, ptsEnnemy = 0;
            int idWinner;
            Random rnd = new Random();

            // On regarde la bravoure
            if (ally.Bravoury > ennemy.Bravoury)
                ptsAlly += 3;
            else
                ptsEnnemy += 3;

            if (ally.Crazyness > ennemy.Crazyness)
                ptsAlly += 2;
            else
                ptsEnnemy += 2;

            if (ally.Pv > ennemy.Pv)
                ptsAlly += 1;
            else
                ptsEnnemy += 1;

            int winner = rnd.Next(1, ptsAlly + ptsEnnemy + 1);

            if (winner < ptsAlly)
                idWinner = ally.ID;
            else
                idWinner = ennemy.ID;

            return idWinner;
        }

    }
}
