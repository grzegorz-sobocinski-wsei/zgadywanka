using NUnit.Framework;
using System;
using Moq;

namespace ConsoleGame.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        private Mock<Game> game;
        [SetUp]
        public void SetUp()
        {
            game = new Mock<Game>();
        }
        [Test]
        public void CheckIfGuessIsNumber_AnswerIsNull_ReturnArgumentNullException()
        {
            // Assert
            game.Setup(game => game.CheckIfGuessIsNumber(null)).Throws<ArgumentNullException>();
            
        }
    }
}
