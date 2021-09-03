using System;
using System.Collections.Generic;
using p0.StoreApplication.Domain.Models;
using p0.StoreApplication.Client.Singletons;
using Serilog;
using p0.StoreApplication.Storage.Adapters;

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
    protected Customer customer;
    protected Store store;
    private static readonly List<Product> cart = new();
    //This references a path that will hold the logs. It is stored within the AppData\Roaming folder.
    //private static readonly string _logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Revature\dotnet-batch-2021-08-p0\StoreApplication\log.txt";
    /// <summary>
    /// Defines the main function
    /// </summary>
    /// <param name="args">String Args</param>
    static void Main(string[] args)
    {
      /*if(!File.Exists(_logPath))
      {
        Directory.CreateDirectory(_logPath.Substring(0, _logPath.LastIndexOf('\\')));
        File.CreateText(_logPath);
      }*/
      /*Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
      var p = new Program();
      Console.WriteLine("Welcome to my storefront!");
      p.DisplayMenu();*/
      DataAdapter da = new DataAdapter();
      List<Customer> customers = da.GetCustomers();
    }
    /// <summary>
    /// Displays the Menu
    /// </summary>
    private void DisplayMenu()
    {
      Log.Information("Method: Display Menu");
      Console.WriteLine("1: Select customer");
      Console.WriteLine("2: Select store");
      Console.WriteLine("3: Add products to cart");
      Console.WriteLine("4: View cart");
      Console.WriteLine("5: View orders");
      Console.WriteLine("6: Log Out");
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
          Output<Customer>(_customerSingleton.Customers);
          SelectCustomer(out customer);
          break;
        case 2:
          Output<Store>(_storeSingleton.Stores);
          SelectStore(out store);
          break;
        case 3:
          Output<Product>(_productSingleton.Products);
          cart.Add(SelectProduct());
          break;
        case 4:
          ViewCart();
          break;
        case 5:
          OutputOrder<Order>(_orderSingleton.Orders, customer);
          break;
        case 6:
          break;
      }
      if (option != 6)
        DisplayMenu();
    }
    /// <summary>
    /// Output the list of objects
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    private static void Output<T>(List<T> data) where T : class
    {
      Log.Information("Method: Output");
      var i = 1;

      foreach (var item in data)
      {
        Console.WriteLine(i + ": " + item);
        i++;
      }
      Console.WriteLine("");
    }
    /// <summary>
    /// Selects a customer
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    private void SelectCustomer(out Customer customer)
    {
      Log.Information("Method: Select Customer");

      //Access the customers from the customer repository
      var customers = (_customerSingleton.Customers);

      //Prompt to select a customer
      Console.Write("Select a Customer: ");

      //Prompt for user input to get a customer
      Customer cust = customers[int.Parse(Console.ReadLine()) - 1];

      //Displays the customer selected
      Console.WriteLine(cust);

      //Return the customer of the customer input
      customer = cust;
    }
    /// <summary>
    /// Selects a store
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    private void SelectStore(out Store store)
    {
      Log.Information("Method: Select Store");

      //Access the stores from the store repository
      var stores = (_storeSingleton.Stores);

      //Prompt to select a store
      Console.Write("Select a Store: ");

      //Prompt for user input to get a store
      Store st = stores[int.Parse(Console.ReadLine()) - 1];

      //Displays the customer selected
      Console.WriteLine(st);

      //Return the customer of the customer input
      store = st;
    }
    /// <summary>
    /// Selects a product and adds it to the cart
    /// </summary>
    /// <returns></returns>
    private Product SelectProduct()
    {
      Log.Information("Method: Select Product");

      //Access the products from the product repository
      var products = (_productSingleton.Products);

      //Prompt to select a product
      Console.Write("Select a Product: ");

      //Return the product of the user input
      Product product = products[int.Parse(Console.ReadLine()) - 1];

      Console.WriteLine(product);

      return product;
    }
    /// <summary>
    /// Views the cart
    /// </summary>
    private void ViewCart()
    {
      Log.Information("Method: View Cart");
      decimal subtotal = 0.00M;
      for (int i = 0; i < cart.Count; i++)
      {
        Console.WriteLine(cart[i]);
        subtotal += cart[i].Price;
      }
      Console.WriteLine($"Subtotal: ${subtotal}");
      DisplayCartMenu();
    }
    /// <summary>
    /// Displays the cart menu
    /// </summary>
    private void DisplayCartMenu()
    {
      Log.Information("Method: Display Cart Menu");
      Console.WriteLine("1: Empty cart");
      Console.WriteLine("2: Purchase");
      Console.WriteLine("3: Go Back");
      Console.Write("Select an option: ");
      try
      {
        CartMenu(int.Parse(Console.ReadLine()));
      }
      catch (Exception e)
      {
        Console.WriteLine($"Generic Exception Handler: {e}");
      }
    }
    /// <summary>
    /// Selects the option in the cart menu
    /// </summary>
    private void CartMenu(int option)
    {
      Log.Information("Method: Cart Menu");
      switch (option)
      {
        case 1:
          Console.WriteLine("Cart Cleared");
          cart.Clear();
          break;
        case 2:
          MakeOrder();
          break;
        case 3:
          break;
      }
    }
    /// <summary>
    /// Creates a new order
    /// </summary>
    private void MakeOrder()
    {
      Log.Information("Method: Make Order");
      if (customer == null)
      {
        Console.WriteLine("ERROR: No customer selected");
        return;
      }
      else if (store == null)
      {
        Console.WriteLine("ERROR: No store selected");
        return;
      }
      else if (cart.Count == 0)
      {
        Console.WriteLine("ERROR: Cart is empty");
        return;
      }
      else
      {
        _orderSingleton.Add(new Order() { Customer = customer, Store = store, Products = new List<Product>(cart), OrderDate = DateTime.Now });
        Console.WriteLine("Your order has been processed. Have a nice day!");
      }
      cart.Clear();
    }
    /// <summary>
    /// Output the list of orders based on the customer
    /// </summary>
    /// <typeparam name="Order"></typeparam>
    /// <param name="data"></param>
    private static void OutputOrder<Order>(List<Order> data, Customer customer)
    {
      Log.Information("Method: Output Order");
      if(data == null)
      {
        Console.WriteLine("There are no orders made.");
        return;
      }

      foreach (var item in data)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine("");
    }
  }
}
