using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System;
using System.Collections.Generic;

namespace p0.StoreApplication.Storage.Repositories
{
  public class CustomerRepository : IRepository<Customer>
  {
    private readonly List<Customer> customers;
    //private readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\customers.xml";
    //private static readonly FileAdapter _fileAdapter = new();
    public CustomerRepository()
    {
      customers = new List<Customer>
      {
        new Customer() { Name = "Jeffrey Wright" },
        new Customer() { Name = "Michael Wright" },
        new Customer() { Name = "Catherine Wright" }
      };
    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Customer entry)
    {
      customers.Add(entry);
      return true;
    }

    public List<Customer> Select()
    {
      return customers;
    }

    public Customer Update()
    {
      throw new System.NotImplementedException();
    }
  }
}