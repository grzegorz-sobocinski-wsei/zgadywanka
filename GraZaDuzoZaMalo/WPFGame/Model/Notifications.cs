using GameLogic;

namespace WPFGame
{
    public class Notifications : INotifications
    {
        /// <summary>
        /// Constants required for better look of the ArcadeClassic font.
        /// Without them notifications look like one word.
        /// </summary>
        private const string Space = " ";
        private const string DoubleSpace = "  ";

        private string notification;

        public string Notification
        {
            get { return notification; }
            set { notification = value.Replace(Space, DoubleSpace) }
        }


        public void FirstQuestionText()
        {
            Notification = "I'm thinking of a number between 0-100, try to guess it!";
        }

        public void GameOverText(int randomNumber)
        {
            Notification = string.Format("Sorry, you have no more questions left. I was thinking of {0}. Let's start again!", randomNumber);

        }

        public void GameWonText(int randomNumber, int numberOfQuestions)
        {
            Notification = string.Format("That's correct! I was thinking of a {0}." +
                " You got it by {1} try. Let's begin a new game!\n", randomNumber, numberOfQuestions);
        }

        public void InputWasntNumberText()
        {
            Notification = "That wasn't a number!";
        }

        public void NameIsEmpty()
        {
            Notification = "You have to type in your name!\nLet's try again, shall we?";
        }

        public void NumberWasTooBigText()
        {
            Notification = "That's too much!";
        }

        public void NumberWasTooSmallText()
        {
            Notification = "That's not enough!";
        }

        public void ScoreInformationText(int numberOfGames, int numberOfWins)
        {
            Notification = string.Format("You played {0} games and won {1}", numberOfGames, numberOfWins);
        }

        public void WelcomeText()
        {
            Notification = "Welcome! \nIf you want to quit and see your score " +
                "then type in \"END\"." + "\nWhat's your name?";
        }
    }
}
