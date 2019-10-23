using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Models
{
    public class EnvironmentConstant
    {
        public int ConstantID { get; set; }
      
        public double A { get; set; }
        public double N { get; set; }

        public EnvironmentConstant(int constantID, string equipType, double a,  double n)
        {
            this.ConstantID = constantID;
          
            this.A = a;
            this.N = n;
        }

        public EnvironmentConstant()
        {

        }
    }
}