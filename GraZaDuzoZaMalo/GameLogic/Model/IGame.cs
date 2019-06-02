namespace GameLogic.Model
{
    /// <summary>
    /// Common interface for games.
    /// </summary>
    public interface IGame
    {
        #region Methods

        /// <summary>
        /// Begin the game with first question.
        /// </summary>
        void StartGame();

        /// <summary>
        /// Ask user for his answer.
        /// </summary>
        void AskUser();

        /// <summary>
        /// Try parsing the user's answer.
        /// </summary>
        /// <param name="answer">User's input.</param>
        void CheckAnswer(string answer);

        /// <summary>
        /// Check if the user guessed the answer.
        /// </summary>
        void CheckNumber();

        /// <summary>
        /// Quit the game. Close the application.
        /// </summary>
        void EndGame();

        /// <summary>
        /// User gave 7 wrong answers.
        /// </summary>
        void GameOver();

        /// <summary>
        /// User got the answer right.
        /// </summary>
        void GameWon();

        /// <summary>
        /// Reset the values to default.
        /// </summary>
        void ResetGame();

        /// <summary>
        /// Creates new user based on user's input and starts the game.
        /// </summary>
        void InitializeGame();

        #endregion Methods
    }
}