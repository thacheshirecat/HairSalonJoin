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

    }
    public static List<Stylist> GetAll()
    {
      return null;
    }

  }
}
