using EntitiesLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ThronesTournamentManager
    {
        /*
         * 
         * GESTION DES PERSONNAGES
         * 
         */

        public List<EntitiesLayer.Character> GetAllCharacters()
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            List<Character> list = manager.DALServer.GetAllCharacters();

            return list;
        }

        public EntitiesLayer.Character GetCharacter(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            var result = manager.DALServer.GetCharacter(id);

            return result;
        }

        public void UpdateCharacter(EntitiesLayer.Character character)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.UpdateCharacter(character);
        }

        public void AddCharacter(EntitiesLayer.Character character)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.AddCharacter(character);
        }

        public void DeleteCharacter(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.DeleteCharacter(id);
        }

        /*
         * 
         * GESTION DES MAISONS
         * 
         */

        public List<EntitiesLayer.House> GetAllHouses()
        {

            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            List<House> list = manager.DALServer.GetAllHouses();

            return list;
        }

        public EntitiesLayer.House GetHouse(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            var result = manager.DALServer.GetHouse(id);

            return result;
        }

        public void AddHouse(EntitiesLayer.House house)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.AddHouse(house);
        }

        public void UpdateHouse(EntitiesLayer.House house)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.UpdateHouse(house);
        }

        public void DeleteHouse(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.DeleteHouse(id);
        }

        /*
         * 
         * GESTION DES TERRITOIRES
         * 
         */

        public List<EntitiesLayer.Territory> GetAllTerritories()
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            List<Territory> list = manager.DALServer.GetAllTerritories();

            return list;
        }

        public EntitiesLayer.Territory GetTerritory(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            var result = manager.DALServer.GetTerritory(id);

            return result;
        }

        public void AddTerritory(EntitiesLayer.Territory territory)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.AddTerritory(territory);
        }

        public void UpdateTerritory(EntitiesLayer.Territory territory)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.UpdateTerritory(territory);
        }

        public void DeleteTerritory(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.DeleteTerritory(id);
        }

        /*
         * 
         * GESTION DES TYPES DE TERRITOIRES
         * 
         */

        public List<EntitiesLayer.TerritoryType> GetAllTerritoriesTypes()
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            List<TerritoryType> list = manager.DALServer.GetAllTerritoriesTypes();

            return list;
        }

        public EntitiesLayer.TerritoryType GetTerritoryType(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            var result = manager.DALServer.GetTerritoryType(id);

            return result;
        }

        public void AddTerritoryType(EntitiesLayer.TerritoryType territoryType)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.AddTerritoryType(territoryType);
        }

        public void UpdateTerritoryType(EntitiesLayer.TerritoryType territoryType)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.UpdateTerritoryType(territoryType);
        }

        public void DeleteTerritoryType(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.DeleteTerritoryType(id);
        }

        /*
         * 
         * GESTION DES COMBATS
         * 
         */

        public List<EntitiesLayer.Fight> GetAllFights()
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            List<Fight> list = manager.DALServer.GetAllFights();

            return list;
        }

        public EntitiesLayer.Fight GetFight(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            var result = manager.DALServer.GetFight(id);

            return result;
        }

        public void AddFight(EntitiesLayer.Fight fight)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.AddFight(fight);
        }

        public void UpdateFight(EntitiesLayer.Fight fight)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.UpdateFight(fight);
        }

        public void DeleteFight(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.DeleteFight(id);
        }

        /*
         * 
         * GESTION DES GUERRES
         * 
         */

        public List<EntitiesLayer.War> GetAllWars()
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            List<War> list = manager.DALServer.GetAllWars();

            return list;
        }

        public EntitiesLayer.War GetWar(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;
            var result = manager.DALServer.GetWar(id);

            return result;
        }

        public void AddWar(EntitiesLayer.War war)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.AddWar(war);
        }

        public void UpdateWar(EntitiesLayer.War war)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.UpdateWar(war);
        }

        public void DeleteWar(int id)
        {
            DataAccessLayer.DALManager manager = DataAccessLayer.DALManager.Instance;

            manager.DALServer.DeleteWar(id);
        }
    }
}
