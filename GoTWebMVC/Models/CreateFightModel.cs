using System.Collections.Generic;

namespace GoTWebMVC.Models
{
    public class CreateFightModel
    {
        public string SelectedWar { get; set; }
        public WarModel War { get; set; }

        public string SelectedAlly { get; set; }
        public IEnumerable<CharacterModel> AlliesCharacters { get; set; }

        public string SelectedEnnemy { get; set; }
        public IEnumerable<CharacterModel> EnnemiesCharacters { get; set; }

        public TerritoryTypeModel AlliesTerritory { get; set; }
        public TerritoryTypeModel EnnemyTerritory { get; set; }
        public int ID_HouseTerritory { get; set; }

        public CreateFightModel() { }
    }
}