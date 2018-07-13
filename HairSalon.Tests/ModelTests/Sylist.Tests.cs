using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=alex_bunnell_test;";
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameStylist_Stylist()
    {
      Stylist testStylist1 = new Stylist("John", "Normal Cuts");
      Stylist testStylist2 = new Stylist("John", "Normal Cuts");
      Assert.AreEqual(testStylist1, testStylist2);
    }
    [TestMethod]
    public void GetAll_StylistTableStartsEmpty_0()
    {
      int result = Stylist.GetAll().Count;
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void GetAll_ReturnsAllSylists_SylistList()
    {
      Stylist testStylist1 = new Stylist("John", "Normal Cuts");
      Stylist testStylist2 = new Stylist("Rex", "80s Hairstyles");
      List<Stylist> testList = new List<Stylist>{testStylist1, testStylist2};
      testStylist1.Save();
      testStylist2.Save();
      List<Stylist> resultList = Stylist.GetAll();
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      Stylist testStylist1 = new Stylist("John", "Normal Cuts");
      List<Stylist> testList = new List<Stylist>{testStylist1};
      testStylist1.Save();
      List<Stylist> resultList = Stylist.GetAll();
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Find_FindsCorrectStylist_Stylist()
    {
      Stylist testStylist1 = new Stylist("John", "Normal Cuts");
      testStylist1.Save();
      Stylist result = Stylist.Search(testStylist1.GetId());
      Assert.AreEqual(testStylist1, result);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
