namespace SaladApi.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public bool Delivered { get; set; }

        public virtual Salad Salad { get; set; }

        public virtual Drink Drink { get; set; }

        public virtual User User { get; set; }
        
    }
}
