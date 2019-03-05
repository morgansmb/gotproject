namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        public Character FirstCharacter { get; set; }
        public Character SecondCharacter { get; set; }
        public int ID_Winner { get; set; }
        public int ID_Territory { get; set; }
        public int ID_War { get; set; }

        public Fight() { }
    }
}
