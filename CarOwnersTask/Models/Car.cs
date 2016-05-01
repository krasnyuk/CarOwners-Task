using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarOwnersTask.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Brand is required!")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required!")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Manufacturer is required!")]
        [Display(Name = "Year of manufacturing")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
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