using RMLS_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMLS_WS.Persistense
{
    public class EnvironmentConstantsPersistence
    {
        private DBConnector connector { get; set; }

        public EnvironmentConstantsPersistence()
        {
            connector = new DBConnector();
        }

        //GET METHOD
        public List<EnvironmentConstant> GetEnvironmentConstantByEquipType(string equiptType)
        {
            List<EnvironmentConstant> res = new List<EnvironmentConstant>();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM constants WHERE equipType='" + equiptType + "'";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                //res.EquipType = mySqlDataReader.GetString(1);
                //res.A = mySqlDataReader.GetDouble(2);
                //res.N = mySqlDataReader.GetDouble(3);

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