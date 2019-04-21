using GameLogic;
using System;

namespace WPFGame
{
    public class GameViewModel : BaseGame
    {
        #region Public Properties
        public string UserAnswer { get; set; }
        public string Notification { get; set; } 
        public string ButtonText { get; set; }
        
        #endregion
        #region Commands
        public RelayCommand UserAnswerCommand { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameViewModel()
        {
            TypeOfGame = false;
            Random = new Random();
            Notifications = new Notifications();
            ButtonText = "Register";

            InitializeGame();
            UserAnswer = string.Empty;
            Notification = Notifications.Notification;

            // Initialize commands
            UserAnswerCommand = new RelayCommand(() => ButtonClicked());
            
        }
        #endregion
        public void ButtonClicked()
        {
            if (ButtonText == "Register")
            {
                ButtonText = "Submit answer";
                RegisterUser();
            }
            if (ButtonText == "Start new game")
            {
                Notification = Notifications.Notification;
                ButtonText = "Submit answer";
                base.InitializeGame();
            }
            if (ButtonText == "Submit answer" && UserAnswer != string.Empty)
            {
                AskUser();
            }
            Notification = Notifications.Notification;

        }
        public override void AskUser()
        {
            if (UserAnswer == string.Empty)
                return;

            base.AskUser();

            if (ButtonText == "Start new game")
            {
                UserAnswer = string.Empty;
                return;
            }

            CheckIfGuessIsNumber(UserAnswer);
        }

        public override void CheckIfGuessIsNumber(string answer)
        {
            base.CheckIfGuessIsNumber(answer);
            Notification = Notifications.Notification;
            UserAnswer = string.Empty;
        }

        public override void CheckNumber()
        {
            base.CheckNumber();
        }

        public override void EndGame()
        {
            Notifications.ScoreInformationText(User.NumberOfGames, User.NumberOfWins);
            base.EndGame();
        }

        public override void GameOver()
        {
            Notifications.GameOverText();
            ButtonText = "Start new game";
            Notification = Notifications.Notification;
        }

        public override void GameWon()
        {
            Notifications.GameWonText(RandomNumber, User.NumberOfQuestions);
            ButtonText = "Start new game";
            ResetGame();
        }

        public override void InitializeGame()
        {
            Notifications.WelcomeText();
        }
        public void RegisterUser()
        {
            // User's name cannot be empty.
            if (!string.IsNullOrEmpty(UserAnswer))
            {
                User = new User(UserAnswer);
                UserAnswer = string.Empty;
            }
            else
            {
                Notifications.NameIsEmpty();
                return;
            }

            base.InitializeGame();
        }

        public override void ResetGame()
        {
            base.ResetGame();
        }

        public override void StartGame()
        {
            if (UserAnswer == User.Name)
                return;
            if (ButtonText == "Start new game" || UserAnswer == string.Empty)
                base.StartGame();
        }
    }
}
