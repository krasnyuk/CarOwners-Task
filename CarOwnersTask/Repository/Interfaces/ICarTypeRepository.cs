using CarOwnersTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwnersTask.Repository.Interfaces
{
    public interface ICarTypeRepository
    {
        IEnumerable<CarType> CarTypes { get; }

        CarType GetCarType(int id);
        void Create(CarType item);
        void Update(CarType item);
        void Delete(int id);
        void Save();
    }
}
