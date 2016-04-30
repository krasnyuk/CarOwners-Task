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
    public class OwnerRepository : IOwnerRepository
    {
        private CarOwnerContext _db;
        public OwnerRepository()
        {
            _db = new CarOwnerContext();
        }

        public IEnumerable<Owner> Owners => _db.Owners.ToList();
        
        public void Create(Owner item)
        {
            _db.Owners.Add(item);
        }

        public void Delete(int id)
        {
            Owner entry = _db.Owners.Find(id);
            if (entry != null)
                _db.Owners.Remove(entry);
        }

        public Owner GetCar(int id)
        {
            return _db.Owners.Find(id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Owner item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}