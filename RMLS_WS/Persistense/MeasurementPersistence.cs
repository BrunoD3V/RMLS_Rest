using RMLS_WS.Models;
using RMLS_WS.Persistense;
using System.Collections.Generic;

namespace RMLS_WS
{
    public class MeasurementPersistence
    {
        private DBConnector connector { get; set; }

        public MeasurementPersistence()
        {
            connector = new DBConnector();
        }

        //GET Method by PosID
        public List<Measurement> GetAllMeasures()
        {
            List<Measurement> measurementsList = new List<Measurement>();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM measurements";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                Measurement res = new Measurement();

                res.MeasurementID = mySqlDataReader.GetString(0);
                res.PositionID = mySqlDataReader.GetString(1);
                res.Azimuth = mySqlDataReader.GetInt32(2);
                res.EquipmentType = mySqlDataReader.GetString(3);
                res.Rssi1 = mySqlDataReader.GetDouble(4);
                res.Rssi2 = mySqlDataReader.GetDouble(5);
                res.Rssi3 = mySqlDataReader.GetDouble(6);
                res.Rssi4 = mySqlDataReader.GetDouble(7);

                measurementsList.Add(res);
            }

            return measurementsList;
        }

        //GET Method by PosID
        public List<Measurement> GetAllMeasuresByPosID(string posID)
        {
            List<Measurement> measurementsList = new List<Measurement>();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = string.Format("SELECT * FROM measurements WHERE pos_ID='{0}'", posID);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                Measurement res = new Measurement();

                res.MeasurementID = mySqlDataReader.GetString(0);
                res.PositionID = mySqlDataReader.GetString(1);
                res.Azimuth = mySqlDataReader.GetInt32(2);
                res.EquipmentType = mySqlDataReader.GetString(3);
                res.Rssi1 = mySqlDataReader.GetDouble(4);
                res.Rssi2 = mySqlDataReader.GetDouble(5);
                res.Rssi3 = mySqlDataReader.GetDouble(6);
                res.Rssi4 = mySqlDataReader.GetDouble(7);

                measurementsList.Add(res);
            }

            return measurementsList;
        }

        //GET Method
        public Measurement GetMeasureByID(string id)
        {
            Measurement res = new Measurement();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM measurements WHERE pos_ID='" + id + "'";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                res.MeasurementID = mySqlDataReader.GetString(0);
                res.PositionID = mySqlDataReader.GetString(1);
                res.Azimuth = mySqlDataReader.GetInt32(2);
                res.EquipmentType = mySqlDataReader.GetString(3);
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

        //POST METHOD
        public void InsertMeasurement(Measurement m)
        {
            string queryString = string.Format("INSERT INTO measurements VALUES('{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7})",
                m.MeasurementID, m.PositionID, m.Azimuth, m.EquipmentType, m.Rssi1, m.Rssi2, m.Rssi3, m.Rssi4);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);
            cmd.ExecuteNonQuery();
        }

        public bool DeleteMeasurement(string id)
        {
            bool result = false;

            Measurement m = new Measurement();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string queryString = string.Format("SELECT * FROM measurements WHERE measurement_ID='" + id + "'");
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);

            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                mySqlDataReader.Close();

                queryString = string.Format("DELETE FROM measurements WHERE measurement_ID='" + id + "'");
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);

                cmd.ExecuteNonQuery();

                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


    }
}