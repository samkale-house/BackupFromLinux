using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreAdminApi.Model;

namespace StoreAdminApi.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class StoreAdminController:ControllerBase    {
     private StoreAdminContext db;
     public StoreAdminController(StoreAdminContext _db)
     {
     db=_db;
     }
    
/*    
[HttpGet("{id}")]
public async Task<ActionResult<Product>> GetProduct(int id)
{
    var product = await db.Products.FindAsync(id);

    if (product == null)
    {
        return NotFound();
    }

    return product;
}
*/
[HttpGet]
public IEnumerable<Product> GetProducts()
{
    return db.Products.ToList();
}


/*
   // GET: api/TodoItems/5
[HttpGet("{id}")]
public async Task<ActionResult<Product>> AddProduct(Product product)
{
    if(ModelState.IsValid)
    {
    await db.Products.AddAsync(product);
    await db.SaveChangesAsync();
    }

    else
    {
        return BadRequest("Invalid data entered");
            
            }

    return product;
}    
  */  
    
    }
}