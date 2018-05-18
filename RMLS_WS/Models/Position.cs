using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Models
{
    public class Position
    {
        public string PositionID { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Position(string posID, double x, double y, double z)
        {
            PositionID = posID;
            X = x;
            Y = y;
            Z = z;
        }

        public Position()
        {

        }
    }
}