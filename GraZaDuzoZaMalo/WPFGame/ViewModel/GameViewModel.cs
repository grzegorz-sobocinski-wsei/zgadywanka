using GameLogic;
using System;

namespace WPFGame
{
    public class GameViewModel : BaseGame
    {
        #region Public Properties
        public string UserAnswer { get; set; } = string.Empty;
        public string Notification { get; set; }
        public string ButtonText { get; set; } = ButtonTexts.Register;
        
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
            // Flag. False, because it's WPF project.
            TypeOfGame = false;

            // Initialization 
            Random = new Random();
            Notifications = new Notifications();
            UserAnswerCommand = new RelayCommand(() => ButtonClicked());

            InitializeGame();
            Notification = Notifications.Notification;            
        }
        #endregion
        public void ButtonClicked()
        {
            if (ButtonText == ButtonTexts.Register)
            {
                ButtonText = ButtonTexts.Submit;
                RegisterUser();
            }
            if (ButtonText == ButtonTexts.Start)
            {
                Notification = Notifications.Notification;
                ButtonText = ButtonTexts.Submit;
                base.InitializeGame();
            }
            if (ButtonText == ButtonTexts.Submit && UserAnswer != string.Empty)
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

            if (ButtonText == ButtonTexts.Start)
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
            Notifications.GameOverText(RandomNumber);
            ButtonText = ButtonTexts.Start;
            Notification = Notifications.Notification;
        }

        public override void GameWon()
        {
            Notifications.GameWonText(RandomNumber, User.NumberOfQuestions);
            ButtonText = ButtonTexts.Start;
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
            if (ButtonText == ButtonTexts.Start || UserAnswer == string.Empty)
                base.StartGame();
        }
    }
}
