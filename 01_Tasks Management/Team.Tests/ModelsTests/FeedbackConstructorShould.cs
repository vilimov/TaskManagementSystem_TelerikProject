using Team.Model;
using Team.Model.Enum;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    public class FeedbackConstructorShould
    {
        [TestMethod]
        public void CreateNewFeedback_When_IdIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);

            //Assert
            Assert.AreEqual(id, sut.Id);
        }

        [TestMethod]
        public void CreateNewBug_When_TitleIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);

            //Assert
            Assert.AreEqual(title, sut.Title);
        }

        [TestMethod]
        public void CreateNewBug_When_DescriptionIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);

            //Assert
            Assert.AreEqual(description, sut.Description);
        }

        [TestMethod]
        public void CreateNewBug_When_RatingIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);

            //Assert
            Assert.AreEqual(rating, sut.Rating);
        }

        [TestMethod]
        public void ChangeRating_When_InputIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);
            sut.ChangeRating(5);

            //Assert
            Assert.AreEqual(5, sut.Rating);
        }

        [TestMethod]
        public void ReturnCorrectStatus_When_StatusIsChanged()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);
            sut.ChangeFeedbackStatus(FeedbackStatus.Done);

            //Assert
            Assert.AreEqual(FeedbackStatus.Done, sut.StatusType);
        }

        [TestMethod]
        public void ReturnCorrectType_When_ParametersAreValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            int rating = FeedbackData.ValidRating;

            //Act
            var sut = new Feedback(id, title, description, rating);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Model.Feedback));
        }
    }
}
