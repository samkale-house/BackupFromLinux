using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StoreAdminApi.Model
{
    public class SqlAdminDataRepo : IAdminDataRepository
    {
        private StoreAdminContext db;
        public SqlAdminDataRepo(StoreAdminContext _db)
        {
         db=_db;
        }
        public void addProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChangesAsync();
        }

        public void deleteProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChangesAsync();
        }

        public void editProduct(Product model)
        {
            Product product=db.Products.Find(model.Product_Id);
            if(product!=null)
            {
                try{
             db.Entry(product).State=EntityState.Modified;
             db.SaveChangesAsync();}
             catch(DbUpdateConcurrencyException){ throw;}
            }
            else{ throw new Exception ("product to be update doesn't exist in database");}
        }

        public List<Product> getAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product getProductById(int id)
        {
            return db.Products.Find(id);
        }

    }
}