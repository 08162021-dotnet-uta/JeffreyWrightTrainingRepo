using Microsoft.EntityFrameworkCore;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Domain.Abstracts;
using System.Collections.Generic;

namespace p0.StoreApplication.Storage.Adapters
{
  public class DataAdapter : DbContext
  {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Stores> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=StoreApplicationDB;Trusted_Connection=True;");
    }

    public List<Customer> ReadCustomers()
    {
      return Customers.FromSqlRaw("select CUSTOMERNAME from Customer.Customer;");
    }
  }
}