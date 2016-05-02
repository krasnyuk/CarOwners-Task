using CarOwnersTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwnersTask.Repository.Interfaces
{
    public interface ICarOwnerRepository
    {
        IEnumerable<CarOwner> CarOwners { get; }
        CarOwner GetCarOwner(int id);
        void Create(CarOwner item);
        void Update(CarOwner item);
        void Delete(int id);
        void Save();
        void DeleteOwnerForCar(int carId, int ownerId);
    }
}
