using System;
using System.Collections.Generic;

namespace StoreAdminApi.Model
{
public interface IAdminDataRepository{
public List<Product> getAllProducts();
public Product getProductById(int id);
public void addProduct(Product product);
public void editProduct(Product product);

public void deleteProduct(Product product);
}
}
