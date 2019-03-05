using API.Models;

namespace GoTWebMVC.Models
{
    public class FightModel
    {
        public int ID { get; set; }
        public CharacterModel FirstCharacter { get; set; }
        public CharacterModel SecondCharacter { get; set; }
        public int ID_Winner { get; set; }
        public int ID_Territory { get; set; }
        public int ID_War { get; set; }

        public FightModel() { }

        public FightModel(FightDTO fightDTO)
        {
            ID              = fightDTO.ID;
            FirstCharacter  = new CharacterModel(fightDTO.FirstCharacter);
            SecondCharacter = new CharacterModel(fightDTO.SecondCharacter);
            ID_Winner       = fightDTO.ID_Winner;
            ID_Territory    = fightDTO.ID_Territory;
            ID_War          = fightDTO.ID_War;
        }
    }
}