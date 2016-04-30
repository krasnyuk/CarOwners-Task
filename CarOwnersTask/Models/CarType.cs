using System.Collections.Generic;

namespace CarOwnersTask.Models
{
    public class CarType
    {
        public int CarTypeId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}