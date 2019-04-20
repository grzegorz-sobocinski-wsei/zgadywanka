using System;

namespace GameLogic
{
    public class User
    {
        #region Public Properties
        public string Name;
        public int NumberOfQuestions;
        public int NumberOfWins;
        public int NumberOfGames;
        #endregion
        #region Constructor
        public User(string name)
        {
            // Guard clause
            Name = name ?? throw new ArgumentNullException("name");
        }
        #endregion
    }
}
