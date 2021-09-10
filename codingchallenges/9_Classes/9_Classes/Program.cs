using System;

namespace _9_ClassesChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Human h1 = new Human();
      Human h2 = new Human("Jeffrey", "Wright");
      Console.WriteLine(h1.AboutMe());
      Console.WriteLine(h2.AboutMe());
      Human2 h3 = new Human2("Jeffrey", "Wright", "brown");
      Human2 h4 = new Human2("Jeffrey", "Wright", 26);
      Human2 h5 = new Human2("Jeffrey", "Wright", "brown", 26);
      Console.WriteLine(h3.AboutMe2());
      Console.WriteLine(h4.AboutMe2());
      Console.WriteLine(h5.AboutMe2());
      Human2 h6 = new Human2("Giga", "Chad", "brown", 30);
      h6.Weight = 170;
      Console.WriteLine(h6.Weight);
      h6.Weight = 9001;
      Console.WriteLine(h6.Weight);
    }
  }
}
