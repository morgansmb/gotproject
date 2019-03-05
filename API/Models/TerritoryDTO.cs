using EntitiesLayer;
using System.Runtime.Serialization;

namespace API.Models
{
    [DataContract]
    public class TerritoryDTO
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember(IsRequired = true)]
        public int ID_Type { get; set; }
        [DataMember(IsRequired = true)]
        public int ID_House { get; set; }

        public TerritoryDTO() { }

        public TerritoryDTO(Territory territory)
        {
            ID          = territory.ID;
            ID_Type     = territory.ID_Type;
            ID_House    = territory.ID_House;
        }

        public Territory Transform()
        {
            Territory territory = new Territory();

            territory.ID        = ID;
            territory.ID_Type   = ID_Type;
            territory.ID_House  = ID_House;

            return territory;
        }
    }
}