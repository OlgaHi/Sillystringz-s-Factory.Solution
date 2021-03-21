using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList(); 
      return View(model);
    }

    public ActionResult Create()
    {
    return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
    _db.Engineers.Add(engineer);
    _db.SaveChanges();
    return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
          .Include(engineer => engineer.JoinEntities)
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    public ActionResult Edit(int id)
    {
    Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
    return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
    _db.Entry(engineer).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Index");
    }

  }
}