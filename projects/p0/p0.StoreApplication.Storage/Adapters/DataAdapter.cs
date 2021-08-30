using Microsoft.EntityFrameworkCore;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace p0.StoreApplication.Storage.Adapters
{
  public class DataAdapter : DbContext
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=StoreApplicationDB;Trusted_Connection=True;");
    }

    public List<Customer> GetCustomers()
    {
      return Customers.FromSqlRaw("select CUSTOMERNAME from Customer.Customer;").ToList();
    }

    public void SetCustomer()
    {

    }

    public List<Order> GetOrders()
    {
      return Orders.FromSqlRaw("select * from Order.StoreOrder;").ToList();
    }

    public void SetOrder()
    {

    }

    public List<Store> GetStores()
    {
      return Stores.FromSqlRaw("select * from Order.Store;").ToList();
    }

    public void SetStore()
    {

    }

    public List<Product> GetProducts()
    {
      return Products.FromSqlRaw("select * from Order.Product;").ToList();
    }

    public void SetProduct()
    {

    }
  }
}