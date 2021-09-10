using System;
using System.Collections.Generic;

namespace _7_GuessingGameChallenge
{
  public class Program
  {
    public static void Main(string[] args)
    {
      bool playAgain = true;
      do
      {
        int numToGuess = GetRandomNumber();
        Console.Write("I am thinking of a number between 1 and 100. ");
        int guesses = 0;
        int match = 0;
        List<int> userGuesses = new List<int>();
        do
        {
          Console.Write("Make your guess! ");
          int userGuess = GetUsersGuess();
          userGuesses.Add(userGuess);
          guesses++;
          match = CompareNums(numToGuess, userGuess);
          if (match == -1)
            Console.WriteLine("Lower!");
          else if (match == 1)
            Console.WriteLine("Higher!");
          Console.WriteLine(string.Join(", ", userGuesses));
        } while (match != 0 && guesses < 10);
        if (match == 0)
          Console.WriteLine($"You got it! The number was {numToGuess}!");
        else
          Console.WriteLine($"Buddy, I'm so sorry. The number was {numToGuess}.");
        Console.Write("Would you like to play again? (yes/no) ");
        playAgain = PlayGameAgain();
      } while (playAgain);
    }

    /// <summary>
    /// This method returns a randomly chosen number between 1 and 100, inclusive.
    /// </summary>
    /// <returns></returns>
    public static int GetRandomNumber()
    {
      Random rand = new Random();
      return rand.Next(100) + 1;
    }

    /// <summary>
    /// This method gets input from the user, 
    /// verifies that the input is valid and 
    /// returns an int.
    /// </summary>
    /// <returns></returns>
    public static int GetUsersGuess()
    {
      int result;
      int.TryParse(Console.ReadLine(), out result);
      return result;
    }

    /// <summary>
    /// This method will has two int parameters.
    /// It will:
    /// 1) compare the first number to the second number
    /// 2) return -1 if the first number is less than the second number
    /// 3) return 0 if the numbers are equal
    /// 4) return 1 if the first number is greater than the second number
    /// </summary>
    /// <param name="randomNum"></param>
    /// <param name="guess"></param>
    /// <returns></returns>
    public static int CompareNums(int randomNum, int guess)
    {
      if (randomNum < guess)
        return -1;
      else if (randomNum > guess)
        return 1;
      return 0;
    }

    public static bool PlayGameAgain()
    {
      string response = Console.ReadLine();
      if (response.ToLower().Equals("yes") || response.ToLower().Equals("y"))
        return true;
      return false;
    }
  }
}
