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
    private static readonly DataAdapter _dataAdapter = new();
    public ProductRepository()
    {
      products = new List<Product>()
      {
        new Product(){ ProductId = 101, Name = "Bluetooth Speaker", Price = 49.99M, Description = "12 hours of battery life on a single charge and up to 100dB." },
        new Product(){ ProductId = 102, Name = "Lightning Cable", Price = 9.99M, Description = "Lightning cable for iPhone, iPad, and iPod Touch" },
        new Product(){ ProductId = 103, Name = "External battery", Price = 19.99M, Description = "External battery that connects to your phone for charging. Enough for one full charge."},
        new Product(){ ProductId = 201, Name = "Office Chair", Price = 149.99M, Description = "Comfortable office chair that supports good posture"},
        new Product(){ ProductId = 202, Name = "Organizer", Price = 24.99M, Description = "Helps tidy up a messy desk. Contains many compartments."},
        new Product(){ ProductId = 203, Name = "File Cabinet", Price = 59.99M, Description = "Keep your files organized with this 4-drawer file cabinet."},
        new Product(){ ProductId = 301, Name = "Blu-Ray Player", Price = 99.99M, Description = "Perfect for playing movies in HD."},
        new Product(){ ProductId = 302, Name = "Nintendo Switch Lite", Price = 199.99M, Description = "Fun and lightweight gaming system from Nintendo"},
        new Product(){ ProductId = 303, Name = "Mario Kart 8 Deluxe", Price = 59.99M, Description = "Fun kart racing game from Nintendo."},
        new Product(){ ProductId = 304, Name = "Funyuns", Price = 1.99M, Description = "A medium-sized bag of some delicious onion ring-shaped chips"},
        new Product(){ ProductId = 305, Name = "Dasani Water Bottle", Price = 1.50M, Description = "Thirsty? Get some bottled water."}
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