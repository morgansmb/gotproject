using API.Models;
using System.Collections.Generic;


namespace GoTWebMVC.Models
{
    public class HouseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NumberOfUnits { get; set; }
        public List<CharacterModel> Housers { get; set; }
        
        public HouseModel() { }

        public HouseModel(HouseDTO house)
        {
            ID = house.ID;
            Name = house.Name;
            NumberOfUnits = house.NumberOfUnits;
            foreach(CharacterDTO ch in house.Housers)
            {
                Housers.Add(new CharacterModel(ch));
            }
        }

        public HouseModel(int id, string name, int numberOfUnits)
        {
            ID = id;
            Name = name;
            NumberOfUnits = numberOfUnits;
            Housers = new List<CharacterModel>();
        }
    }
}