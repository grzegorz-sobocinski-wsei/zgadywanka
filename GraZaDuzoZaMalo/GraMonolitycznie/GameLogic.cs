using System;
using static System.Console;

namespace GraMonolitycznie
{
    public class GameLogic
    {
        public User User;
        private int randomNumber;
        private Random random;
        private int userGuess;
        private const int questionsLimit = 7;

        public GameLogic()
        {
            random = new Random();
            InitializeGame();
        }
        /// <summary>
        /// Asks for user name, ran at the beginning of the game
        /// </summary>
        private void InitializeGame()
        {
            WriteLine("Welcome! What's your name?");

            // Create new player
            User = new User(ReadLine());

            StartGame();
        }
        /// <summary>
        /// Begins new round 
        /// </summary>
        private void StartGame()
        {
            ResetGame();
            WriteLine("I'm thinking of a number between 1-100, what number is it?");
            AskUser();
        }
        private void AskUser()
        {
            CheckIfGuessIsNumber(ReadLine());

            if (User.NumberOfQuestions < questionsLimit)
                AskUser();
            else
                GameOver();
        }
        /// <summary>
        /// Checks if the user typed in a number
        /// </summary>
        /// <param name="userAnswer">User's input</param>
        /// <returns></returns>
        private void CheckIfGuessIsNumber(string userAnswer)
        {
            // Guard clause
            if (userAnswer == null)
                throw new Exception("userAnswer");

            if (int.TryParse(userAnswer, out userGuess))
            {
                CheckNumber();
                return;
            }

            WriteLine("That wasn't a number!");
        }
        private void CheckNumber()
        {
            User.NumberOfQuestions++;
            
            if (randomNumber < userGuess)
                WriteLine("That's too much!");
            if (randomNumber > userGuess)
                WriteLine("That's not enough!");
            if (randomNumber == userGuess)
                GameWon();
        }
        private void GameWon()
        {
            WriteLine(string.Format("That's correct! I was thinking of a {0}. You got it by {1} try. Let's begin a new game!\n", randomNumber, User.NumberOfQuestions));
            User.NumberOfWins++;
            StartGame();
        }
        /// <summary>
        /// User have no more questions left
        /// </summary>
        private void GameOver()
        {
            WriteLine("Sorry, you have no more questions left. Let's begin a new game!");
            StartGame();
        }
        /// <summary>
        /// Resets the game values to defaults
        /// </summary>
        private void ResetGame()
        {
            randomNumber = random.Next(0, 100);
            User.NumberOfQuestions = 0;
            User.NumberOfGames++;
        }
    }
}
