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


        //GET ALL ENVIRONMENT CONSTANTS
        public List<EnvironmentConstant> GetAllEnvironmentConstants()
        {
            List<EnvironmentConstant> environmentConstantList = new List<EnvironmentConstant>();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM EnvironmentConstants";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                EnvironmentConstant res = new EnvironmentConstant();

                res.ConstantID = mySqlDataReader.GetInt32(0);
                res.A = mySqlDataReader.GetDouble(1);
                res.N = mySqlDataReader.GetDouble(2);

                environmentConstantList.Add(res);
            }

            return environmentConstantList;
        }

        //POST METHOD
        public void InsertEnvironmentConstant(EnvironmentConstant ev)
        {
            string queryString = string.Format("INSERT INTO environmentconstants VALUES({0}, '{1}', {2})",
                ev.ConstantID, ev.A, ev.N);

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);
            cmd.ExecuteNonQuery();
        }
    }
}