using System.Collections.Generic;

namespace GoTWebMVC.Models
{
    public class DisplayWarModel
    {
        public int ID { get; set; }
        public HouseModel FirstHouse { get; set; }
        public HouseModel SecondHouse { get; set; }
        public int ID_Winner { get; set; }
        public List<FightModel> Fights { get; set; }

        public DisplayWarModel()
        {
            Fights = new List<FightModel>();
        }

        public DisplayWarModel(int id, HouseModel firstHouse, HouseModel secondHouse, int winner, List<FightModel> fights)
        {
            ID          = id;
            FirstHouse  = firstHouse;
            SecondHouse = secondHouse;
            ID_Winner = winner;
            Fights = fights;
        }
    }
}