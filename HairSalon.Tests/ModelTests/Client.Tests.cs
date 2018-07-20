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
    public void Search_ReturnsCorrectClient_Client()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      Client testClient2 = new Client("Jean", "5551238889", 1);
      testClient1.Save();
      testClient2.Save();
      Client result = Client.Search(testClient1.GetId());
      Assert.AreEqual(testClient1, result);
    }
    [TestMethod]
    public void SearchClientsByStylist_ReturnsCorrectClients_ClientList()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      Client testClient2 = new Client("Jean", "5551238889", 1);
      Client testClient3 = new Client("Tom", "5551239000", 2);
      List<Client> testList = new List<Client>{testClient1, testClient2};
      testClient1.Save();
      testClient2.Save();
      testClient3.Save();
      List<Client> resultList = Client.SearchClientsByStylist(1);
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Delete_DeletesSpecifiedClientFromDB_StylistList()
    {
      Client testClient1 = new Client("Billy", "5551238888", 1);
      Client testClient2 = new Client("Jean", "5551238889", 1);

      testClient1.Save();
      testClient2.Save();
      testClient2.Delete();

      List<Client> testList = new List<Client>{testClient1};
      List<Client> resultList = Client.GetAll();

      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Update_CorrectlyUpdatesClientNameInDB_String()
    {
      Client testClient = new Client("Billy", "5551238888", 1);
      testClient.Save();
      Client resultClient = new Client("Jean", "5551238889", 2);
      resultClient.Save();

      testClient.Update("Jean", "5551238888", 1);
      Client controlClient = Client.Search(testClient.GetId());
      string test = controlClient.GetName();
      string result = resultClient.GetName();

      Assert.AreEqual(result, test);
    }
    [TestMethod]
    public void Update_CorrectlyUpdatesClientPhoneInDB_String()
    {
      Client testClient = new Client("Billy", "5551238888", 1);
      testClient.Save();
      Client resultClient = new Client("Jean", "5551238889", 2);
      resultClient.Save();

      testClient.Update("Billy", "5551238889", 1);
      Client controlClient = Client.Search(testClient.GetId());
      string test = controlClient.GetPhone();
      string result = resultClient.GetPhone();

      Assert.AreEqual(result, test);
    }
    [TestMethod]
    public void Update_CorrectlyUpdatesClientStylistIdInDB_String()
    {
      Client testClient = new Client("Billy", "5551238888", 1);
      testClient.Save();
      Client resultClient = new Client("Jean", "5551238889", 2);
      resultClient.Save();

      testClient.Update("Billy", "5551238888", 2);
      Client controlClient = Client.Search(testClient.GetId());
      int test = controlClient.GetStylistId();
      int result = resultClient.GetStylistId();

      Assert.AreEqual(result, test);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
