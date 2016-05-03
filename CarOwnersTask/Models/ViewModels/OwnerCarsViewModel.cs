using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarOwnersTask.Models.ViewModels
{
    public class OwnerCarsViewModel
    {
        public int OwnerId { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<SelectListItem> selectList { get; set;}
    }
}