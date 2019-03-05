using EntitiesLayer;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class HouseDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        [DataMember(IsRequired = true)]
        public int NumberOfUnits { get; set; }
        [DataMember]
        /* Sert uniquement pour l'affichage -> inutile pour la construction */
        public List<CharacterDTO> Housers { get; set; }

        public HouseDTO()
        {
            Housers = new List<CharacterDTO>();
        }

        /**
         * Construction d'un DTO à partir d'une Entity
         */
        public HouseDTO(House house)
        {
            Housers = new List<CharacterDTO>();
            foreach (EntitiesLayer.Character ch in house.Housers)
            {
                Housers.Add(new CharacterDTO(ch));
            }

            Name = house.Name;
            NumberOfUnits = house.NumberOfUnities;
            ID = house.ID;
        }

        public House Transform()
        {
            House house = new House();

            house.ID = ID;
            house.Name = Name;
            house.NumberOfUnities = NumberOfUnits;

            return house;
        }
    }
}