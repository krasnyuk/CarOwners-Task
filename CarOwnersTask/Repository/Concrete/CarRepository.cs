using CarOwnersTask.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarOwnersTask.Models;
using System.Data.Entity;

namespace CarOwnersTask.Repository.Concrete
{
    public class CarRepository : ICarRepository
    {
        private CarOwnerContext _db;
        public CarRepository()
        {
            _db = new CarOwnerContext();
        }
        public IEnumerable<Car> Cars => _db.Cars.ToList();
        
        public void Create(Car item)
        {
            _db.Cars.Add(item);
        }

        public void Delete(int id)
        {
            Car entry = _db.Cars.Find(id);
            if (entry != null)
                _db.Cars.Remove(entry);
        }

        public Car GetCar(int id)
        {
            return _db.Cars.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Car item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}