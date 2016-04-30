using CarOwnersTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwnersTask.Repository.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }
        Car GetCar(int id);
        void Create(Car item);
        void Update(Car item);
        void Delete(int id);
        void Save();
    }
}
