using RMLS_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Persistense
{
    public class AccessPointPersistence
    {
        private DBConnector connector { get; set; }

        public AccessPointPersistence()
        {
            connector = new DBConnector();
        }


        //GET ALL ACCESS POINTS
        public List<AccessPoint> GetAllAccessPoints()
        {
            List<AccessPoint> accessPoints = new List<AccessPoint>();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM accesspoints";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                AccessPoint res = new AccessPoint();

                res.Position = mySqlDataReader.GetString(0);
                res.Bssid = mySqlDataReader.GetString(1);
                res.EquipType = mySqlDataReader.GetString(2);

                accessPoints.Add(res);
            }

            return accessPoints;
        }

        //GET METHOD
        public AccessPoint GetAccessPointsByName(string name)
        {
            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            AccessPoint res = new AccessPoint();

            string sqlString = "SELECT * FROM accesspoints WHERE Position ='" + name + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);

            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                res.Position = mySqlDataReader.GetString(0);
                res.Bssid = mySqlDataReader.GetString(1);
                res.EquipType = mySqlDataReader.GetString(2);
            }

            return res;
        }

        //POST METHOD
        public void InsertAccessPoint(AccessPoint ap)
        {
            string queryString = string.Format("INSERT INTO accesspoints VALUES({0}, '{1}', {2})",
                ap.Position, ap.Bssid, ap.EquipType);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);
            cmd.ExecuteNonQuery();
        }


    }
}