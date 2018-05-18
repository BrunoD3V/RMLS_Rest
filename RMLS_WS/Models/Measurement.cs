using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Models
{
    public class Measurement
    {
        public string MeasurementID { get; set; }
        public string PositionID { get; set; }
        public string EquipmentType { get; set; }
        public int Azimuth { get; set; }
        public double Rssi1 { get; set; }
        public double Rssi2 { get; set; }
        public double Rssi3 { get; set; }
        public double Rssi4 { get; set; }

        public Measurement(string measurementID, string positionID, string equipmentType, int azimuth, double rssi1, double rssi2, double rssi3, double rssi4)
        {
            this.MeasurementID = MeasurementID;
            this.PositionID = positionID;
            this.EquipmentType = equipmentType;
            this.Azimuth = azimuth;
            this.Rssi1 = rssi1;
            this.Rssi2 = rssi2;
            this.Rssi3 = rssi3;
            this.Rssi4 = rssi4;
        }

        public Measurement()
        {

        }
    }
}