using System;
using Microsoft.EntityFrameworkCore;

namespace StoreAdminApi.Model
{
public class StoreAdminContext:DbContext
{
    public StoreAdminContext(DbContextOptions<StoreAdminContext> options)
            : base(options)
        {
        }
    public DbSet<Product> Products{get;set;}
}
}
