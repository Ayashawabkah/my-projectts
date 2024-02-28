namespace E_Commerce.Models
{
    public class Category : Shared_class
    {
       public virtual IEnumerable<Products>? Products { get; set;}

    }
}
