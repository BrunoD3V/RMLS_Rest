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


        //GET Method by PosID
        public List<Position> GetAllPositions()
        {
            List<Position> positionsList = new List<Position>();

            MySql.Data.MySqlClient.MySqlDataReader mySqlDataReader = null;

            string sqlString = "SELECT * FROM positions";

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connector.conn);
            mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                Position res = new Position();

                res.PositionID = mySqlDataReader.GetString(0);
                res.X = mySqlDataReader.GetDouble(1);
                res.Y = mySqlDataReader.GetDouble(2);
                res.Z = mySqlDataReader.GetDouble(3);

                positionsList.Add(res);
            }

            mySqlDataReader.Close();

            return positionsList;
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

        //POST METHOD
        public string InsertPosition(Position p)
        {
            List<Position> searchRes = GetAllPositions();

            string newPosition = "";

            if (searchRes.Count != 0)
            {
                int max = 0;

                foreach (Position pos in searchRes)
                {
                    if(pos.PositionID.Length < 3)
                    {
                        continue;
                    }

                    int aux;
                    Int32.TryParse(pos.PositionID.Replace("pos",""), out aux);

                    if (aux > max)
                        max = aux;
                }


                newPosition = string.Format("pos{0}", ++max);

                //Insert Query
                string queryString = string.Format("INSERT INTO positions VALUES('{0}', '{1}', {2}, '{3}')",

                     newPosition, p.X, p.Y, p.Z);

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(queryString, connector.conn);
                cmd.ExecuteNonQuery();
            }
            return newPosition;
        }
    }
}