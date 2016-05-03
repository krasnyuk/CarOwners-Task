using CarOwnersTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOwnersTask.Repository.Interfaces
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> Owners { get; }
        Owner GetOwner(int id);
        void Create(Owner item);
        void Update(Owner item);
        void Delete(int id);
        void Save();
    }
}
