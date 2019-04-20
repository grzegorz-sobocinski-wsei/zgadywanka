using GameLogic;
using System;
using static System.Console;

namespace ConsoleGame
{
    public class Game : BaseGame
    {
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Game()
        {
            Random = new Random();
            Notifications = new Notifications();
        }
        #endregion
        public override void AskUser()
        {
            CheckIfGuessIsNumber(ReadLine());

            base.AskUser();
        }

        public override void CheckIfGuessIsNumber(string answer)
        {
            base.CheckIfGuessIsNumber(answer);
        }

        public override void CheckNumber()
        {
            base.CheckNumber();
        }

        public override void EndGame()
        {
            Notifications.ScoreInformationText(User.NumberOfGames, User.NumberOfWins);
            ReadLine();
            base.EndGame();
        }

        public override void GameOver()
        {
            base.GameOver();
        }

        public override void GameWon()
        {
            Notifications.GameWonText(RandomNumber, User.NumberOfQuestions);
            base.GameWon();
        }

        public override void InitializeGame()
        {
            Notifications.WelcomeText();

            string userName = ReadLine();

            // User's name cannot be empty.
            if (!string.IsNullOrEmpty(userName))
                User = new User(ReadLine());
            else
            {
                Notifications.NameIsEmpty();
                InitializeGame();
            }

            base.InitializeGame();
        }

        public override void ResetGame()
        {
            base.ResetGame();
        }

        public override void StartGame()
        {
            base.StartGame();
        }

    }
}
