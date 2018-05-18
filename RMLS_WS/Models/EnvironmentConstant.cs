using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Models
{
    public class EnvironmentConstant
    {
        public string EquipType { get; set; }
        public double A { get; set; }
        public double N { get; set; }

        public EnvironmentConstant(string equipType, double a, double n)
        {
            this.EquipType = equipType;
            this.A = a;
            this.N = n;
        }

        public EnvironmentConstant()
        {

        }
    }
}