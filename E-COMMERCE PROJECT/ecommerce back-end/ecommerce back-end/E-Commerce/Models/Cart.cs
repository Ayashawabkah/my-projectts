namespace E_Commerce.Models
{
    public class Cart : Shared_class
    {
        ////public int CartId { get; set; }
        public int ProductId { get; set; }
       
        public int UserId { get; set; }

        public int Quantity { get; set; }

        public Products Product { get; set; }//to ensure that they are fk ies from the 1 side
        public User User { get; set; }
    }
}
