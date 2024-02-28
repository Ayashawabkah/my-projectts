namespace E_Commerce.Models
{
    public interface ISharedRespository <T> where T : class  // thats called generics
                                                             // a variable as class
                                                             // to make the code reusable and 
                                                             //enhance performance
    {
        // CRUD → create, read, update & delete

        public IEnumerable<T> List();

            public void Add(T item);  
            public void Update(T item);
            public void delete(int Id );
            public T FindBy(int Id );
          





    }
}
