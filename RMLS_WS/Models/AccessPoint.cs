using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Models
{
    public class AccessPoint
    {
        public string Position { get; set; }
        public string Bssid { get; set; }
        public string EquipType { get; set; }

        public AccessPoint(string position, string bssid, string equipType)
        {
            Position = position;
            Bssid = bssid;
            EquipType = equipType;
        }

        public AccessPoint()
        {
        }
    }
}