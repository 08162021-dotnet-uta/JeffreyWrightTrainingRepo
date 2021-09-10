using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
  internal class Human2 : Human
  {
    private string firstName;
    private string lastName;
    private string eyeColor;
    private int age = -1;
    private int weight;
    public int Weight
    {
      get
      {
        return weight;
      }
      set
      {
        if (value < 0 || value > 400)
          weight = 0;
        else
          weight = value;
      }
    }
    public Human2()
    {
      firstName = "Pat";
      lastName = "Smyth";
    }
    public Human2(string fn, string ln, string eColor, int a)
    {
      firstName = fn;
      lastName = ln;
      eyeColor = eColor;
      age = a;
    }

    public Human2(string fn, string ln, string eColor)
    {
      firstName = fn;
      lastName = ln;
      eyeColor = eColor;
    }

    public Human2(string fn, string ln, int a)
    {
      firstName = fn;
      lastName = ln;
      age = a;
    }
    public string AboutMe2()
    {
      string result = $"My name is {firstName} {lastName}.";
      if (age >= 0)
        result = string.Concat(result, $" My age is {age}.");
      if (eyeColor != null)
        result = string.Concat(result, $" My eye color is {eyeColor}.");
      return result;
    }
  }
}