using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {
    public ClientTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=alex_bunnell_test;";
    }
    [TestMethod]
    public void Equals_ReturnsTrueForSameClient_Client()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      Client testClient2 = new Client("Billy", "5551238888", 1);
      Assert.AreEqual(testClient1, testClient2);
    }
    [TestMethod]
    public void GetAll_ClientTableStartsEmpty_0()
    {
      int result = Client.GetAll().Count;
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void GetAll_ReturnsAllClients_ClientList()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      Client testClient2 = new Client("Jean", "5551238889", 1);
      List<Client> testList = new List<Client>{testClient1, testClient2};
      testClient1.Save();
      testClient2.Save();
      List<Client> resultList = Client.GetAll();
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Save_SavesClientToDatabase_ClientList()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      List<Client> testList = new List<Client>{testClient1};
      testClient1.Save();
      List<Client> resultList = Client.GetAll();
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void CategorySearch_ReturnsCorrectClients_ClientList()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      Client testClient2 = new Client("Jean", "5551238889", 1);
      Client testClient3 = new Client("Jean", "5551238889", 2);
      List<Client> testList = new List<Client>{testClient1, testClient2};
      testClient1.Save();
      testClient2.Save();
      testClient3.Save();
      List<Client> resultList = Client.CategorySearch(1);
      CollectionAssert.AreEqual(testList, resultList);
    }

    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
