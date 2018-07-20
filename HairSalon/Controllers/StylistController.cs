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
    [HttpPost("/Stylist/DeleteAll")]
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
      model.Add("allspecials", allSpecialties);

      return View(model);
    }
    [HttpGet("/Stylist/{id}/Update")]
    public ActionResult Update(int id)
    {
      Stylist selectedStylist = Stylist.Search(id);

      return View(selectedStylist);
    }
    [HttpPost("/Stylist/{id}/Update")]
    public ActionResult Update(string newname, string newstyle, int id)
    {
      Stylist selectedStylist = Stylist.Search(id);

      selectedStylist.Update(newname, newstyle);

      return View("Success", selectedStylist);
    }
    [HttpPost("/Stylist/{id}/AddSpecialty")]
    public ActionResult AddSpecialty(int id, int newspecialtyid)
    {
      Stylist selectedStylist = Stylist.Search(id);
      Specialty newSpecialty = Specialty.Search(newspecialtyid);

      selectedStylist.AddSpecialty(newSpecialty);

      return View("Success", selectedStylist);
    }
    [HttpPost("/Stylist/{id}/Delete")]
    public ActionResult Delete(int id)
    {
      Stylist foundStylist = Stylist.Search(id);

      foundStylist.Delete();

      return View("Index", Stylist.GetAll());
    }
  }
}
