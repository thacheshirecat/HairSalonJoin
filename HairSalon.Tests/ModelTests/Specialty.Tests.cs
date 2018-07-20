using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTests : IDisposable
  {
    public SpecialtyTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=alex_bunnell_test;";
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameSpecialty_Specialty()
    {
      Specialty testSpecialty1 = new Specialty("Buzz Cut");
      Specialty testSpecialty2 = new Specialty("Buzz Cut");
      Assert.AreEqual(testSpecialty1, testSpecialty2);
    }
  }
}
