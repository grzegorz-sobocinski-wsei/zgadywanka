using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraMonolitycznie
{
    public class User
    {
        #region Public Properties
        public string Name;
        public int NumberOfQuestions;
        public int NumberOfWins;
        public int NumberOfGames;
        #endregion
        public User(string name)
        {
            // Guard clause
            if (name == null)
                throw new ArgumentNullException("name");

            Name = name;
        
        }


    }
}
