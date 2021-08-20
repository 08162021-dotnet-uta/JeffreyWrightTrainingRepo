using System;
using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Repositories;

namespace p0.StoreApplication.Client
{
  class Program
  {
    static void Main(string[] args)
    {
      var p = new Program();
      Console.WriteLine("Welcome to The Store!");
      p.DisplayMenu();
    }

    private void DisplayMenu()
    {
      Console.WriteLine("1: View store locations");
      Console.WriteLine("2: Select store");
      //Console.WriteLine("3: View products to purchase");
      //Console.WriteLine("4: View past purchases");
      Console.WriteLine("5: Log Out");
      Console.Write("Select an option: ");
      var option = int.Parse(Console.ReadLine());
      switch (option)
      {
        case 1:
          PrintAllStoreLocations();
          break;
        case 2:
          Console.WriteLine(SelectStore() +"\n");
          break;
        case 5:
          break;
      }
      if (option != 5)
        DisplayMenu();
    }

    private void PrintAllStoreLocations()
    {
      var storeRepository = new StoreRepository();
      var i = 1;

      foreach (var store in storeRepository.Stores)
      {
        Console.WriteLine(i + ": " + store);
        i++;
      }
      Console.WriteLine("");
    }

    private Store SelectStore()
    {
      //Access the stores from the store repository
      var stores = (new StoreRepository().Stores);

      //Prompt to select a store
      Console.Write("Select a Store: ");

      //Return the store of the user input
      return (stores[int.Parse(Console.ReadLine()) - 1]);
    }
  }
}
