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
      Specialty.DeleteAll();
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameSpecialty_Specialty()
    {
      Specialty testSpecialty1 = new Specialty("Buzz Cut");
      Specialty testSpecialty2 = new Specialty("Buzz Cut");
      Assert.AreEqual(testSpecialty1, testSpecialty2);
    }
    [TestMethod]
    public void Save_SavesSpecialtyToDatabase_SpecialtyList()
    {
      Specialty testSpecialty1 = new Specialty("Buzz Cut");
      List<Specialty> testList = new List<Specialty>{testSpecialty1};
      testSpecialty1.Save();
      List<Specialty> resultList = Specialty.GetAll();
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void GetAll_ReturnsAllSylists_SylistList()
    {
      Specialty testSpecialty1 = new Specialty("Buzz Cut");
      Specialty testSpecialty2 = new Specialty("High Rise");
      List<Specialty> testList = new List<Specialty>{testSpecialty1, testSpecialty2};
      testSpecialty1.Save();
      testSpecialty2.Save();
      List<Specialty> resultList = Specialty.GetAll();
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Search_ReturnsCorrectSpecialty_Specialty()
    {
      Specialty testSpecialty1 = new Specialty("Buzz Cut");
      Specialty testSpecialty2 = new Specialty("High Rise");
      testSpecialty1.Save();
      testSpecialty2.Save();
      Specialty result = Specialty.Search(testSpecialty1.GetId());
      Assert.AreEqual(testSpecialty1, result);
    }
  }
}
