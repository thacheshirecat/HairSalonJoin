using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/Stylist")]
    public ActionResult Index()
    {
      return View(Stylist.GetAll());
    }
    [HttpGet("/Stylist/CreateForm")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/Stylist/Add")]
    public ActionResult CreateForm(string newname, string newstyle)
    {
      Stylist newStylist = new Stylist(newname, newstyle);
      newStylist.Save();
      return View("Index", Stylist.GetAll());
    }
    [HttpGet("/Stylist/DeleteAll")]
    public ActionResult DeleteAllStylists()
    {
      Stylist.DeleteAll();
      return View("Index", Stylist.GetAll());
    }
    [HttpGet("/Stylist/{id}/View")]
    public ActionResult View(int id)
    {
      return View(Stylist.Search(id));
    }
  }
}
