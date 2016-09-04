using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var mock = new Mock<IConfiguration>();
            mock.Setup(x => x.Url).Returns("http://localhost:50014/api/Questions");
            var questionnaireController = new QuestionnaireController(mock.Object);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}