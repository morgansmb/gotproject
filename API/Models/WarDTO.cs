using EntitiesLayer;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class WarDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember (IsRequired = true)]
        public HouseDTO FirstHouse { get; set; }
        [DataMember(IsRequired = true)]
        public HouseDTO SecondHouse { get; set; }
        [DataMember]
        public int? ID_WinnerHouse { get; set; }
        [DataMember]
        public List<FightDTO> Fights { get; set; }

        public WarDTO()
        {
            Fights = new List<FightDTO>();
        }

        public WarDTO(War war)
        {
            Fights = new List<FightDTO>();

            foreach (Fight fight in war.Fights)
            {
                Fights.Add(new FightDTO(fight));
            }

            ID              = war.ID;
            FirstHouse      = new HouseDTO(war.FirstHouse);
            SecondHouse     = new HouseDTO(war.SecondHouse);
            ID_WinnerHouse  = war.ID_WinnerHouse;
        }

        public War Transform()
        {
            War war = new War();

            war.ID              = ID;
            war.FirstHouse      = FirstHouse.Transform();
            war.SecondHouse     = SecondHouse.Transform();
            war.ID_WinnerHouse  = ID_WinnerHouse;

            /* Liste vide car pas rentrée en BDD -> sert juste pour affichage */
            war.Fights = new List<Fight>();

            return war;
        }
    }
}