using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarOwnersTask.Models.ViewModels
{
    public class CarOwnerViewModel
    {
        public IEnumerable<Owner> Owners { get; set; } //список владельцев
        public int CarId { get; set; } //ID машины
        public IEnumerable<SelectListItem> list { get; set; } //список для drop-down list
    }
}