using EntitiesLayer;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class FightDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember (IsRequired = true)]
        public CharacterDTO FirstCharacter { get; set; }
        [DataMember(IsRequired = true)]
        public CharacterDTO SecondCharacter { get; set; }
        [DataMember(IsRequired = true)]
        public int ID_Winner { get; set; }
        [DataMember(IsRequired = true)]
        public int ID_Territory { get; set; }
        [DataMember(IsRequired = true)]
        public int ID_War { get; set; }

        public FightDTO() { }

        public FightDTO(Fight fight)
        {
            FirstCharacter  = new CharacterDTO(fight.FirstCharacter);
            SecondCharacter = new CharacterDTO(fight.SecondCharacter);
            ID_Winner       = fight.ID_Winner;
            ID_Territory    = fight.ID_Territory;
            ID_War          = fight.ID_War;
            ID              = fight.ID;
        }

        public Fight Transform()
        {
            Fight fight = new Fight();

            fight.FirstCharacter    = FirstCharacter.Transform();
            fight.SecondCharacter   = SecondCharacter.Transform();
            fight.ID_Winner         = ID_Winner;
            fight.ID_Territory      = ID_Territory;
            fight.ID_War            = ID_War;

            return fight;
        }
    }
}