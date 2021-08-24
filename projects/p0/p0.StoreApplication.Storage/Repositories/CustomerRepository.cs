using p0.StoreApplication.Domain.Interfaces;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Adapters;
using System.Collections.Generic;

namespace p0.StoreApplication.Storage.Repositories
{
  public class CustomerRepository : IRepository<Customer>
  {
    private const string _path = @"/home/jeffrey/revature/training_repo/data/customers.xml";
    private static readonly FileAdapter _fileAdapter = new FileAdapter();
    public CustomerRepository()
    {

    }
    public bool Delete()
    {
      throw new System.NotImplementedException();
    }

    public bool Insert(Customer entry)
    {
      _fileAdapter.WriteToFile<Customer>(_path, entry);
      return true;
    }

    public List<Customer> Select()
    {
      return _fileAdapter.ReadFromFile<List<Customer>>(_path);
    }

    public Customer Update()
    {
      throw new System.NotImplementedException();
    }
  }
}