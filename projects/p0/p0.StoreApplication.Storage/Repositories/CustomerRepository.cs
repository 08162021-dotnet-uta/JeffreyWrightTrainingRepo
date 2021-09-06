using p0.StoreApplication.Storage.Model;
using p0.StoreApplication.Storage.Adapters;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using p0.StoreApplication.Domain.Interfaces;

namespace p0.StoreApplication.Storage.Repositories
{
  public class CustomerRepository : IRepository<Customer>
  {
    private readonly List<Customer> customers;
    private static readonly DataAdapter _dataAdapter = new();
    public CustomerRepository()
    {
      using (var context = new StoreApplicationDBContext())
      {
        customers = context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customer.Customer").ToList();
      }
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