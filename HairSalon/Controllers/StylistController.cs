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
      Dictionary<string, object> model = new Dictionary<string, object>();

      Stylist selectedStylist = Stylist.Search(id);
      List<Client> stylistsClients = Client.SearchClientsByStylist(id);
      List<Specialty> stylistsSpecialties = selectedStylist.GetAllSpecialties();
      List<Specialty> allSpecialties = Specialty.GetAll();

      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistsClients);
      model.Add("specialties", stylistsSpecialties);
      model.Add("allspecials"), allSpecialties);

      return View(model);
    }
    [HttpPost("/Stylist/AddSpecialty")]
    public ActionResult AddSpecialty(int stylistid, int newspecialtyid)
    {

      Dictionary<string, object> model = new Dictionary<string, object>();

      Stylist selectedStylist = Stylist.Search(stylistid);
      Specialty newSpecialty = Specialty.Search(newspecialtyid);
      selectedStylist.AddSpecialty(newSpecialty);
      List<Client> stylistsClients = Client.SearchClientsByStylist(stylistid);
      List<Specialty> stylistsSpecialties = selectedStylist.GetAllSpecialties();
      List<Specialty> allSpecialties = Specialty.GetAll();

      model.Add("stylist", selectedStylist);
      model.Add("clients", stylistsClients);
      model.Add("specialties", stylistsSpecialties);
      model.Add("allspecials"), allSpecialties);

      return View("View", model);
    }
  }
}
