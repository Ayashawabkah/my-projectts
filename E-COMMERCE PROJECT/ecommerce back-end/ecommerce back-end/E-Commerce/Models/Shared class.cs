namespace E_Commerce.Models
{
    public abstract class Shared_class
    {
        // virtual → use lazy loading  →
        // that means dont bring me anything except when i call it 
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }

       
    }
}
