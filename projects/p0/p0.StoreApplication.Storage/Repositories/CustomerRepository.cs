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
    private static readonly DataAdapter _dataAdapter = new();
    public CustomerRepository()
    {
      customers = _dataAdapter.GetCustomers();
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