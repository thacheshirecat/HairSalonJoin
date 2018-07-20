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
    private int stylist_id;

    public Client(string name, string phone, int stylistid, int id = 0)
    {
      _name = name;
      _phone = phone;
      _id = id;
      stylist_id = stylistid;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public int GetStylistId()
    {
      return stylist_id;
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
          bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
          return (idEquality && nameEquality && phoneEquality && stylistIdEquality);
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
      cmd.CommandText = @"INSERT INTO clients (name, phone, stylist_id) VALUES (@name, @phone, @stylistid);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@phone", _phone));
      cmd.Parameters.Add(new MySqlParameter("@stylistid", stylist_id));

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
    public static List<Client> FindClientsByStylist(int stylistid)
    {
      List<Client> searchClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @id;";

      cmd.Parameters.Add(new MySqlParameter("@id", stylistid));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int ClientId = rdr.GetInt32(0);
        string ClientName = rdr.GetString(1);
        string ClientPhone = rdr.GetString(2);
        int ClientCatId = rdr.GetInt32(3);
        Client newClient = new Client(ClientName, ClientPhone, ClientCatId, ClientId);
        searchClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return searchClients;
    }
    public static Client Search(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients WHERE id = @ClientId;";

      cmd.Parameters.Add(new MySqlParameter("@ClientId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int ClientId = 0;
      string ClientName = "";
      string ClientPhone = "";
      int StylistId = 0;

      while(rdr.Read())
      {
        ClientId = rdr.GetInt32(0);
        ClientName = rdr.GetString(1);
        ClientPhone = rdr.GetString(2);
        StylistId = rdr.GetInt32(3);
      }
      Client foundClient = new Client(ClientName, ClientPhone, StylistId, ClientId);
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return foundClient;
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients WHERE id = @ClientId;";

      cmd.Parameters.Add(new MySqlParameter("@ClientId", _id));

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
