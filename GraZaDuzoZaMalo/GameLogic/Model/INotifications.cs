﻿namespace GameLogic
{
    public interface INotifications
    {
        void WelcomeText();
        void FirstQuestionText();
        void InputWasntNumberText();
        void NumberWasTooBigText();
        void NumberWasTooSmallText();
        void GameWonText(int randomNumber, int numberOfQuestions);
        void GameOverText();
        void ScoreInformationText(int numberOfGames, int numberOfWins);
    }
}