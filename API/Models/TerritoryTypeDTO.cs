using EntitiesLayer;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class TerritoryTypeDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember(IsRequired = true)]
        public string Type { get; set; }

        public TerritoryTypeDTO() { }

        public TerritoryTypeDTO(TerritoryType territoryType)
        {
            ID      = territoryType.ID;
            Type    = territoryType.Type;
        }

        public TerritoryType Transform()
        {
            TerritoryType territoryType = new TerritoryType();

            territoryType.ID    = ID;
            territoryType.Type  = Type;

            return territoryType;
        }
    }
}