using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/Specialty")]
    public ActionResult Index()
    {
      return View(Specialty.GetAll());
    }
    [HttpGet("/Specialty/CreateForm")]
    public ActionResult CreateForm()
    {
      return View();
    }
    [HttpPost("/Specialty/Add")]
    public ActionResult AddSpecialty(string newname)
    {
      Specialty newSpecialty = new Specialty(newname);
      newSpecialty.Save();
      return View("Index", Specialty.GetAll());
    }
    [HttpPost("/Specialty/DeleteAll")]
    public ActionResult DeleteAll()
    {
      Specialty.DeleteAll();
      return View("Index", Specialty.GetAll());
    }
    [HttpGet("/Specialty/{id}/View")]
    public ActionResult View(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Search(id);
      List<Stylist> specialtiesStylists = selectedSpecialty.GetAllStylists();

      model.Add("specialty", selectedSpecialty);
      model.Add("stylists", specialtiesStylists);

      return View(model);
    }
    [HttpPost("/Stylist/{id}/AddStylist")]
    public ActionResult AddStylist(int id, int newstylistid)
    {
      Specialty selectedSpecialty = Specialty.Search(id);
      Stylist selectedStylist = Stylist.Search(newstylistid);

      selectedSpecialty.AddStylist(selectedStylist);

      return View("Success", selectedSpecialty);
    }
  }
}
