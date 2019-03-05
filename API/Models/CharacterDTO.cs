using EntitiesLayer;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class CharacterDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember(IsRequired = true)]
        public int Bravoury { get; set; }
        [DataMember(IsRequired = true)]
        public int Crazyness { get; set; }
        [DataMember(IsRequired = true)]
        public string FirstName { get; set; }
        [DataMember(IsRequired = true)]
        public string LastName { get; set; }
        [DataMember(IsRequired = true)]
        public int Pv { get; set; }
        [DataMember(IsRequired = true)]
        public int ID_House { get; set; }

        public CharacterDTO() { }

        public CharacterDTO(Character element)
        {
            ID = element.ID;
            Bravoury = element.Bravoury;
            Crazyness = element.Crazyness;
            FirstName = element.FirstName;
            LastName = element.LastName;
            Pv = element.PV;
            ID_House = element.ID_House;
        }

        public override string ToString()
        {
            string desc = "id=" + ID + " ,bravoury=" + Bravoury + " ,crazynesse=" + Crazyness + " ,firstname=" + FirstName + " ,lastname=" + LastName + " ,pv=" + Pv;
            return desc;
        }

        /**
         * Transforme l'objet DTO en Character Entity pour l'insérer dans la BDD 
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

            return character;
        }
    }
}