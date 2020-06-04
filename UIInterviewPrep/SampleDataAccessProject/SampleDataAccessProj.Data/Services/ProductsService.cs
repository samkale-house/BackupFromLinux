using System;
using System.Collections.Generic;
using System.Linq;
using SampleDataAccessProj.Data.Models;

namespace SampleDataAccessProj.Data.Services
{
    public class ProductService
    {
        AppDbContext appDbContext = new AppDbContext();

        public IEnumerable<Product> getProducts()
        {
            try { return appDbContext.products.ToList(); } catch (Exception ex) { Console.Write(ex); }
            return appDbContext.products.ToList();
        }
        public Product getProductById(int id)
        {
            return appDbContext.products.FirstOrDefault(product => product.Product_Id == id);
        }
    }
}