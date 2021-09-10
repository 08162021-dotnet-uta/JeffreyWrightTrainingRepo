using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
  internal class Human
  {
    private string firstName;
    private string lastName;
    internal Human()
    {
      firstName = "Pat";
      lastName = "Smyth";
    }
    internal Human(string fn, string ln)
    {
      firstName = fn;
      lastName = ln;
    }
    public string AboutMe()
    {
      return $"My name is {firstName} {lastName}.";
    }
  }//end of class
}//end of namespace