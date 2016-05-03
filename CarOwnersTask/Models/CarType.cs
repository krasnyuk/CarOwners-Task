using System.Collections.Generic;

namespace CarOwnersTask.Models
{
    //Тип нашего автомобиля
    public class CarType
    {
        public int CarTypeId { get; set; } 
        public string Title { get; set; } //название
        public virtual ICollection<Car> Cars { get; set; }
    }
}