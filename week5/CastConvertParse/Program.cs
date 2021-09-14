using System;

namespace CastConvertParse
{
  class Program
  {
    static void Main(string[] args)
    {
      float floating = 3.14159f;
      Console.WriteLine(floating);

      //implicit conversion
      double doubling = floating;
      Console.WriteLine(doubling);

      //explicit conversion
      //casting
      int integer = (int)floating;
      Console.WriteLine(integer);

      //converting
      string year = "2001";
      int yearAsInt = Convert.ToInt32(year);
      Console.WriteLine(yearAsInt);

      //parsing
      string animeTitle = "I've Been Killing Slimes for 300 Years and Maxed Out my Level!";
      try
      {
        int animeNumber = int.Parse(animeTitle);
        Console.WriteLine(animeNumber);
      }
      catch (System.Exception e)
      {
        throw new Exception(e.Message);
      }

      //parsing
      string cheese = "mozzarella";
      try
      {
        int cheeseNum = int.Parse(cheese);
        Console.WriteLine(cheeseNum);
      }
      catch (System.Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}
