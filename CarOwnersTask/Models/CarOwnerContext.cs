using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarOwnersTask.Models
{
    public class CarOwnerContext : DbContext
    {
        public CarOwnerContext(): base("CarOwnerContext")
        { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<CarType> CarTypes { get; set; }


    }
}