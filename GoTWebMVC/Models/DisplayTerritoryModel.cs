namespace GoTWebMVC.Models
{
    public class DisplayTerritoryModel
    {
        public int ID { get; set; }
        public HouseModel Owner { get; set; }
        public TerritoryTypeModel Type { get; set; }

        public DisplayTerritoryModel() { }

        public DisplayTerritoryModel(int id, HouseModel owner, TerritoryTypeModel type)
        {
            ID      = id;
            Owner   = owner;
            Type    = type;
        }
    }
}