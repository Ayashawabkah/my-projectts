using E_Commerce.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{


    public class CategoryRepository : ISharedRespository<Category>
    {
        private readonly ApplicationDbContext db;  // we must call the main class
                                                   // to use the category & prosucts
        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;  // initialization // we can edit the readonly ..only by the constructor

        }





        public void Add(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            db.Categories.Remove(db.Categories.Find(Id));
            db.SaveChanges();
        }

        public Category FindBy(int Id)
        {
            return db.Categories.Find(Id);
        }

        public IEnumerable<Category> List(int? id)
        {
            return db.Categories.ToList();
        }

        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();

        }
    }
}
