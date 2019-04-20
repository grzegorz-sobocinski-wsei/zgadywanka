using GameLogic;
using static System.Console;

namespace GraMonolitycznie
{
    public class Notifications : INotifications
    {
        public void FirstQuestionText()
        {
            WriteLine("I'm thinking of a number between 0-100, try to guess it!");
        }

        public void GameOverText()
        {
            WriteLine("Sorry, you have no more questions left. Let's begin a new game!");
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
