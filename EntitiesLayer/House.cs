using System.Collections.Generic;
using System.Linq;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        public string Name { get; set; }
        public int NumberOfUnities { get; set; }
        public List<Character> Housers { get; set; }

        public House(int id, string name, int numberOfUnities)
        {
            iD = id;
            this.Name = name;
            this.NumberOfUnities = numberOfUnities;
            Housers = new List<Character>();
        }

        public House()
        {
            Housers = new List<Character>();
        }

        public void AddHouser(Character h)
        {
            Housers.Add(h);
        }
        public void RemoveHouser()
        {
            if (Housers.Count() != 0)
                Housers.RemoveAt(Housers.Count()-1);
        }

        public override string ToString()
        {
            string desc = "id=" + ID + " ,name=" + Name + " ,numberofUnities" + NumberOfUnities;
            return desc;
        }
    }
}
