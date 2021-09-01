using System;

namespace _4_MethodsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
        //1
        string name = GetName();
        Console.WriteLine(GreetFriend(name));

        //2
        double result1 = GetNumber();
        double result2 = GetNumber();
        int action1 = GetAction();
        double result3 = DoAction(result1, result2, action1);

        System.Console.WriteLine($"The result of your mathematical operation is {result3}.");
    }

    public static string GetName()
    {
        Console.Write("What's your name? ");
        return Console.ReadLine();
    }

    public static string GreetFriend(string name)
    {
        return "Hello " + name + ". You are my friend.";
    }

    public static double GetNumber()
    {
      string input;
      Console.Write("Type in a number: ");
      while (true)
      {
        input = Console.ReadLine();
        if (CheckForOnlyDigits(input))
          break;
        Console.Write("This is not a number! Please type in a number: ");
      }
      return Convert.ToDouble(input);
    }

    public static bool CheckForOnlyDigits(string test)
    {
      int dot = 0;
      foreach (char c in test)
      {
        if (c < '0' || c > '9')
        {
          if (c == '.')
            dot++;
          else
            return false;
        }
        if (dot > 1)
          return false;
      }
      return true;
    }

    public static int GetAction()
    {
      int action;
      Console.WriteLine("1: Add");
      Console.WriteLine("2: Subtract");
      Console.WriteLine("3: Multiply");
      Console.WriteLine("4: Divide");
      Console.Write("Select an Action: ");
      while (true)
      {
        action = Convert.ToInt32(Console.ReadLine());
        if (action >= 1 && action <= 4)
          break;
        Console.Write("This is not valid! Please select an action: ");
      }
      return action;
    }

    public static double DoAction(double x, double y, int action)
    {
      return action switch
      {
        1 => x + y,
        2 => x - y,
        3 => x * y,
        4 => x / y,
        _ => 0,
      };
    }
  }
}
