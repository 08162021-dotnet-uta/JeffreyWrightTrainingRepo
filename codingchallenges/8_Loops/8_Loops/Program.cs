using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      /* Your code here */
      List<string>[] strings = new List<string>[5];
      strings[0] = new List<string> { "Tony", "look", "at" };
      strings[1] = new List<string> { "me.", "We're", "going to" };
      strings[2] = new List<string> { "be", "okay...", "I'm" };
      strings[3] = new List<string> { "sorry.", "You", "can" };
      strings[4] = new List<string> { "rest", "now.", "\n" };
      Console.WriteLine(LoopdyLoop(strings));
    }

    /// <summary>
    /// Return the number of elements in the List<int> that are odd.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseFor(List<int> x)
    {
      int count = 0;
      for (int i = 0; i < x.Count; i++)
        if (x[i] % 2 == 1)
          count++;
      return count;
    }

    /// <summary>
    /// This method counts the even entries from the provided List<object> 
    /// and returns the total number found.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseForEach(List<object> x)
    {
      int count = 0;
      foreach (object o in x)
      {
        if (o is float)
        {
          float f = (float)o;
          if (f % 2 == 0)
            count++;
        }
        else if (o is long)
        {
          long l = (long)o;
          if (l % 2 == 0)
            count++;
        }
        else if (o is int)
        {
          int i = (int)o;
          if (i % 2 == 0)
            count++;
        }
        else if (o is double)
        {
          double d = (double)o;
          if (d % 2 == 0)
            count++;
        }
        else if (o is ulong)
        {
          ulong ul = (ulong)o;
          if (ul % 2 == 0)
            count++;
        }
      }
      return count;
    }

    /// <summary>
    /// This method counts the multiples of 4 from the provided List<int>. 
    /// Exit the loop when the integer 1234 is found.
    /// Return the total number of multiples of 4.
    /// </summary>
    /// <param name="x"></param>
    public static int UseWhile(List<int> x)
    {
      int i = 0;
      int count = 0;
      while (i < x.Count)
      {
        if (x[i] == 1234)
          break;
        if (x[i] % 4 == 0)
          count++;
        i++;
      }
      return count;
    }

    /// <summary>
    /// This method will evaluate the Int Array provided and return how many of its 
    /// values are multiples of 3 and 4.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int UseForThreeFour(int[] x)
    {
      int count = 0;
      for (int i = 0; i < x.Length; i++)
        if (x[i] % 3 == 0 && x[i] % 4 == 0)
          count++;
      return count;
    }

    /// <summary>
    /// This method takes an array of List<string>'s. 
    /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
    /// </summary>
    /// <param name="stringListArray"></param>
    /// <returns></returns>
    public static string LoopdyLoop(List<string>[] stringListArray)
    {
      string concatString = "";
      foreach (List<string> stringArray in stringListArray)
        foreach (string member in stringArray)
          concatString = string.Concat(concatString, member, " ");
      return concatString;
    }
  }
}