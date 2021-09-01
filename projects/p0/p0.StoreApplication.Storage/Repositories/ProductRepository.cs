using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;
using System;

namespace p0.StoreApplication.Storage.Repositories
{
  public class ProductRepository : IRepository<Product>
  {
    private readonly List<Product> products;
    //private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\products.xml";
    //private static readonly FileAdapter _fileAdapter = new();
    public ProductRepository()
    {
      products = new List<Product>()
      {
        new Product(){ ProdcutId = 101, Name = "Bluetooth Speaker", Price = 49.99M, Description = "12 hours of battery life on a single charge and up to 100dB." },
        new Product(){ ProdcutId = 102, Name = "iPhone 12 (128GB)", Price = 849.00M, Description = "Mid-range iPhone. Comes in 6 different colors."},
        new Product(){ ProdcutId = 103, Name = "15.6\" Laptop (1TB)", Price = 1999.99M, Description = "Powerful laptop comes with 16GB of ram and a 1TB SSD." },
        new Product(){ ProdcutId = 104, Name = "External battery", Price = 19.99M, Description = "External battery that connects to your phone for charging. Enough for one full charge."},
        new Product(){ ProdcutId = 201, Name = "Computer desk", Price = 249.99M, Description = "Perfect for working. Comes with drawers for extra storage." },
        new Product(){ ProdcutId = 202, Name = "Office Chair", Price = 199.99M, Description = "Comfortable office chair that supports good posture"},
        new Product(){ ProdcutId = 203, Name = "Organizer", Price = 24.99M, Description = "Helps tidy up a messy desk. Contains many compartments."},
        new Product(){ ProdcutId = 204, Name = "File Cabinet", Price = 59.99M, Description = "Keep your files organized with this 4-drawer file cabinet."},
        new Product(){ ProdcutId = 301, Name = "Blu-Ray Player", Price = 149.99M, Description = "Perfect for playing movies in HD."},
        new Product(){ ProdcutId = 302, Name = "Nintendo Switch", Price = 299.99M, Description = "Fun gaming system from Nintendo"},
        new Product(){ ProdcutId = 203, Name = "55\" 4KTV", Price = 999.99M, Description = "A TV that displays pictures, movies, and games in crystal-clear quality."}
      };
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Product entry)
    {
      products.Add(entry);
      return true;
    }

    public List<Product> Select()
    {
      return products;
    }

    public Product Update()
    {
      throw new System.NotImplementedException();
    }
  }
}