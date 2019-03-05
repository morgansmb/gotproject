using System.Collections.Generic;
using System.Linq;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DALSQLServer : IDAL
    {
        /*
        * GESTION DES PERSONNAGES
        */

        public List<EntitiesLayer.Character> GetAllCharacters()
        {
            List<EntitiesLayer.Character> list = new List<EntitiesLayer.Character>();
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            foreach (Character element in bdd.Characters)
            {
                list.Add(ConvertToCharacter(element));
            }
            return list;
        }

        public EntitiesLayer.Character GetCharacter(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Characters.SingleOrDefault(c => c.Id == id);

            return ConvertToCharacter(result);
        }

        public void AddCharacter(EntitiesLayer.Character character)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var newChar = new Character();
            newChar.lastName = character.LastName;
            newChar.firstName = character.FirstName;
            newChar.bravoury = character.Bravoury;
            newChar.crazyness = character.Crazyness;
            newChar.house_char = character.ID_House;
            newChar.pv = character.PV;

            bdd.Characters.Add(newChar);

            bdd.SaveChanges();
        }

        public void UpdateCharacter(EntitiesLayer.Character ch)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Character objEntity = bdd.Characters.FirstOrDefault(c => c.Id == ch.ID);

            objEntity.lastName = ch.LastName;
            objEntity.firstName = ch.FirstName;
            objEntity.pv = ch.PV;
            objEntity.bravoury = ch.Bravoury;
            objEntity.crazyness = ch.Crazyness;

            bdd.SaveChanges();
        }

        public void DeleteCharacter(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Character objEntity = bdd.Characters.FirstOrDefault(c => c.Id == id);
            bdd.Characters.Remove(objEntity);

            bdd.SaveChanges();
        }

        private EntitiesLayer.Character ConvertToCharacter(Character element)
        {
            EntitiesLayer.Character c = new EntitiesLayer.Character();

            if (element != null)
            {
                c.ID = element.Id;
                c.Bravoury = element.bravoury;
                c.Crazyness = element.crazyness;
                c.FirstName = element.firstName;
                c.LastName = element.lastName;
                c.ID_House = (int)element.house_char;
                c.PV = element.pv;
            }
            else
                c = null;
            
            return c;
        }

        private IEnumerable<EntitiesLayer.Character> GetCharactersByHouse(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            List<EntitiesLayer.Character> list = new List<EntitiesLayer.Character>();

            var result = bdd.Characters.Where(ch => ch.house_char == id);
            foreach (Character ch in result)
            {
                list.Add(ConvertToCharacter(ch));
            }

            return list;
        }

        /*
         * GESTION DES MAISONS
         */

        public List<EntitiesLayer.House> GetAllHouses()
        {
            List<EntitiesLayer.House> list = new List<EntitiesLayer.House>();
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            /* Aucune utilité de récupérer les Housers ici */
            foreach (House element in bdd.Houses)
            {   
                list.Add(ConvertToHouse(element));
            }
            return list;
        }

        public EntitiesLayer.House GetHouse(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Houses.SingleOrDefault(h => h.Id == id);
            var convertedHouse = ConvertToHouse(result);

            if (convertedHouse != null)
            {
                /* Récupération des Housers car cette méthode est appelée pour le détail d'une House et dans le détail on a les Housers */
                foreach (EntitiesLayer.Character ch in GetCharactersByHouse(convertedHouse.ID))
                {
                    convertedHouse.AddHouser(ch);
                }
            }
            
            return convertedHouse;
        }

        public void AddHouse(EntitiesLayer.House house)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var newHouse = new House();

            newHouse.name = house.Name;
            newHouse.numberOfUnities = house.NumberOfUnities;

            bdd.Houses.Add(newHouse);

            bdd.SaveChanges();
        }

        public void UpdateHouse(EntitiesLayer.House house)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            House objEntity = bdd.Houses.FirstOrDefault(h => h.Id == house.ID);

            objEntity.name = house.Name;
            objEntity.numberOfUnities = house.NumberOfUnities;

            bdd.SaveChanges();
        }

        public void DeleteHouse(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            House objEntity = bdd.Houses.FirstOrDefault(h => h.Id == id);
            bdd.Houses.Remove(objEntity);

            bdd.SaveChanges();
        }

        private EntitiesLayer.House ConvertToHouse(House element)
        {
            EntitiesLayer.House h = new EntitiesLayer.House();

            if (element != null)
            {
                h.ID = element.Id;
                h.NumberOfUnities = element.numberOfUnities;
                h.Name = element.name;
            }
            else
                h = null;

            return h;
        }

        /*
         * GESTION DES TERRITOIRES
         */

        public List<EntitiesLayer.Territory> GetAllTerritories()
        {
            List<EntitiesLayer.Territory> list = new List<EntitiesLayer.Territory>();
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            foreach (Territory element in bdd.Territories)
            {
                list.Add(ConvertToTerritory(element));
            }
            return list;
        }

        public EntitiesLayer.Territory GetTerritory(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Territories.SingleOrDefault(t => t.Id == id);

            return ConvertToTerritory(result);
        }

        public void AddTerritory(EntitiesLayer.Territory territory)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var newTerritory = new Territory();
            newTerritory.owner = territory.ID_House;
            newTerritory.type = territory.ID_Type;

            bdd.Territories.Add(newTerritory);

            bdd.SaveChanges();
        }

        public void UpdateTerritory(EntitiesLayer.Territory territory)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Territory objEntity = bdd.Territories.FirstOrDefault(t => t.Id == territory.ID);

            objEntity.owner = territory.ID_House;
            objEntity.type  = territory.ID_Type;

            bdd.SaveChanges();
        }

        public void DeleteTerritory(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Territory objEntity = bdd.Territories.FirstOrDefault(t => t.Id == id);
            bdd.Territories.Remove(objEntity);

            bdd.SaveChanges();
        }

        private EntitiesLayer.Territory ConvertToTerritory(Territory element)
        {
            EntitiesLayer.Territory territory = new EntitiesLayer.Territory();

            if (element != null)
            {
                territory.ID = element.Id;
                territory.ID_Type = element.type;
                territory.ID_House = element.owner;
            }
            else
                territory = null;

            return territory;
        }

        private EntitiesLayer.TerritoryType GetTerritoryTypeByTerritory(int type_id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.TerritoriesTypes.SingleOrDefault(t => t.Id == type_id);

            return new EntitiesLayer.TerritoryType(result.Id, result.type);
        }

        private EntitiesLayer.House GetHouseByTerritory(int owner_id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Houses.SingleOrDefault(h => h.Id == owner_id);

            return ConvertToHouse(result);
        }

        /*
         * GESTION DES TYPES DE TERRITOIRES
         */

        public List<EntitiesLayer.TerritoryType> GetAllTerritoriesTypes()
        {
            List<EntitiesLayer.TerritoryType> list = new List<EntitiesLayer.TerritoryType>();
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            foreach (Territory_Type element in bdd.TerritoriesTypes)
            {
                list.Add(ConvertToTerritoryType(element));
            }
            return list;
        }

        public EntitiesLayer.TerritoryType GetTerritoryType(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.TerritoriesTypes.SingleOrDefault(t => t.Id == id);

            return ConvertToTerritoryType(result);
        }

        public void AddTerritoryType(EntitiesLayer.TerritoryType territoryType)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var newTerritoryType = new Territory_Type();
            newTerritoryType.type = territoryType.Type;

            bdd.TerritoriesTypes.Add(newTerritoryType);

            bdd.SaveChanges();
        }

        public void UpdateTerritoryType(EntitiesLayer.TerritoryType territoryType)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Territory_Type objEntity = bdd.TerritoriesTypes.FirstOrDefault(t => t.Id == territoryType.ID);

            objEntity.type = territoryType.Type;

            bdd.SaveChanges();
        }

        public void DeleteTerritoryType(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Territory_Type objEntity = bdd.TerritoriesTypes.FirstOrDefault(t => t.Id == id);
            bdd.TerritoriesTypes.Remove(objEntity);

            bdd.SaveChanges();
        }

        private EntitiesLayer.TerritoryType ConvertToTerritoryType(Territory_Type element)
        {
            EntitiesLayer.TerritoryType territoryType = new EntitiesLayer.TerritoryType();

            if (element != null)
            {
                territoryType.ID = element.Id;
                territoryType.Type = element.type;
            }
            else
                territoryType = null;

            return territoryType;
        }

        /*
        * GESTION DES COMBATS
        */

        public List<EntitiesLayer.Fight> GetAllFights()
        {
            List<EntitiesLayer.Fight> list = new List<EntitiesLayer.Fight>();
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            foreach (Fight element in bdd.Fights)
            {
                list.Add(ConvertToFight(element));
            }

            return list;
        }

        public EntitiesLayer.Fight GetFight(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Fights.SingleOrDefault(f => f.Id == id);

            return ConvertToFight(result);
        }

        public void AddFight(EntitiesLayer.Fight fight)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var newFight = new Fight();

            newFight.character1 = fight.FirstCharacter.ID;
            newFight.character2 = fight.SecondCharacter.ID;
            newFight.winner = fight.ID_Winner;
            newFight.id_war = fight.ID_War;
            newFight.teritory_fight = fight.ID_Territory;
            
            bdd.Fights.Add(newFight);

            bdd.SaveChanges();
        }

        public void UpdateFight(EntitiesLayer.Fight fight)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Fight objEntity = bdd.Fights.FirstOrDefault(f => f.Id == fight.ID);

            objEntity.character1 = fight.FirstCharacter.ID;
            objEntity.character2 = fight.SecondCharacter.ID;
            objEntity.winner = fight.ID_Winner;
            objEntity.id_war = fight.ID_War;
            objEntity.teritory_fight = fight.ID_Territory;

            bdd.SaveChanges();
        }

        public void DeleteFight(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            Fight objEntity = bdd.Fights.FirstOrDefault(f => f.Id == id);
            bdd.Fights.Remove(objEntity);

            bdd.SaveChanges();
        }

        private EntitiesLayer.Fight ConvertToFight(Fight element)
        {
            EntitiesLayer.Fight fight = new EntitiesLayer.Fight();

            if (element != null)
            {
                fight.ID = element.Id;
                fight.ID_Territory = element.teritory_fight;
                fight.ID_Winner = (int)element.winner;
                fight.FirstCharacter = GetCharacter(element.character1);
                fight.SecondCharacter = GetCharacter(element.character2);
                fight.ID_War = element.id_war;
            }
            else
                fight = null;

            return fight;
        }

        /*
        * GESTION DES GUERRES
        */

        public List<EntitiesLayer.War> GetAllWars()
        {
            List<EntitiesLayer.War> list = new List<EntitiesLayer.War>();
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            /* Pareil que pour les maisons, la liste des Fight est remplie uniquement pour le détail d'une War */
            foreach (War element in bdd.Wars)
            {
                list.Add(ConvertToWar(element));
            }
            return list;
        }

        public EntitiesLayer.War GetWar(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Wars.SingleOrDefault(w => w.Id == id);
            var convertedWar = ConvertToWar(result);

            if (convertedWar != null)
            {
                /* Récupération des Housers car cette méthode est appelée pour le détail d'une House et dans le détail on a les Housers */
                foreach (EntitiesLayer.Fight fight in GetFightsByWar(convertedWar.ID))
                {
                    convertedWar.Fights.Add(fight);
                }
            }
            
            return convertedWar;
        }

        public void AddWar(EntitiesLayer.War war)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var newWar = new War();

            newWar.house1 = war.FirstHouse.ID;
            newWar.house2 = war.SecondHouse.ID;
            newWar.winner = war.ID_WinnerHouse;

            bdd.Wars.Add(newWar);

            bdd.SaveChanges();
        }

        public void UpdateWar(EntitiesLayer.War war)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            War objEntity = bdd.Wars.FirstOrDefault(w => w.Id == war.ID);

            objEntity.house1 = war.FirstHouse.ID;
            objEntity.house2 = war.SecondHouse.ID;
            objEntity.winner = war.ID_WinnerHouse; ;

            bdd.SaveChanges();
        }

        public void DeleteWar(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            War objEntity = bdd.Wars.FirstOrDefault(w => w.Id == id);
            bdd.Wars.Remove(objEntity);

            bdd.SaveChanges();
        }

        private EntitiesLayer.War ConvertToWar(War element)
        {
            EntitiesLayer.War war = new EntitiesLayer.War();

            if (element != null)
            {
                war.ID = element.Id;
                war.FirstHouse = GetHouseByWar(element.house1);
                war.SecondHouse = GetHouseByWar(element.house2);
                war.ID_WinnerHouse = element.winner;
            }
            else
                war = null;

            return war;
        }

        private IEnumerable<EntitiesLayer.Fight> GetFightsByWar(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();
            List<EntitiesLayer.Fight> list = new List<EntitiesLayer.Fight>();

            var result = bdd.Fights.Where(f => f.id_war == id);
            foreach (Fight fight in result)
            {
                list.Add(ConvertToFight(fight));
            }

            return list;
        }

        private EntitiesLayer.House GetHouseByWar(int id)
        {
            DataAccessLayer.ThronesTournamentEntities bdd = new ThronesTournamentEntities();

            var result = bdd.Houses.SingleOrDefault(h => h.Id == id);

            return ConvertToHouse(result);
        }
    }
}
