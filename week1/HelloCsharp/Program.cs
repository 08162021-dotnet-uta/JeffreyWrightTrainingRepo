using System;

namespace HelloCsharp
{
  class Program
  {
    //Build a simple calculator using 5 methods: Add, multiply, subtract, divide, and print. 
    static void Main(string[] args)
    {
      //Global variable for first and second options
      int firstNumber;
      int secondNumber;
      //While true loop loops forever unless 5 is an option
      while (true)
      {
        //Menu
        Console.WriteLine("Select a function!");
        Console.WriteLine("1: Add");
        Console.WriteLine("2: Subtract");
        Console.WriteLine("3: Multiply");
        Console.WriteLine("4: Divide");
        //Adds a blank line below the menu
        Console.WriteLine("5: Exit\n");
        //Takes a numerical input
        int option = Convert.ToInt32(Console.ReadLine());
        //Asks for first and second number
        Console.Write("First number? ");
        firstNumber = Convert.ToInt32(Console.ReadLine());
        Console.Write("Second number? ");
        secondNumber = Convert.ToInt32(Console.ReadLine());
        //Switch case goes through either one of these functions
        switch (option)
        {
          case 1:
            Print(Add(firstNumber, secondNumber));
            break;
          case 2:
            Print(Subtract(firstNumber, secondNumber));
            break;
          case 3:
            Print(Multiply(firstNumber, secondNumber));
            break;
          case 4:
            Print(Divide(firstNumber, secondNumber));
            break;
          case 5:
            Console.WriteLine("Goodbye!");
            break;
          default:
            Console.WriteLine("Invalid option");
            break;
        }
        if (option == 5)
          break;
      }
    }

    static int Add(int a, int b)
    {
      return a + b;
    }

    static int Subtract(int a, int b)
    {
      return a - b;
    }

    static int Multiply(int a, int b)
    {
      return a * b;
    }

    static int Divide(int a, int b)
    {
      return a / b;
    }

    static void Print(int result)
    {
      Console.WriteLine(result);
    }
  }
}
