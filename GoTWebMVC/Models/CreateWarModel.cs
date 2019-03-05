using System.Collections.Generic;

namespace GoTWebMVC.Models
{
    public class CreateWarModel
    {
        public List<HouseModel> Houses { get; set; }
        public string SelectedAllyHouse { get; set; }
        public string SelectedEnnemyHouse { get; set; }

        public CreateWarModel() { }
    }
}