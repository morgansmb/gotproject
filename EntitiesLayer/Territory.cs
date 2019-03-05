namespace EntitiesLayer
{
    public class Territory : EntityObject
    {
        public int ID_Type { get; set; }
        public int ID_House { get; set; }

        public Territory() {}

        public Territory(int id, int type, int house)
        {
            iD = id;
            this.ID_Type = type;
            this.ID_House = house;
        }

        public override string ToString()
        {
            string desc = "id=" + ID;
            return desc;
        }
    }
}
