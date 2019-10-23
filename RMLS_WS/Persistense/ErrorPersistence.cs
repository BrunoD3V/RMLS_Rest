using RMLS_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Persistense
{
    public class ErrorPersistence
    {
        private DBConnector connector { get; set; }

        public ErrorPersistence()
        {
            connector = new DBConnector();
        }

        //GET Method
        public Error GetErrorByPosID(string posID)
        {
            Error res = new Error();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM errors WHERE pos_ID='" + posID + "'";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                res.ErrorID = mySqlDataReader.GetInt32(0);
                res.PosID = mySqlDataReader.GetString(1);
                res.Error1 = mySqlDataReader.GetDouble(2);
                res.Error2 = mySqlDataReader.GetDouble(3);
                res.Error3 = mySqlDataReader.GetDouble(4);
                res.Error4 = mySqlDataReader.GetDouble(5);

                return res;
            }
            else
            {
                return null;
            }
        }

        //POST METHOD
        public void InsertError(Error error)
        {
            string queryString = string.Format("INSERT INTO errors VALUES( {0}, '{1}', {2}, {3}, {4}, {5} )",
                error.ErrorID, error.PosID, error.Error1, error.Error2, error.Error3, error.Error4);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);
            cmd.ExecuteNonQuery();
        }
    }
}