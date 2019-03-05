namespace EntitiesLayer
{
    public class TerritoryType : EntityObject
    {
        public string Type { get; set; }

        public TerritoryType() { }

        public TerritoryType(int id, string type)
        {
            iD = id;
            Type = type;
        }

        public override string ToString()
        {
            return Type;
        }
    }
}
