using NUnit.Framework;
using System;

namespace ConsoleGame.UnitTests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }
        [Test]
        public void CheckIfGuessIsNumber_AnswerIsNull_ReturnArgumentNullException()
        {
            // Act
            var result = Assert.Throws<ArgumentNullException>(() => game.CheckIfGuessIsNumber(null));

            // Assert
            Assert.That(result.ParamName, Is.EqualTo("answer"));
        }
    }
}
