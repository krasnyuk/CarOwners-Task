using CarOwnersTask.Models;
using CarOwnersTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarOwnersTask.Controllers
{
    public class CarsController : Controller
    {
        private ICarRepository _carRep;
        public CarsController(ICarRepository rep)
        {
            _carRep = rep;
        }
        public ActionResult Index()
        {
            return View(_carRep.Cars);
        }
    }
}