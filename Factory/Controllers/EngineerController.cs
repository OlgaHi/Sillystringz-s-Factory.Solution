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
      List<Engineer> model = _db.Engineers.ToList(); // the same as GetAll()
      return View(model);
    }
  }
}