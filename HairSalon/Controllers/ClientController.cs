using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/Client")]
    public ActionResult Index()
    {
      return View(Client.GetAll());
    }
    [HttpGet("/Client/CreateForm")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/Client/Add")]
    public ActionResult CreateForm(string newname, string newstyle, int newcatid)
    {
      Client newClient = new Client(newname, newstyle, newcatid);
      newClient.Save();
      return View("Index", Client.GetAll());
    }
    [HttpGet("/Client/DeleteAll")]
    public ActionResult DeleteAllClients()
    {
      Client.DeleteAll();
      return View("Index", Client.GetAll());
    }
  }
}
