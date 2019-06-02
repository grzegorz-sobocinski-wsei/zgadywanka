using System;

namespace GameLogic
{
    /// <summary>
    /// Contains common properties that are used in every game application version.
    /// /// </summary>
    public abstract class BaseGame
    {
        #region Constant Values

        /// <summary>
        /// The highest number user can input.
        /// </summary>
        protected const int MaximalGuess = 100;

        /// <summary>
        /// The lowest number user can input.
        /// </summary>
        protected const int MinimalGuess = 0;

        /// <summary>
        /// Amount of questions for one game.
        /// </summary>
        protected const int QuestionsLimit = 7;

        #endregion Constant Values

        #region Protected Fields

        /// <summary>
        /// User's input.
        /// </summary>
        protected int UserAnswer;

        /// <summary>
        /// Current user of the game.
        /// </summary>
        protected User User { get; set; }

        /// <summary>
        /// Random number generator.
        /// </summary>
        protected Random Random => new Random();

        /// <summary>
        /// Random number which user has to guess.
        /// </summary>
        protected int RandomNumber { get; set; }

        #endregion Protected Fields

        #region Public Methods

        public string GameOverText()
        {
            return $"Sorry, you have no more questions left. I was thinking of {RandomNumber}. Let's start again!";
        }

        public string GameWonText()
        {
            return $"That's correct! I was thinking of {RandomNumber}. You got it by {User.NumberOfQuestions} try. Let's begin a new game!";
        }

        public string EndGameText()
        {
            return $"You played {User.NumberOfGames} games and won {User.NumberOfWins}.";
        }

        public string ScoreInformationText()
        {
            return $"{User.Name}, you have played {User.NumberOfGames} games and won {User.NumberOfWins} of them.";
        }

        #endregion Public Methods
    }
}