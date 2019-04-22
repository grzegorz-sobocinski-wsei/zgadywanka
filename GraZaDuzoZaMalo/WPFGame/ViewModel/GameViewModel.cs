using GameLogic;
using System;

namespace WPFGame
{
    public class GameViewModel : BaseGame
    {
        #region Public Properties
        /// <summary>
        /// User input inside of a textbox. Empty by default.
        /// </summary>
        public string UserAnswer { get; set; } = string.Empty;
        /// <summary>
        /// Text seen by the user.
        /// </summary>
        public string Notification { get; set; }
        /// <summary>
        /// Text displayed on the button. Default is register. 
        /// </summary>
        public string ButtonText { get; set; } = ButtonTexts.Register;
        public string ScoreInformation { get; set; } 
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
        /// <summary>
        /// Method invoked after button was clicked. The outcome of the method depends of the button text.
        /// </summary>
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
            // If user answer is empty then return and wait for ButtonClicked method.
            if (UserAnswer == string.Empty)
                return;

            base.AskUser();

            // When the user got 7 questions wrong then return.
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

            // Assign string values
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
            // Assign string values.
            Notifications.GameOverText(RandomNumber);
            ButtonText = ButtonTexts.Start;
            Notification = Notifications.Notification;
        }

        public override void GameWon()
        {
            // Assign string values.
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
            // Inform the user about his score. 
            ScoreInformation = string.Format("{0}, you have played {1} games and won {2} of them.", User.Name, User.NumberOfGames, User.NumberOfWins);
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
