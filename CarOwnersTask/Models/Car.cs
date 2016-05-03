using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarOwnersTask.Models
{
    public class Car
    {
        [Required]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Brand is required!")]
        public string Brand { get; set; } //брэнд авто

        [Required(ErrorMessage = "Model is required!")]
        public string Model { get; set; } //модель

        [Required(ErrorMessage = "Price is required!")]
        public double Price { get; set; } //цена

        [Required(ErrorMessage = "Manufacturer is required!")]
        [Display(Name = "Year of manufacturing")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ManufactureYear { get; set; } //год производства

        //свойства навигации
        public int CarTypeId { get; set; } 
        public virtual CarType CarType { get; set; }
        public virtual ICollection<CarOwner> CarOwners {get; set;}

    }

}