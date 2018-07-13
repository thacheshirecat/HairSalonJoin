using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public CategoryTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=alex_bunnell_test;";
    }
    [TestMethod]
    public void GetAll_ReturnsAllSylists_SylistList()
    {
      Stylist testStylist1 = new Stylist("John", "Normal Cuts");
      Stylist testStylist2 = new Stylist("Rex", "80s Hairstyles");
      List<Stylist> testList =
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
