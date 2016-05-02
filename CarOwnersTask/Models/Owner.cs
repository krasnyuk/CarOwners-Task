using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarOwnersTask.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string LastName {get; set;}
        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }
        public double Experience { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        //navigation property
        public virtual ICollection<CarOwner> CarOwners {get; set;}
    }
}