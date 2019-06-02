using GameLogic;
using GameLogic.Model;
using GameLogic.Resources;
using System;
using System.ComponentModel;
using WPFGame.Resources;

namespace WPFGame
{
    public class GameViewModel : BaseGame, IGame, INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// User input inside of a textbox. Empty by default.
        /// </summary>
        public string UserInput { get; set; }

        /// <summary>
        /// Text seen by the user.
        /// </summary>
        public string Notification { get; set; }

        /// <summary>
        /// Text displayed on the button. Default is register.
        /// </summary>
        public string ButtonText { get; set; } = ButtonTexts.Register;

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// Invoked after user's click.
        /// </summary>
        public RelayCommand UserAnswerCommand { get; set; }

        #endregion Commands

        #region Constructor

        public GameViewModel()
        {
            UserAnswerCommand = new RelayCommand(() => ButtonClicked());

            Notification = Texts.Welcome;
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Method invoked after button was clicked. The outcome of the method depends of the button text.
        /// </summary>
        public void ButtonClicked()
        {
            if (ButtonText == ButtonTexts.Register)
            {
                ButtonText = ButtonTexts.Submit;
                InitializeGame();
                return;
            }
            if (ButtonText == ButtonTexts.Start)
            {
                ButtonText = ButtonTexts.Submit;
                StartGame();
            }
            if (ButtonText == ButtonTexts.Submit && UserInput != string.Empty)
            {
                AskUser();
            }
        }

        /// <summary>
        /// Ask the user for his answer.
        /// </summary>
        public void AskUser()
        {
            // If user answer is empty then return and wait for ButtonClicked method.
            if (string.IsNullOrEmpty(UserInput))
                return;

            if (User.NumberOfQuestions < QuestionsLimit)
                CheckAnswer(UserInput);
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
                Notification = Texts.NumberTooBig;
            }

            if (RandomNumber > UserAnswer)
            {
                Notification = Texts.NumberTooSmall;
            }

            if (RandomNumber == UserAnswer)
            {
                GameWon();
            }

            UserInput = string.Empty;
        }

        /// <summary>
        /// Display the user's final score and close the application.
        /// </summary>
        public void EndGame()
        {
            Notification = EndGameText();
            Environment.Exit(0);
        }

        /// <summary>
        /// User lost after 7 tries.
        /// Display the correct answer.
        /// </summary>
        public void GameOver()
        {
            // Assign string values.
            Notification = GameOverText();
            ResetGame();
        }

        /// <summary>
        /// User got the number right and won the game.
        /// </summary>
        public void GameWon()
        {
            // Assign string values.
            Notification = GameWonText();
            ButtonText = ButtonTexts.Start;
            ResetGame();
        }

        /// <summary>
        /// Reset the game to default values.
        /// </summary>
        public void ResetGame()
        {
            // Reset the values to default.
            RandomNumber = Random.Next(MinimalGuess, MaximalGuess);
            UserInput = string.Empty;
            User.NumberOfQuestions = 0;
            User.NumberOfGames++;
            ButtonText = ButtonTexts.Start;
        }

        /// <summary>
        /// Begins the game with first question.
        /// </summary>
        public void StartGame()
        {
            RandomNumber = Random.Next(MinimalGuess, MaximalGuess);

            if (ButtonText == ButtonTexts.Start || UserInput == string.Empty)
            {
                Notification = Texts.FirstQuestion;
                AskUser();
            }
        }

        /// <summary>
        /// Creates new user based on user's input and starts the game.
        /// </summary>
        public void InitializeGame()
        {
            // User's name cannot be empty.
            if (!string.IsNullOrEmpty(UserInput))
            {
                User = new User(UserInput);
                UserInput = string.Empty;
            }
            else
            {
                Notification = Texts.NameIsEmpty;
                return;
            }

            StartGame();
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

            Notification = Texts.InputIsNotNumber;
        }

        #endregion Public Methods

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Property Changed
    }
}