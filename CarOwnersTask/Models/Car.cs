using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarOwnersTask.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; } 

        public string Model { get; set; }
       
        public double Price { get; set; }
        public DateTime ManufactureYear { get; set; }


        public int CarTypeId { get; set; }
        public virtual CarType CarType { get; set; }
        public virtual ICollection<CarOwner> CarOwners {get; set;}

    }
    //public enum CarType
    //{
    //    Passenger,
    //    Truck
    //}
}