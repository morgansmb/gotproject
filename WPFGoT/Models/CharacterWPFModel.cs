using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGoT.Models
{
    public class CharacterWPFModel
    {
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int ID_House { get; set; }
        public int Pv { get; set; }

        public CharacterWPFModel(int bravoury, int crazyness, string firstName, string lastName, int id, int house, int pv)
        {
            Bravoury = bravoury;
            Crazyness = crazyness;
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            ID_House = house;
            Pv = pv;
        }

        public CharacterWPFModel()
        {
        }

        override
        public String ToString()
        {
            return (ID + " : " + LastName + " " + FirstName + " de la maison " + ID_House + " (PV : " + Pv + ", Brav : " + Bravoury + ", Craz : " + Crazyness + ")");
        }

        /**
         * Transforme l'objet WPF en Character Entity pour l'insérer dans la BDD 
         */
        public Character Transform()
        {
            Character character = new Character();
            character.Bravoury = Bravoury;
            character.Crazyness = Crazyness;
            character.LastName = LastName;
            character.FirstName = FirstName;
            character.ID = ID;
            character.ID_House = ID_House;
            character.PV = Pv;

            return character;
        }
    }
}
