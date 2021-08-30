using System;
using System.Collections.Generic;
using p0.StoreApplication.Domain.Abstracts;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Storage.Repositories;
using p0.StoreApplication.Client.Singletons;
using Serilog;
using System.IO;

namespace p0.StoreApplication.Client
{
  /// <summary>
  /// Defines the Program class
  /// </summary>
  class Program
  {
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
    private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
    private static readonly ProductSingleton _productSingleton = ProductSingleton.Instance;
    private static readonly OrderSingleton _orderSingleton = OrderSingleton.Instance;
    //This references a path that will hold the logs. It is stored within the AppData\Roaming folder.
    private static readonly string _logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\log.txt";
    /// <summary>
    /// Defines the main function
    /// </summary>
    /// <param name="args">String Args</param>
    static void Main(string[] args)
    {
      if(!File.Exists(_logPath))
      {
        Directory.CreateDirectory(_logPath.Substring(0, _logPath.LastIndexOf('\\')));
        File.CreateText(_logPath);
      }
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logPath).CreateLogger();
      var p = new Program();
      Console.WriteLine("Welcome to The Store!");
      p.DisplayMenu();
    }
    /// <summary>
    /// Displays the Menu
    /// </summary>
    private void DisplayMenu()
    {
      Log.Information("Method: Display Menu");
      Console.WriteLine("1: View customers");
      Console.WriteLine("3: View store locations");
      Console.WriteLine("4: Select store");
      //Console.WriteLine("3: View products to purchase");
      //Console.WriteLine("4: View past purchases");
      Console.WriteLine("7: Log Out");
      Console.Write("Select an option: ");
      try
      {
        Menu(int.Parse(Console.ReadLine()));
      }
      catch (Exception e)
      {
        Console.WriteLine($"Generic Exception Handler: {e}");
      }
    }
    /// <summary>
    /// Selects the option in the menu
    /// </summary>
    /// <param name="option"></param>
    private void Menu(int option)
    {
      switch (option)
      {
        case 1:
          Console.WriteLine(_customerSingleton);
          /*var customers = new List<Customer>
          {
            new Customer() { Name = "Elizabeth Medford" },
            new Customer() { Name = "Nicole Medford" },
            new Customer() { Name = "Henry Medford" }
          };
          Output<Customer>(_customerSingleton.Customers);*/
          break;
        case 2:
          Console.WriteLine(SelectCustomer() + "\n");
          break;
        case 3:
          var stores = new List<Store>()
          {
            new FurnitureStore(){ Name = "IKEA", State = "IN", City = "Fishers"},
            new TechStore(){ Name = "Best Buy", State = "TX", City = "San Antonio" },
            new MultimediaStore(){ Name = "Jeffrey's Home Entertainment", State = "AZ", City = "Mesa" },
            new TechStore(){ Name = "Smartphones and Gizmos", State = "CA", City = "Long Beach"},
            new MultimediaStore(){ Name = "Smithsonian Museum Media Collection", State = "DC", City = "Washington"},
            new FurnitureStore(){ Name = "Cool Funiture", State = "UT", City = "Orem"}
          };
          //Output<Store>(_storeSingleton.Stores);
          break;
        case 4:
          Console.WriteLine(SelectStore() + "\n");
          break;
        case 7:
          break;
      }
      if (option != 7)
        DisplayMenu();
    }

    private static void Output<T>(List<T> data) where T : class
    {
      //Log.Information("Method: Output");
      var i = 1;

      foreach (var item in data)
      {
        Console.WriteLine(i + ": " + item);
        i++;
      }
      Console.WriteLine("");
    }

    private Customer SelectCustomer()
    {
      //Log.Information("Method: Select Customer");

      //Access the stores from the store repository
      var customers = (_customerSingleton.Customers);

      //Prompt to select a store
      Console.Write("Select a Customer: ");

      //Return the store of the user input
      return (customers[int.Parse(Console.ReadLine()) - 1]);
    }

    private Store SelectStore()
    {
      //Log.Information("Method: Select Store");

      //Access the stores from the store repository
      //var stores = (_storeSingleton.Stores);

      //Prompt to select a store
      Console.Write("Select a Store: ");

      //Return the store of the user input
      //return (stores[int.Parse(Console.ReadLine()) - 1
      return null;
    }

    private Product SelectProduct()
    {
      //Log.Information("Method: Select Product");

      //Access the products from the product repository
      var products = (_productSingleton.Products);

      //Prompt to select a store
      Console.Write("Select a Product: ");

      //Return the store of the user input
      return (products[int.Parse(Console.ReadLine()) - 1]);
    }
  }
}
