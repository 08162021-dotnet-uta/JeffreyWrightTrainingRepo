using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;

namespace p0.StoreApplication.Domain.Interfaces
{
  public interface IRepository<T> where T : class
  {
    bool Insert(T entry);
    bool Update();
    List<T> Select();
    bool Delete();
  }
}