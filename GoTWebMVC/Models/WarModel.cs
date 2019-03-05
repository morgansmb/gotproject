using API.Models;
using System.Collections.Generic;

namespace GoTWebMVC.Models
{
    public class WarModel
    {
        public int ID { get; set; }
        public HouseModel FirstHouse { get; set; }
        public HouseModel SecondHouse { get; set; }
        public int? ID_WinnerHouse { get; set; }
        public List<FightModel> Fights { get; set; }

        public WarModel()
        {
            Fights = new List<FightModel>();
        }

        public WarModel(WarDTO warDTO)
        {
            Fights = new List<FightModel>();

            ID              = warDTO.ID;
            FirstHouse      = new HouseModel(warDTO.FirstHouse);
            SecondHouse     = new HouseModel(warDTO.SecondHouse);
            ID_WinnerHouse  = warDTO.ID_WinnerHouse;

            foreach (FightDTO fight in warDTO.Fights)
            {
                Fights.Add(new FightModel(fight));
            }
        }
    }
}