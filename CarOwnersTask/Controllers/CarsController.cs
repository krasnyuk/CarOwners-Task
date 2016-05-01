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
        private ICarTypeRepository _carTypeRep;
        public CarsController(ICarRepository carRep, ICarTypeRepository carTypeRep)
        {
            _carRep = carRep;
            _carTypeRep = carTypeRep;
        }
        public ActionResult Index()
        {
            return View(_carRep.Cars);
        }
        [HttpPost]
        public ActionResult Create(CarViewModel model, int CarTypeId)
        {
            model.Car.CarTypeId = CarTypeId;
            _carRep.Create(model.Car);
            _carRep.Save();
            return RedirectToAction("Index");
        }
        public PartialViewResult NewCar()
        {
            CarViewModel car = new CarViewModel
            {
                CarTypes = from g in _carTypeRep.CarTypes
                           select new SelectListItem {
                               Text = g.Title,
                               Value = g.CarTypeId.ToString() }
            };


            return PartialView("Create",car);
        }
    }
}