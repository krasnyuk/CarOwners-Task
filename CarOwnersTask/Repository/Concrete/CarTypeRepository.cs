using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarOwnersTask.Models;
using CarOwnersTask.Repository;
using CarOwnersTask.Repository.Interfaces;
using System.Data.Entity;

namespace CarOwnersTask.Repository.Concrete
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private CarOwnerContext _db;
        public CarTypeRepository()
        {
            _db = new CarOwnerContext();
        }
        public IEnumerable<CarType> CarTypes => _db.CarTypes.ToList();
       
        public void Create(CarType item)
        {
            _db.CarTypes.Add(item);
        }

        public void Delete(int id)
        {
            CarType entry = _db.CarTypes.Find(id);
            if (entry != null)
                _db.CarTypes.Remove(entry);
        }

        public CarType GetCarType(int id)
        {
           return _db.CarTypes.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CarType item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}