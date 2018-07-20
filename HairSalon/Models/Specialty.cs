using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Specialty
  {
    private int _id;
    private string _name;

    public Specialty(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
          return false;
      }
      else
      {
          Specialty newSpecialty = (Specialty) otherSpecialty;
          bool idEquality = (this.GetId() == newSpecialty.GetId());
          bool nameEquality = (this.GetName() == newSpecialty.GetName());
          return (idEquality && nameEquality);
      }
    }
    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";

      cmd.Parameters.Add(new MySqlParameter("@name", _name));

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int SpecialtyId = rdr.GetInt32(0);
        string SpecialtyName = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allSpecialties;
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties; DELETE from specialties_stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
    public static Specialty Search(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = @SpecialtyId;";

      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int SpecialtyId = 0;
      string SpecialtyName = "";

      while(rdr.Read())
      {
        SpecialtyId = rdr.GetInt32(0);
        SpecialtyName = rdr.GetString(1);
      }
      Specialty foundSpecialty = new Specialty(SpecialtyName, SpecialtyId);

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return foundSpecialty;
    }
    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@SpecialtyId, @StylistId);";

      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", _id));
      cmd.Parameters.Add(new MySqlParameter("@StylistId", newStylist.GetId()));

      cmd.ExecuteNonQuery();

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public List<Stylist> GetAllStylists()
    {
      List<Stylist> foundStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
                          JOIN specialties_stylists ON (specialties.id = specialties_stylists.specialty_id)
                          JOIN stylists ON (specialties_stylists.stylist_id = stylists.id)
                          WHERE specialties.id = @SpecialtyId;";

      cmd.Parameters.Add(new MySqlParameter("@SpecialtyId", _id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistName = rdr.GetString(1);
        string StylistStyle = rdr.GetString(2);
        Stylist newStylist = new Stylist(StylistName, StylistStyle, StylistId);
        foundStylists.Add(newStylist);
      }

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }

      return foundStylists;
    }
  }
}
