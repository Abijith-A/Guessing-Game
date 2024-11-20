using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a random number between 1 and 100
            Random random = new Random();
            int targetNumber = random.Next(1, 101);

            // Initialize variables
            int userNumber;
            List<Guess> guesses = new List<Guess>();
            bool isCorrect = false;

            Console.WriteLine("Welcome to the Guessing Game!");
            Console.WriteLine("Try to guess the number between 1 and 100.");

            do
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();

                // Validate input
                if (!int.TryParse(input, out userNumber) || userNumber < 1 || userNumber > 100)
                {
                    Console.WriteLine("Wrong input. Please enter a number between 1 and 100.");
                    continue;
                }

                // Check if the guess is repeated
                var previousGuess = guesses.FirstOrDefault(g => g.UserGuess == userNumber);
                if (previousGuess != null)
                {
                    int turnDifference = guesses.Count - guesses.IndexOf(previousGuess);
                    Console.WriteLine($"You guessed this number {turnDifference} turn(s) ago!");
                }

                // Add the guess to the list
                guesses.Add(new Guess(userNumber));

                // Check the guess
                if (userNumber < targetNumber)
                {
                    Console.WriteLine("guess higher ,Try again.");
                }
                else if (userNumber > targetNumber)
                {
                    Console.WriteLine("guess lower ,Try again.");
                }
                else
                {
                    isCorrect = true;
                    Console.WriteLine($"Congrats You have won the guessing game. The answer was {targetNumber}.");
                }
            } while (!isCorrect);

            // Display summary of guesses
            Console.WriteLine("\nGame Over! Here are your guesses:");
            foreach (var guess in guesses)
            {
                Console.WriteLine($"Guess: {guess.UserGuess}, Time: {guess.GuessTime}");
            }
        }
    }
}