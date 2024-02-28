namespace E_Commerce.Models
{
    public class Products : Shared_class
    {
        public virtual decimal price { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsSale { get; set; }
        public virtual decimal AfterSale { get; set; }


        public virtual int CategoryId { get; set; }  // must be together to create fk
        public virtual Category? category { get; set; } // to know its not a prop
                                                       // but its a fk
                                                      // fk → foriegn key 

        // thats called composition → to create relations between classes
    }          












}
