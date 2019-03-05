using API.Models;

namespace GoTWebMVC.Models
{
    public class CharacterModel
    {
        public int ID { get; set; }
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pv { get; set; }
        public int ID_House { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public CharacterModel() { }

        public CharacterModel(int id, int bravoury, int crazyness, string firstName, string lastName, int pv, int id_house)
        {
            ID          = id;
            Bravoury    = bravoury;
            Crazyness   = crazyness;
            FirstName   = firstName;
            LastName    = lastName;
            Pv          = pv;
            ID_House    = id_house;
        }

        public CharacterModel(CharacterDTO other)
        {
            ID              = other.ID;
            Bravoury        = other.Bravoury;
            Crazyness       = other.Crazyness;
            FirstName       = other.FirstName;
            LastName        = other.LastName;
            Pv              = other.Pv;
            ID_House        = other.ID_House;
        }
    }
}