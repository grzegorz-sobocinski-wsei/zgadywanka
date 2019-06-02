using GameLogic;
using GameLogic.Model;
using GameLogic.Resources;
using System;
using static System.Console;

namespace ConsoleGame
{
    public class ConsoleGame : BaseGame, IGame
    {
        #region Public Methods

        /// <summary>
        /// Ask the user for his answer.
        /// </summary>
        public void AskUser()
        {
            if (User.NumberOfQuestions < QuestionsLimit)
            {
                CheckAnswer(ReadLine());
                AskUser();
            }
            else
                GameOver();
        }

        /// <summary>
        /// Check if the user got the number right.
        /// </summary>
        public void CheckNumber()
        {
            User.NumberOfQuestions++;

            if (RandomNumber < UserAnswer)
            {
                WriteLine(Texts.NumberTooBig);
            }

            if (RandomNumber > UserAnswer)
            {
                WriteLine(Texts.NumberTooSmall);
            }

            if (RandomNumber == UserAnswer)
            {
                GameWon();
            }
        }

        /// <summary>
        /// Display the user's final score and close the application.
        /// </summary>
        public void EndGame()
        {
            WriteLine(EndGameText());
            ReadKey();
            Environment.Exit(0);
        }

        /// <summary>
        /// User lost after 7 tries.
        /// Display the correct answer.
        /// </summary>
        public void GameOver()
        {
            WriteLine(GameOverText());
            ReadKey();
            ResetGame();
        }

        /// <summary>
        /// User got the number right and won the game.
        /// </summary>
        public void GameWon()
        {
            User.NumberOfWins++;
            WriteLine(GameWonText());
            ReadLine();
            ResetGame();
        }

        /// <summary>
        /// Check if the input was an number.
        /// </summary>
        /// <param name="userAnswer">User's input.</param>
        public void CheckAnswer(string answer)
        {
            if (answer == "END" && answer == "end")
            {
                EndGame();
            }

            // Check if user answer is a number within 0-100
            int.TryParse(answer, out int number);
            if (number >= MinimalGuess && number <= MaximalGuess && !string.IsNullOrEmpty(answer))
            {
                UserAnswer = number;
                CheckNumber();
                return;
            }

            WriteLine(Texts.InputIsNotNumber);
        }

        /// <summary>
        /// Reset the game to default values.
        /// </summary>
        public void ResetGame()
        {
            RandomNumber = Random.Next(MinimalGuess, MaximalGuess);
            User.NumberOfQuestions = 0;
            User.NumberOfGames++;
            StartGame();
        }

        /// <summary>
        /// Begins the game with first question.
        /// </summary>
        public void StartGame()
        {
            WriteLine(Texts.FirstQuestion);
            AskUser();
        }

        /// <summary>
        /// Creates new user based on user's input and starts the game.
        /// </summary>
        public void InitializeGame()
        {
            WriteLine(Texts.Welcome);
            RandomNumber = Random.Next(MinimalGuess, MaximalGuess);
            string input = ReadLine();

            // User's name cannot be empty.
            if (!string.IsNullOrEmpty(input))
            {
                User = new User(input);
            }
            else
            {
                WriteLine(Texts.NameIsEmpty);
                InitializeGame();
            }

            StartGame();
        }

        #endregion Public Methods
    }
}