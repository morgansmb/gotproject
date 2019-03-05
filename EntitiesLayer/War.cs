using System.Collections.Generic;

namespace EntitiesLayer
{
    public class War : EntityObject
    {
        public House FirstHouse { get; set; }
        public House SecondHouse { get; set; }
        public int? ID_WinnerHouse { get; set; }
        public List<Fight> Fights { get; set; }

        public War()
        {
            Fights = new List<Fight>();
        }
    }
}
