using System;
using MySql.Data.MySqlClient;
using ToDoList;

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
