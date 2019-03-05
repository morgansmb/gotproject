using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGoT.Models
{
    public class HouseWPFModel
    {
        public List<CharacterWPFModel> Housers { get; set; }
        public string Name { get; set; }
        public int NumberOfUnits { get; set; }
        public int ID { get; set; }

        public HouseWPFModel(string inName, int inNumberOfUnits, int inID)
        {
            Name = inName;
            NumberOfUnits = inNumberOfUnits;
            ID = inID;

        }

        public HouseWPFModel()
        {
            Housers = new List<CharacterWPFModel>();
        }

        override
        public String ToString()
        {
            return (ID + " : Maison " + Name + " contenant " + NumberOfUnits + " unites");
        }

        public EntitiesLayer.House Transform()
        {
            EntitiesLayer.House h = new EntitiesLayer.House(ID, Name, NumberOfUnits);
            return h;
        }
    }
}