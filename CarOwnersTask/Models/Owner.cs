using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarOwnersTask.Models
{
    public class Owner
    {
        [Required]
        public int OwnerId { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [Display(Name = "Last name")]
        public string LastName {get; set; } //фамилия 

        [Required(ErrorMessage = "First name is required!")]
        [Display(Name = "First name")]
        public string FirstName { get; set; } //имя

        [Required(ErrorMessage = "Birth date is required!")]
        [Display(Name = "Birth date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; } //дата рождения

        [Required(ErrorMessage = "Driver experience is required!")]
        public double Experience { get; set; } //опыт вождения

        public string FullName //Имя + Фамилия
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