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
  }
}
