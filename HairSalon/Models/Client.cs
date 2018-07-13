using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    private int _id;
    private string _name;
    private string _phone;
    private int category_id;

    public Client(string name, string phone, int catid, int id = 0)
    {
      _name = name;
      _phone = phone;
      _id = id;
      category_id = catid;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public int GetCategoryId()
    {
      return category_id;
    }
    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
          return false;
      }
      else
      {
          Client newClient = (Client) otherClient;
          bool idEquality = (this.GetId() == newClient.GetId());
          bool nameEquality = (this.GetName() == newClient.GetName());
          bool phoneEquality = (this.GetPhone() == newClient.GetPhone());
          bool catIdEquality = (this.GetCategoryId() == newClient.GetCategoryId());
          return (idEquality && nameEquality && phoneEquality && catIdEquality);
      }
    }
    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public static void DeleteAll()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO clients (name, phone, category_id) VALUES (@name, @phone, @catid);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@phone", _phone));
      cmd.Parameters.Add(new MySqlParameter("@catid", category_id));

      cmd.ExecuteNonQuery();

      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        string ClientPhone = rdr.GetString(2);
        int ClientCatId = rdr.GetInt32(3);
        Client newClient = new Client(ClientName, ClientPhone, ClientCatId, ClientId);
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allClients;
    }
  }
}
