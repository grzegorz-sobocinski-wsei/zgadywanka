using GameLogic;
using static System.Console;

namespace ConsoleGame
{
    public class Notifications : INotifications
    {
        /// <summary>
        /// Not used in this platform, however needed for the WPF and XAML projects.
        /// </summary>
        public string Notification { get; set; }

        public void FirstQuestionText()
        {
            WriteLine("I'm thinking of a number between 0-100, try to guess it!");
        }

        public void GameOverText(int randomNumber)
        {
            WriteLine(string.Format("Sorry, you have no more questions left. I was thinking of {0}. Let's start again!", randomNumber));
        }

        public void GameWonText(int randomNumber, int numberOfQuestions)
        { 
            WriteLine(string.Format("That's correct! I was thinking of a {0}." +
                " You got it by {1} try. Let's begin a new game!\n", randomNumber, numberOfQuestions));
        }

        public void InputWasntNumberText()
        {
            WriteLine("That wasn't a number!");
        }

        public void NameIsEmpty()
        {
            WriteLine("You have to type in your name!\nLet's try again, shall we?");
        }

        public void NumberWasTooBigText()
        {
            WriteLine("That's too much!");
        }

        public void NumberWasTooSmallText()
        {
            WriteLine("That's not enough!");
        }

        public void ScoreInformationText(int numberOfGames, int numberOfWins)
        {
            WriteLine(string.Format("You played {0} games and won {1}", numberOfGames, numberOfWins));
        }

        public void WelcomeText()
        {
            WriteLine("Welcome! \nIf you want to quit and see your score " +
                "then type in \"END\"." + "\nWhat's your name?");
        }
    }
}
