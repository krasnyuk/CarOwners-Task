using CarOwnersTask.Models;
using CarOwnersTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarOwnersTask.Models.ViewModels;

namespace CarOwnersTask.Controllers
{
    //Контроллер для владельцев автомобилей
    public class OwnersController : Controller
    {
        //репозитории
        private ICarRepository _carRepository;
        private ICarTypeRepository _carTypeRepository;
        private ICarOwnerRepository _carOwnerRepository;
        private IOwnerRepository _ownerRepository;

        public OwnersController(ICarRepository carRep, ICarTypeRepository carTypeRep, ICarOwnerRepository carOwnRep, IOwnerRepository ownRep)
        {
            _carRepository = carRep;
            _carTypeRepository = carTypeRep;
            _carOwnerRepository = carOwnRep;
            _ownerRepository = ownRep;
        }
        //Представление со списком всех владельцов
        public ActionResult Index()
        {
            return View(_ownerRepository.Owners);
        }

        //Редактирование владельца, получаем Id как RouteValue 
        public ActionResult Edit(int ownerId)
        {
            Owner owner = _ownerRepository.GetOwner(ownerId);
            if (owner == null)
                return HttpNotFound();
            return View(owner);
        }
        //Сохранение результатов редактирования
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Owner model)
        {
            if (ModelState.IsValid) //если модель верна
            {
                var entry = _ownerRepository.GetOwner(model.OwnerId);
                entry.LastName = model.LastName;
                entry.FirstName = model.FirstName;
                entry.BirthDate = model.BirthDate;
                entry.Experience = model.Experience;
                _ownerRepository.Save();
                return RedirectToAction("Index");
            }
            else //вернуть список ошибок
            {
                return View(model);
            }

        }
        //удаление владельца по ID
        public ActionResult Delete(int ownerId)
        {
            Owner owner = _ownerRepository.GetOwner(ownerId);
            if (owner == null)
                return HttpNotFound();
            return View(owner);
        }
        //подтверждение и удаление
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ownerId)
        {
            Owner owner = _ownerRepository.GetOwner(ownerId);
            _ownerRepository.Delete(ownerId);
            _ownerRepository.Save();
            return RedirectToAction("Index");
        }
        //Создание владельца
        [HttpPost]
        public ActionResult Create(Owner model)
        {
            _ownerRepository.Create(model);
            _ownerRepository.Save();
            return RedirectToAction("Index");
        }
        //Показать список машин для заданного владельца
        public ActionResult Cars(int ownerId)
        {
            OwnerCarsViewModel model = new OwnerCarsViewModel
            {
                OwnerId = ownerId, //его ID
                Cars = from u in _carOwnerRepository.CarOwners //Машины, которыми он владеет
                       from inf in _carRepository.Cars
                       where (u.CarId == inf.CarId && u.OwnerId == ownerId)
                       select inf
            };
            return View(model);
        }
        //Создание машины для заданного владельца
        [HttpPost]
        public ActionResult CreateCarForOwner(int ownerId, int CarId)
        {
            CarOwner item = new CarOwner
            {
                OwnerId = ownerId,
                CarId = CarId
            };
            _carOwnerRepository.Create(item);
            _carOwnerRepository.Save();
            return RedirectToAction("Cars", new { ownerId = ownerId });
        }
        //Удаление машины для заданного владельца
        public ActionResult DeleteCarOfOwner(int ownerId, int carId)
        {
            _carOwnerRepository.DeleteOwnerForCar(carId, ownerId);
            _carOwnerRepository.Save();
            return View("Index", _ownerRepository.Owners);
        }
        //Частичное представление - новая машина для владельца из списка доступных
        public PartialViewResult NewCar(int ownerId)
        {
            OwnerCarsViewModel model = new OwnerCarsViewModel
            {
                OwnerId = ownerId,
                Cars = _carRepository.Cars,
                selectList = from i in _carRepository.Cars
                       select new SelectListItem
                       {
                           Text = i.Brand + " " + i.Model + " " + i.ManufactureYear.Year,
                           Value = i.CarId.ToString()
                       }
            };
            return PartialView("_CreateCarForOwner", model);
        }
        public PartialViewResult NewOwner()
        {
            return PartialView("_Create");
        }
    }
}