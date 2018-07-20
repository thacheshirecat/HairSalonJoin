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
    [HttpPost("/Client/DeleteAll")]
    public ActionResult DeleteAllClients()
    {
      Client.DeleteAll();
      return View("Index", Client.GetAll());
    }
    [HttpGet("/Client/{id}/View")]
    public ActionResult ViewClient(int id)
    {
      return View("View", Client.Search(id));
    }
    [HttpPost("/Client/{id}/Delete")]
    public ActionResult Delete(int id)
    {
      Client selectedClient = Client.Search(id);

      selectedClient.Delete();

      return View("Index", Client.GetAll());
    }
    [HttpPost("/Client/{id}/Update")]
    public ActionResult Update(string newname, string newphone, int newstylist, int id)
    {
      Client thisClient = Client.Search(id);

      thisClient.Update(newname, newphone, newstylist);

      return View("Success", thisClient);
    }
  }
}
