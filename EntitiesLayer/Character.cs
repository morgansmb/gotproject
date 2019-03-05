namespace EntitiesLayer
{
    public enum CharacterType
    {
        warrior, witch, tactician, leader, loser
    }

    public class Character : EntityObject
    {
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PV { get; set; }
        public CharacterType type { get; set; }
        public int ID_House { get; set; }

        public Character() { }

        public Character(int id, int bravoury, int crazyness, string firstName, string lastName, int pv)
        {
            iD = id;
            this.Bravoury = bravoury;
            this.Crazyness = crazyness;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PV = pv;
        }

        public override string ToString()
        {
            string desc = LastName + " " + FirstName + " (Barv : " + Bravoury+", Folie : "+ Crazyness+", PV : "+PV+")";
            return desc;
        }
    }
}
