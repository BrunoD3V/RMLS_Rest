using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Models
{
    public class Error
    {
        public int ErrorID { get; set; }
        public string PosID { get; set; }
        public double Error1 { get; set; }
        public double Error2 { get; set; }
        public double Error3 { get; set; }
        public double Error4 { get; set; }

        public Error(int errorID, string posID, double error1, double error2, double error3, double error4 )
        {
            this.ErrorID = errorID;
            this.PosID = posID;
            this.Error1 = error1;
            this.Error2 = error2;
            this.Error3 = error3;
            this.Error4 = error4;
        }

        public Error()
        {

        }
    }
}