using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_ArraysAndListsChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {

    }//EoM

    /// <summary>
    /// This method takes an array of integers and returns a double, the average 
    /// value of all the integers in the array
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static double AverageOfValues(int[] array)
    {
      double average = 0.0;
      for (int i = 0; i < array.Length; i++)
      {
        average += array[i];
      }
      return average / array.Length;
    }

    /// <summary>
    /// This method increases each array element by 2 and 
    /// returns an array with the altered values.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static int[] SunIsShining(int[] x)
    {
      int[] newArray = new int[x.Length];
      for (int i = 0; i < x.Length; i++)
        newArray[i] = x[i] + 2;
      return newArray;
    }

    /// <summary>
    /// This method takes an ArrayList containing types of double, int, and string 
    /// and returns the average of the ints and doubles only, as a decimal.
    /// It ignores the string values and rounds the result to 3 decimal places toward the nearest even number.
    /// </summary>
    /// <param name="myArrayList"></param>
    /// <returns></returns>
    public static decimal ArrayListAvg(ArrayList myArrayList)
    {
      double total = 0.0;
      int countNumbers = 0;
      foreach (var element in myArrayList)
      {
        if (element is string)
          continue;
        total += Convert.ToDouble(element);
        countNumbers++;
      }
      double avg = total / countNumbers;
      return (decimal)Math.Round(avg, 3);
    }

    /// <summary>
    /// This method returns the rank (starting with 1st place) of a new 
    /// score entered into a list of randomly ordered scores.
    /// </summary>
    /// <param name="myArray1"></param>
    public static int ListAscendingOrder(List<int> scores, int yourScore)
    {
      scores.Add(yourScore);
      scores.Sort();
      int rank = 0;
      while (rank < scores.Count)
      {
        rank++;
        if (yourScore < scores[rank])
          break;
      }
      return rank;
    }

    /// <summary>
    /// This method has with two parameters takes a List<string> and a string.
    /// The method returns true if the string parameter is found in the List, otherwise false.
    /// </summary>
    /// <param name="myArray2"></param>
    /// <param name="word"></param>
    /// <returns></returns>
    public static bool FindStringInList(List<string> myArray2, string word)
    {
      foreach (string w in myArray2)
        if (w.Equals(word))
          return true;
      return false;
    }
  }//EoP
}// EoN