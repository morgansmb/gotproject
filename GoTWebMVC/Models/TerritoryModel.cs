using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoTWebMVC.Models
{
    public class TerritoryModel
    {
        public int ID { get; set; }
        public int ID_House { get; set; }
        public int ID_Type { get; set; }

        public TerritoryModel() { }

        public TerritoryModel(TerritoryDTO territoryDTO)
        {
            ID          = territoryDTO.ID;
            ID_House    = territoryDTO.ID_House;
            ID_Type     = territoryDTO.ID_Type;
        }
    }
}