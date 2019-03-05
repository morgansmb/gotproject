using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDAL
    {
        /*
         * GESTION DES PERSONNAGES
         */
        List<EntitiesLayer.Character> GetAllCharacters();
        EntitiesLayer.Character GetCharacter(int id);
        void AddCharacter(EntitiesLayer.Character character);
        void UpdateCharacter(EntitiesLayer.Character character);
        void DeleteCharacter(int id);

        /*
         * GESTION DES MAISONS
         */
        List<EntitiesLayer.House> GetAllHouses();
        EntitiesLayer.House GetHouse(int id);
        void AddHouse(EntitiesLayer.House house);
        void UpdateHouse(EntitiesLayer.House house);
        void DeleteHouse(int id);

        /*
         * GESTION DES TERRITOIRES
         */
        List<EntitiesLayer.Territory> GetAllTerritories();
        EntitiesLayer.Territory GetTerritory(int id);
        void AddTerritory(EntitiesLayer.Territory territory);
        void UpdateTerritory(EntitiesLayer.Territory territory);
        void DeleteTerritory(int id);

        /*
         * GESTION DES TYPES DE TERRITOIRES
         */
        List<EntitiesLayer.TerritoryType> GetAllTerritoriesTypes();
        EntitiesLayer.TerritoryType GetTerritoryType(int id);
        void AddTerritoryType(EntitiesLayer.TerritoryType territoryType);
        void UpdateTerritoryType(EntitiesLayer.TerritoryType territoryType);
        void DeleteTerritoryType(int id);

        /*
        * GESTION DES COMBATS
        */
        List<EntitiesLayer.Fight> GetAllFights();
        EntitiesLayer.Fight GetFight(int id);
        void AddFight(EntitiesLayer.Fight fight);
        void UpdateFight(EntitiesLayer.Fight fight);
        void DeleteFight(int id);

        /*
         * GESTION DES GUERRES
         */
        List<EntitiesLayer.War> GetAllWars();
        EntitiesLayer.War GetWar(int id);
        void AddWar(EntitiesLayer.War war);
        void UpdateWar(EntitiesLayer.War war);
        void DeleteWar(int id);
    }
}
