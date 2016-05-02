using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarOwnersTask.Models;
using CarOwnersTask.Repository;
using CarOwnersTask.Repository.Interfaces;

namespace CarOwnersTask.Repository.Concrete
{
    public class CarOwnerRepository : ICarOwnerRepository
    {
        private CarOwnerContext _db;
        public CarOwnerRepository()
        {
            _db = new CarOwnerContext();
        }
        public IEnumerable<CarOwner> CarOwners => _db.CarOwners.ToList();
       
        public void Create(CarOwner item)
        {
            _db.CarOwners.Add(item);
        }
        public void DeleteOwnerForCar(int carId, int ownerId)
        {
            CarOwner entry = _db.CarOwners.Where(x=>x.CarId==carId && x.OwnerId==ownerId).FirstOrDefault();
            if (entry != null)
                _db.CarOwners.Remove(entry);
        }
        public void Delete(int id)
        {
            CarOwner entry = _db.CarOwners.Find(id);
            if (entry != null)
                _db.CarOwners.Remove(entry);
        }

        public CarOwner GetCarOwner(int id)
        {
            return _db.CarOwners.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CarOwner item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}