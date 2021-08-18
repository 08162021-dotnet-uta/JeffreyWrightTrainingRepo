using System;

namespace Calculator
{
  class Program
  {
    //Build a simple calculator using 5 methods: Add, multiply, subtract, divide, and print. 
    static void Main(string[] args)
    {
      //input stuff
      var input1 = int.Parse(Console.ReadLine());
      var input2 = int.Parse(Console.ReadLine());

      //compute stuff
      int result1 = Add(input1, input2);
      int result2 = Subtract(input1, input2);

      //output stuff
      Print(result1, result2);
      /*//Global variable for first and second options
      int firstNumber;
      int secondNumber;
      int result;
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
        //Takes a numerical input for the menut
        int option = Convert.ToInt32(Console.ReadLine());
        //This block only runs if the options are 1-4.
        if (option >= 1 || option <= 4)
        {
          //Asks for first input
          Console.Write("First number? ");
          firstNumber = Convert.ToInt32(Console.ReadLine());
          //Asks for second input
          Console.Write("Second number? ");
          secondNumber = Convert.ToInt32(Console.ReadLine());
        }
        //Switch case goes through either one of these calculating functions or prints a line
        switch (option)
        {
          case 1:
            result = Add(firstNumber, secondNumber);
            break;
          case 2:
            result = Subtract(firstNumber, secondNumber);
            break;
          case 3:
            result = Multiply(firstNumber, secondNumber);
            break;
          case 4:
            result = Divide(firstNumber, secondNumber);
            break;
          case 5:
            Console.WriteLine("Goodbye!");
            break;
          //This runs if any other number is inputted.
          default:
            Console.WriteLine("Error: Invalid option");
            break;
        }
        //Exits the loop if the user exits
        if (option == 5)
          break;
        //Prints the result
        else if (option >= 1 && option <= 4)
          Print(Result);
      }*/
    }

    /*static int Add(var a, var b)
    {
      return a + b;
    }*/

    static int Add(int input1, int input2)
    {
      return (int)input1 + (int)input2;
    }

    /*static int Subtract(int a, int b)
    {
      return a - b;
    }*/

    static int Subtract(var input1, var input2)
    {
      return (int)input1 - (int)input2;
    }

    /*static int Multiply(int a, int b)
    {
      return a * b;
    }*/

    static int Multiply(var input1, var input2)
    {
      return (int)input1 * (int)input2;
    }

    /*static int Divide(int a, int b)
    {
      return a / b;
    }*/

    static int Divide(var input1, var input2)
    {
      return (int)input1 / (int)input2;
    }

    /*static void Print(int result)
    {
      Console.WriteLine(result);
    }*/

    static void Print(params int[] results)
    {
      Console.WriteLine(result1, result2);
    }
  }
}
