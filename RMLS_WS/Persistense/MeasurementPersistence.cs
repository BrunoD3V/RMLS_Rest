using RMLS_WS.Models;
using RMLS_WS.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS
{
    public class MeasurementPersistence
    {
        private DBConnector connector { get; set; }

        public MeasurementPersistence()
        {
            connector = new DBConnector();
        }

        public Measurement GetMeasureByID(string id)
        {
            Measurement res = new Measurement();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM measurements WHERE measurement_ID='" + id + "'";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                res.MeasurementID = mySqlDataReader.GetString(0);
                res.PositionID = mySqlDataReader.GetString(1);
                res.EquipmentType = mySqlDataReader.GetString(3);
                res.Azimuth = mySqlDataReader.GetInt32(2);
                res.Rssi1 = mySqlDataReader.GetDouble(4);
                res.Rssi2 = mySqlDataReader.GetDouble(5);
                res.Rssi3 = mySqlDataReader.GetDouble(6);
                res.Rssi4 = mySqlDataReader.GetDouble(7);

                return res;
            }
            else
            {
                return null;
            }
        }

        //TODO: POST METHOD
        public void InsertMeasurement(Measurement m)
        {
            string queryString = string.Format("INSERT INTO measurements VALUES('{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7})", 
                m.MeasurementID, m.PositionID, m.Azimuth, m.EquipmentType, m.Rssi1, m.Rssi2, m.Rssi3, m.Rssi4);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);
            cmd.ExecuteNonQuery();
        }


    }
}