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
      return View(Stylist.GetAll());
    }
    [HttpPost("/Client/Add")]
    public ActionResult CreateForm(string newname, string newphone, int newstylist)
    {
      Client newClient = new Client(newname, newphone, newstylist);
      newClient.Save();
      return View("Index", Client.GetAll());
    }
    [HttpGet("/Client/DeleteAll")]
    public ActionResult DeleteAllClients()
    {
      Client.DeleteAll();
      return View("Index", Client.GetAll());
    }
    [HttpGet("/Client/{id}/View")]
    public ActionResult ViewClient(int id)
    {
      return View("View", Client.SearchClientsByStylist(id));
    }
  }
}
