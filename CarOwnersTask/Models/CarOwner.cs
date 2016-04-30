namespace CarOwnersTask.Models
{
    public class CarOwner
    {
        public int CarOwnerId { get; set; }
        public int CarId { get; set; }
        public int OwnerId { get; set; }
        public virtual  Car Car { get; set; }
        public virtual Owner Owner { get; set; }

    }
}