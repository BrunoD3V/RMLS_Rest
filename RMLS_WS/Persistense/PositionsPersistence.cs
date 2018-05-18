using RMLS_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Persistense
{
    public class PositionsPersistence
    {
        private DBConnector connector { get; set; }

        public PositionsPersistence()
        {
            connector = new DBConnector();
        }

        //GET METHOD
        public Position GetPositionByID(string id)
        {
            Position res = new Position();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM positions WHERE pos_ID='" + id + "'";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                res.PositionID = mySqlDataReader.GetString(0);
                res.X = mySqlDataReader.GetDouble(1);
                res.Y = mySqlDataReader.GetDouble(2);
                res.Z = mySqlDataReader.GetDouble(3);

                return res;
            }
            else
            {
                return null;
            }
        }
        //PUT METHOD


    }
}