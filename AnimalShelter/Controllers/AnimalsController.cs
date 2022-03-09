using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public  class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");

    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal=>animal.AnimalId==id);
      return View(thisAnimal);
    }

    public ActionResult SortByBreed()
    {
      List<Animal> sortModel = _db.Animals.OrderBy(s => s.Type).ToList();
      return View(sortModel);
    }

    public ActionResult SortByAlphabet()
    {
      List<Animal> sortModel = _db.Animals.OrderBy(s => s.Name).ToList();
      return View(sortModel);
    }

    public ActionResult SortByDate()
    {
      List<Animal> sortModel = _db.Animals.OrderBy(s => s.AdmitDate).ToList();
      return View(sortModel);
    }
  }
}