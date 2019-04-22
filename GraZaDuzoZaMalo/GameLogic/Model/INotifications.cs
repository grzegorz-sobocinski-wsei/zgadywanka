namespace GameLogic
{
    public interface INotifications
    {
        string Notification { get; set; }
        void WelcomeText();
        void FirstQuestionText();
        void InputWasntNumberText();
        void NumberWasTooBigText();
        void NumberWasTooSmallText();
        void GameWonText(int randomNumber, int numberOfQuestions);
        void GameOverText(int randomNumber);
        void ScoreInformationText(int numberOfGames, int numberOfWins);
        void NameIsEmpty();
    }
}
