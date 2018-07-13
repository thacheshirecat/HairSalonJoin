using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest
  {
    [TestMethod]
    public void ClientIndex_ReturnsCorrectView_True()
    {
      ClientController controller = new ClientController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
    [TestMethod]
    public void ClientCreateForm_ReturnsCorrectView_True()
    {
      ClientController controller = new ClientController();
      ActionResult indexView = controller.CreateForm();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
    public void ClientView_ReturnsCorrectView_True()
    {
      ClientController controller = new ClientController();
      ActionResult indexView = controller.View();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }
  }
}
