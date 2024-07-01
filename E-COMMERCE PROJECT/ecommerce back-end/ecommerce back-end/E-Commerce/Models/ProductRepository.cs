using E_Commerce.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Models
{
    public class ProductRepository : ISharedRespository<Products>

    {   // // we can reuse the methods because of the interface

        private readonly ApplicationDbContext db;    // // select then ctrl and dot
                                                     // // to create the constructor quiqly

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Products item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            db.Products.Remove(db.Products.Find(Id));
            db.SaveChanges();
        }

        public Products FindBy(int Id)
        {
            return db.Products.Find(Id);
        }

        public IEnumerable<Products> List(int? id)
        {
            if (id==null)
            {
                return db.Products.ToList();
            }
            else
            {
                return db.Products.Where(p => p.CategoryId == id).ToList();
            }
            
        }

        public void Update(Products item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }



        ////public IEnumerable<Products> List(int id)
        ////{
        ////    return db.Products.Where(p=>p.CategoryId == id).ToList(); 
        ////    // where clause to put conditions
        ////}
        ///
    }
}
