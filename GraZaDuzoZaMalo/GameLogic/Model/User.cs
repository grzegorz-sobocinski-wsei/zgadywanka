using System;

namespace GameLogic
{
    /// <summary>
    /// Current player of the game.
    /// </summary>
    public class User
    {
        #region Public Properties

        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Number of questions user have yet to answer.
        /// </summary>
        public int NumberOfQuestions { get; set; }

        /// <summary>
        /// Number of games won by the user.
        /// </summary>
        public int NumberOfWins { get; set; }

        /// <summary>
        /// Total number of games played by the user.
        /// </summary>
        public int NumberOfGames { get; set; }

        #endregion Public Properties

        #region Constructor

        public User(string name)
        {
            #region Guard Clasues

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), $"{nameof(User)}: {nameof(name)} is null or empty.");
            }

            #endregion Guard Clasues

            Name = name;
        }

        #endregion Constructor
    }
}