using System;

namespace GuessingGame
{
    public class Guess
    {
        public int UserGuess { get; }
        public DateTime GuessTime { get; }

        public Guess(int userGuess)
        {
            UserGuess = userGuess;
            GuessTime = DateTime.Now;
        }
    }
}