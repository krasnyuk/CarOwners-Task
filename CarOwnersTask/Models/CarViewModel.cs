using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarOwnersTask.Models
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<SelectListItem> CarTypes { get; set; }
    }
}