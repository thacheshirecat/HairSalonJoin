using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private string _style;

    public Stylist(string name, string style, int id = 0)
    {
      _name = name;
      _style = style;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetStyle()
    {
      return _style;
    }
    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
          return false;
      }
      else
      {
          Stylist newStylist = (Stylist) otherStylist;
          bool idEquality = (this.GetId() == newStylist.GetId());
          bool nameEquality = (this.GetName() == newStylist.GetName());
          bool styleEquality = (this.GetStyle() == newStylist.GetStyle());
          return (idEquality && nameEquality && styleEquality);
      }
    }
    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public static void DeleteAll()
    {
        Client.DeleteAll();
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM stylists;";
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
      cmd.CommandText = @"INSERT INTO stylists (name, style) VALUES (@name, @style);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));
      cmd.Parameters.Add(new MySqlParameter("@style", _style));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistName = rdr.GetString(1);
        string StylistStyle = rdr.GetString(2);
        Stylist newStylist = new Stylist(StylistName, StylistStyle, StylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allStylists;
    }

    public static Stylist Search(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = @StylistId;";

      cmd.Parameters.Add(new MySqlParameter("@StylistId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int StylistId = 0;
      string StylistName = "";
      string StylistStyle = "";

      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistName = rdr.GetString(1);
        StylistStyle = rdr.GetString(2);
      }
      Stylist newStylist = new Stylist(StylistName, StylistStyle, StylistId);
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return newStylist;
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @StylistId; DELETE FROM specialties_stylists WHERE stylist_id = @StylistId;";

      cmd.Parameters.Add(new MySqlParameter("@StylistId", _id));

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public void Update(string newName, string newStyle)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET name = @StylistName, style = @StylistStyle WHERE id = @StylistId;";

      cmd.Parameters.Add(new MySqlParameter("@StylistId", _id));
      cmd.Parameters.Add(new MySqlParameter("@StylistName", newName));
      cmd.Parameters.Add(new MySqlParameter("@StylistStyle", newStyle));

      cmd.ExecuteNonQuery();
      _name = newName;
      _style = newStyle;

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";

      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", newSpecialty.GetId()));
      cmd.Parameters.Add(new MySqlParameter("@StylistId", _id));

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public List<Specialty> GetAllSpecialties()
    {
      List<Specialty> foundSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM stylists
                          JOIN specialties_stylists ON (stylists.id = specialties_stylists.stylist_id)
                          JOIN specialties ON (specialties_stylists.specialty_id = specialties.id)
                          WHERE stylists.id = @StylistId;";

      cmd.Parameters.Add(new MySqlParameter("@StylistId", _id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string SpecialtyName = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
        foundSpecialties.Add(newSpecialty);
      }

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }

      return foundSpecialties;
    }
  }
}
