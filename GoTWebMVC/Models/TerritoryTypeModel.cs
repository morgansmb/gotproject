using API.Models;

namespace GoTWebMVC.Models
{
    public class TerritoryTypeModel
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public TerritoryTypeModel() { }

        public TerritoryTypeModel(TerritoryTypeDTO territoryType)
        {
            ID      = territoryType.ID;
            Type    = territoryType.Type;
        }
    }
}