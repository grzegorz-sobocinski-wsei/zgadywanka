using System;
using static System.Console;

namespace GraMonolitycznie
{
    public class GameLogic
    {
        #region Private Fields
        private User User;
        private int randomNumber;
        private Random random;
        private int userGuess;
        private const int QuestionsLimit = 7;
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameLogic()
        {
            random = new Random();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Asks for user name, ran at the beginning of the game. Exposed as public to increase code readability.
        /// </summary>
        public void InitializeGame()
        {
            WriteLine("Welcome! \nIf you want to quit and see your score " +
                "then type in \"END\"." + "\nWhat's your name?");

            // Create new player
            User = new User(ReadLine());

            StartGame();
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Begins new round.
        /// </summary>
        private void StartGame()
        {
            ResetGame();
            WriteLine("I'm thinking of a number between 1-100, what number is it?");
            AskUser();
        }
        /// <summary>
        /// Questions the user. 
        /// </summary>
        private void AskUser()
        {
            CheckIfGuessIsNumber(ReadLine());

            if (User.NumberOfQuestions < QuestionsLimit)
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

            if (userAnswer == "END")
            {
                EndGame();
                return;
            }

            if (int.TryParse(userAnswer, out userGuess))
            {
                CheckNumber();
                return;
            }

            WriteLine("That wasn't a number!");
        }
        /// <summary>
        /// Checks how close to the answer user's answer was.
        /// </summary>
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
        /// <summary>
        /// User won the game. Starts new game. 
        /// </summary>
        private void GameWon()
        {
            WriteLine(string.Format("That's correct! I was thinking of a {0}. You got it by {1} try. Let's begin a new game!\n", randomNumber, User.NumberOfQuestions));
            User.NumberOfWins++;
            StartGame();
        }
        /// <summary>
        /// Resets the game because user had no more quetsions left 
        /// </summary>
        private void GameOver()
        {
            WriteLine("Sorry, you have no more questions left. Let's begin a new game!");
            StartGame();
        }
        /// <summary>
        /// Resets the game values to defaults.
        /// </summary>
        private void ResetGame()
        {
            randomNumber = random.Next(0, 100);
            User.NumberOfQuestions = 0;
            User.NumberOfGames++;
        }
        /// <summary>
        /// Informs the user about his score and closes the application.
        /// </summary>
        private void EndGame()
        {
            WriteLine(string.Format("You played {0} games and won {1}", User.NumberOfGames, User.NumberOfWins));
            ReadLine();
            // Close console window.
            Environment.Exit(0);
        }
        #endregion
    }
}
