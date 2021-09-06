using System;
using System.Collections.Generic;
using p0.StoreApplication.Client.Singletons;
using Serilog;
using dm = p0.StoreApplication.Storage.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
    protected dm.Customer customer;
    protected dm.Store store;
    private static readonly List<dm.Product> cart = new();
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
      Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
      var p = new Program();
      Console.WriteLine("Welcome to my storefront!");
      p.DisplayMenu();
      /*using (var context = new dm.StoreApplicationDBContext())
      {
        /*dm.Customer r = new dm.Customer();
        r.Name = "Robert Smith";
        context.Customers.Add(r);
        context.SaveChanges();
        var customerList = context.Customers.FromSqlRaw<dm.Customer>("SELECT * FROM Customer.Customer").ToList();
        foreach (var customer in customerList)
        {
          Console.WriteLine(customer.Name);
        }
      }*/
    }
    /// <summary>
    /// Displays the Menu
    /// </summary>
    private void DisplayMenu()
    {
      Log.Information("Method: Display Menu");
      Console.WriteLine("1: Login as customer");
      Console.WriteLine("2: Login as store");
      Console.WriteLine("Any other key: Log Out");
      Console.Write("Select an option: ");
      string value = Console.ReadLine();
      if(value.Equals("1") || value.Equals("2"))
      {
        Menu(int.Parse(value));
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
          Output<dm.Customer>(_customerSingleton.Customers);
          SelectCustomer(out customer);
          Console.WriteLine($"You have selected {customer}");
          DisplayMenuCust();
          break;
        case 2:
          Output<dm.Store>(_storeSingleton.Stores);
          SelectStore(out store);
          DisplayMenuStore();
          break;
        case 3:
          Output<dm.Product>(_productSingleton.Products);
          cart.Add(SelectProduct());
          break;
        case 4:
          ViewCart();
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
    private void SelectCustomer(out dm.Customer customer)
    {
      Log.Information("Method: Select Customer");

      //Access the customers from the customer repository
      var customers = (_customerSingleton.Customers);

      //Prompt to select a customer
      Console.Write("Select a Customer: ");

      //Prompt for user input to get a customer
      dm.Customer cust = customers[int.Parse(Console.ReadLine()) - 1];

      //Return the customer of the customer input
      customer = cust;
    }
    /// <summary>
    /// Selects a store
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    private void SelectStore(out dm.Store store)
    {
      Log.Information("Method: Select Store");

      //Access the stores from the store repository
      var stores = (_storeSingleton.Stores);

      //Prompt to select a store
      Console.Write("Select a Store: ");

      //Prompt for user input to get a store
      dm.Store st = stores[int.Parse(Console.ReadLine()) - 1];

      //Displays the customer selected
      Console.WriteLine(st);

      //Return the customer of the customer input
      store = st;
    }
    /// <summary>
    /// Displays the menu for the customer
    /// </summary>
    private void DisplayMenuCust()
    {
      Log.Information("Method: Display Customer Menu");
      Console.WriteLine("1: Select store");
      Console.WriteLine("2: View orders");
      Console.WriteLine("3: Log out");
      Console.Write("Select an option: ");
      string value = Console.ReadLine();
      if (value.Equals("1") || value.Equals("2") || value.Equals("3"))
      {
        MenuCust(int.Parse(value));
      }
    }
    private void MenuCust(int option)
    {
      switch (option)
      {
        case 1:
          Output<dm.Store>(_storeSingleton.Stores);
          SelectStore(out store);
          DisplayShopping();
          break;
        case 2:
          OutputOrder<dm.StoreOrder>(customer);
          DisplayMenuStore();
          break;
        case 3:
          customer = null;
          break;
      }
    }
    private void DisplayMenuStore()
    {
      Log.Information("Method: Display Customer Menu");
      Console.WriteLine("1: View orders");
      Console.WriteLine("2: Log out");
      Console.Write("Select an option: ");
      string value = Console.ReadLine();
      if (value.Equals("1") || value.Equals("2"))
      {
        MenuStore(int.Parse(value));
      }
    }
    private void MenuStore(int option)
    {
      switch (option)
      {
        case 1:
          OutputOrder<dm.StoreOrder>(store);
          DisplayMenuStore();
          break;
        case 2:
          store = null;
          break;
      }
    }
    private void DisplayShopping()
    {
      Log.Information("Method: Display Customer Menu");
      Console.WriteLine("1: Add products to cart");
      Console.WriteLine("2: View cart");
      Console.WriteLine("3: Leave store and empty cart");
      Console.Write("Select an option: ");
      string value = Console.ReadLine();
      if (value.Equals("1") || value.Equals("2") || value.Equals("3"))
      {
        MenuShopping(int.Parse(value));
      }
    }
    private void MenuShopping(int option)
    {
      switch(option)
      {
        case 1:
          Output<dm.Product>(_productSingleton.Products);
          cart.Add(SelectProduct());
          break;
      }
    }
    /// <summary>
    /// Selects a product and adds it to the cart
    /// </summary>
    /// <returns></returns>
    private dm.Product SelectProduct()
    {
      Log.Information("Method: Select Product");

      //Access the products from the product repository
      var products = (_productSingleton.Products);

      //Prompt to select a product
      Console.Write("Select a Product: ");

      //Return the product of the user input
      dm.Product product = products[int.Parse(Console.ReadLine()) - 1];

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
      DisplayCartMenu(subtotal);
    }
    /// <summary>
    /// Displays the cart menu
    /// </summary>
    private void DisplayCartMenu(decimal subtotal)
    {
      Log.Information("Method: Display Cart Menu");
      Console.WriteLine("1: Empty cart");
      Console.WriteLine("2: Purchase");
      Console.WriteLine("3: Go Back");
      Console.Write("Select an option: ");
      try
      {
        CartMenu(int.Parse(Console.ReadLine()), subtotal);
      }
      catch (Exception e)
      {
        Console.WriteLine($"Generic Exception Handler: {e}");
      }
    }
    /// <summary>
    /// Selects the option in the cart menu
    /// </summary>
    private void CartMenu(int option, decimal subtotal)
    {
      Log.Information("Method: Cart Menu");
      switch (option)
      {
        case 1:
          Console.WriteLine("Cart Cleared");
          cart.Clear();
          break;
        case 2:
          MakeOrder(subtotal);
          break;
        case 3:
          break;
      }
    }
    /// <summary>
    /// Creates a new order
    /// </summary>
    private void MakeOrder(decimal subtotal)
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
      else if (subtotal > 500)
      {
        Console.WriteLine("Sorry, this order is invalid. Orders are limited to a total of $500.");
        return;
      }
      else
      {
        //will ned to change a lot og things here
        //_orderSingleton.Add(new dm.Order() { Customer = customer, Store = store, Products = new List<dm.Product>(cart), OrderDate = DateTime.Now });
        Console.WriteLine("Your order has been processed. Have a nice day!");
      }
      cart.Clear();
    }
    /// <summary>
    /// Output the list of orders based on the customer
    /// </summary>
    /// <typeparam name="Order"></typeparam>
    /// <param name="data"></param>
    private static void OutputOrder<Order>(dm.Customer customer)
    {
      Log.Information("Method: Output Order (Customer)");
      var data = _orderSingleton.QueryOrders(customer);
      if (data == null)
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

    /// <summary>
    /// Output the list of orders based on the store
    /// </summary>
    /// <typeparam name="StoreOrder"></typeparam>
    /// <param name="store"></param>
    private static void OutputOrder<StoreOrder>(dm.Store store)
    {
      Log.Information("Method: Output Order (Store)");
      var data = _orderSingleton.QueryOrders(store);
      if (data.Count == 0)
      {
        Console.WriteLine($"There are no orders made at {store}.");
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
