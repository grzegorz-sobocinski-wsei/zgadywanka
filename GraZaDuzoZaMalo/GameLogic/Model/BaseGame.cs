using System;
using System.ComponentModel;

namespace GameLogic
{
    /// <summary>
    /// Base logic of the game. Implements INotifyPropertyChanged for WPF and Xamarin project. 
    /// </summary>
    public abstract class BaseGame : INotifyPropertyChanged
    {
        #region Constant Values
        private const int MaximalGuess = 100;
        private const int MinimalGuess = 0;
        private const int QuestionsLimit = 7;
        #endregion
        #region Private Fields
        private int userGuess;
        #endregion
        #region Public Properties
        public User User { get; set; }
        public Random Random { get; set; }
        public int RandomNumber { get; set; }
        /// <summary>
        /// True if console, false if WPF
        /// </summary>
        public bool TypeOfGame { get; set; }
        /// <summary>
        /// Contains platform specific notifications for the user.
        /// </summary>
        public INotifications Notifications { get;set; }

        #endregion
        #region Virtual Methods
        /// <summary>
        /// Ask the user about his name. 
        /// </summary>
        public virtual void InitializeGame()
        {
            StartGame();
        }
        /// <summary>
        /// Begins the game with the first question.
        /// </summary>
        public virtual void StartGame()
        {
            ResetGame();
            Notifications.FirstQuestionText();
            AskUser();
        }
        /// <summary>
        /// Ask user of his answer and check if he was right or wrong.
        /// </summary>
        public virtual void AskUser()
        {
            // True if console game
            // False if WPF game
            if(TypeOfGame)
            {
                if (User.NumberOfQuestions < QuestionsLimit)
                    AskUser();
                else
                    GameOver();
            }
            else
            {
                if (User.NumberOfQuestions < QuestionsLimit)
                    return;
                else
                    GameOver();
            }
        }
        /// <summary>
        /// Check if the input was an number.
        /// </summary>
        /// <param name="userAnswer"></param>
        public virtual void CheckIfGuessIsNumber(string answer)
        {
            // Guard clause
            if (answer == null)
                throw new ArgumentNullException("answer");

            if (answer == "END")
            {
                EndGame();
                return;
            }
            
            // Check if user answer is a number within 0-100
            int.TryParse(answer, out int number);

            if (number >= MinimalGuess && number <= MaximalGuess && !string.IsNullOrEmpty(answer))
            {
                userGuess = number;
                CheckNumber();
                return;
            }

            Notifications.InputWasntNumberText();
        }
        /// <summary>
        /// Check if the user got the number right.
        /// </summary>
        public virtual void CheckNumber()
        {
            User.NumberOfQuestions++;

            if (RandomNumber < userGuess)
                Notifications.NumberWasTooBigText();
            if (RandomNumber > userGuess)
                Notifications.NumberWasTooSmallText();
            if (RandomNumber == userGuess)
                GameWon();
        }
        /// <summary>
        /// User got the number right and won the game.
        /// </summary>
        public virtual void GameWon()
        {
            User.NumberOfWins++;
            StartGame();
        }
        /// <summary>
        /// User lost after seven tries.
        /// </summary>
        public virtual void GameOver()
        {
            Notifications.GameOverText();
            StartGame();
        }
        /// <summary>
        /// Reset the game to default values.
        /// </summary>
        public virtual void ResetGame()
        {
            RandomNumber = Random.Next(MinimalGuess, MaximalGuess);
            User.NumberOfQuestions = 0;
            User.NumberOfGames++;
        }
        /// <summary>
        /// User typed in END. Output user score and end application.
        /// </summary>
        public virtual void EndGame()
        {
            Environment.Exit(0);
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
