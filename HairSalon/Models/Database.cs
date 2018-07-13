using System;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon
{
    public class DB
    {
      public static MySqlConnection Connection()
      {
        MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
        return conn;
      }
    }
}
