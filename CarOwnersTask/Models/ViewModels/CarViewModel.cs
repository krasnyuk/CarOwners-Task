using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarOwnersTask.Models
{
    public class CarViewModel
    {
        public Car Car { get; set; } //машина
        public IEnumerable<SelectListItem> CarTypes { get; set; } //типы автомобилей для drop-down
    }
}