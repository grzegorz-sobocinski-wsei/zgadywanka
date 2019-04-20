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
            random = new Random();
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
            Notifications.GameWonText(randomNumber, User.NumberOfQuestions);
            base.GameWon();
        }

        public override void InitializeGame()
        {
            Notifications.WelcomeText();

            User = new User(ReadLine());

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
