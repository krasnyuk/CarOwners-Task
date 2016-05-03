using CarOwnersTask.Models;
using CarOwnersTask.Models.ViewModels;
using CarOwnersTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarOwnersTask.Controllers
{
    //Контроллер для машин
    public class CarsController : Controller
    {
        //объекты для взаимодействия с репозиториями
        private ICarRepository _carRepository;
        private ICarTypeRepository _carTypeRepository;
        private ICarOwnerRepository _carOwnerRepository;
        private IOwnerRepository _ownerRepository;
        public CarsController(ICarRepository carRep, ICarTypeRepository carTypeRep, ICarOwnerRepository carOwnRep, IOwnerRepository ownRep)
        {
            _carRepository = carRep;
            _carTypeRepository = carTypeRep;
            _carOwnerRepository = carOwnRep;
            _ownerRepository = ownRep;
        }
        //главная страница со списком машин
        public ActionResult Index()
        {
            return View(_carRepository.Cars);
        }
        //редактирование машины по ID
        public ActionResult Edit(int id)
        {
            CarViewModel model = new CarViewModel
            {
                Car = _carRepository.GetCar(id),
                CarTypes = from g in _carTypeRepository.CarTypes
                           select new SelectListItem
                           {
                               Text = g.Title,
                               Value = g.CarTypeId.ToString()
                           }
            };
            if (model.Car == null)
                return HttpNotFound();
            return View(model);
        }
        //Сохранения результатов редактирования POST-запросом
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CarViewModel model, int CarTypeId)
        {
            if (ModelState.IsValid)
            {
                var entry = _carRepository.GetCar(model.Car.CarId);
                entry.CarTypeId = CarTypeId; //берём из drop-down list'a
                entry.Brand = model.Car.Brand;
                entry.Model = model.Car.Model;
                entry.ManufactureYear = model.Car.ManufactureYear;
                _carRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                CarViewModel car = new CarViewModel
                {
                    Car = _carRepository.GetCar(model.Car.CarId),
                    CarTypes = from g in _carTypeRepository.CarTypes
                               select new SelectListItem
                               {
                                   Text = g.Title,
                                   Value = g.CarTypeId.ToString()
                               }
                };
                return View(car);
            }
        }
        //добавление новой машины
        [HttpPost]
        public ActionResult Create(CarViewModel model, int CarTypeId)
        {
            model.Car.CarTypeId = CarTypeId;
            _carRepository.Create(model.Car);
            _carRepository.Save();
            return RedirectToAction("Index"); //перенаправление на главную страницу со списком
        }
        //Показывает представление, с запросом на удаление
        public ActionResult Delete(int id)
        {
            
            Car car = _carRepository.GetCar(id);
            if (car == null)
                return HttpNotFound();
            return View(car);
        }
        //Удаление машины по ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _carRepository.GetCar(id);
            _carRepository.Delete(id);
            _carRepository.Save();
            return RedirectToAction("Index");
        }
        //Удаление владельца машины по ID владельца и ID машины
        public ActionResult DeleteOwner(int ownerId, int carId)
        {
            _carOwnerRepository.DeleteOwnerForCar(carId, ownerId);
            _carOwnerRepository.Save();
            return View("Index",_carRepository.Cars);
        }
        //Показывает владельцов машины с заданным ID
        public ActionResult Owners(int id)
        {
            CarOwnerViewModel model = new CarOwnerViewModel
            {
                Owners = from u in _carOwnerRepository.CarOwners
                        from inf in _ownerRepository.Owners
                        where (u.OwnerId == inf.OwnerId && u.CarId == id)
                        select inf,
                CarId = id
            };
       
            return View(model);
        }
        //Создание владельца для машины по ID
        [HttpPost]
        public ActionResult CreateOwnerForCar(int OwnerId, int carId)
        {
            CarOwner item = new CarOwner
            {
                OwnerId = OwnerId,
                CarId = carId
            };
            _carOwnerRepository.Create(item);
            _carOwnerRepository.Save();
            
            return RedirectToAction("Owners", new { id = carId});
        }
        //Дочернее действие, которое возвращает частичное представление "Create"
        public PartialViewResult NewCar()
        {
            CarViewModel car = new CarViewModel
            {
                CarTypes = from g in _carTypeRepository.CarTypes
                           select new SelectListItem {
                               Text = g.Title,
                               Value = g.CarTypeId.ToString() }
            };


            return PartialView("Create",car);
        }
        //Новый владелец
        public PartialViewResult NewOwner(int carId)
        {
            CarOwnerViewModel model = new CarOwnerViewModel
            {
                CarId = carId,
                Owners = from o in _ownerRepository.Owners
                         select o,
                list = from i in _ownerRepository.Owners
                       select new SelectListItem
                       {
                           Text = i.FullName,
                           Value = i.OwnerId.ToString()
                       }
            };
            return PartialView("_CreateOwnerForCar", model);
        }
    }
}