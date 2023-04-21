using Newtonsoft.Json.Linq;
using System.Threading.Channels;
using Team.Model;
using Team.Model.Enum;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    public class StoryConstructorShould
    {
        [TestMethod]
        public void CreateNewStory_When_IdIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(id, sut.Id);
        }

        [TestMethod]
        public void CreateNewStory_When_TitleIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(title, sut.Title);
        }

        [TestMethod]
        public void CreateNewStory_When_DescriptionIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(description, sut.Description);
        }

        [TestMethod]
        public void CreateNewStory_When_PriorityIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(priority, sut.Priority);
        }

        [TestMethod]
        public void CreateNewStory_When_SizeIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(size, sut.Size);
        }

        [TestMethod]
        public void ReturnCorrectStatus_When_StatusIsChanged()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(StoryStatusType.NotDone, sut.Status);
        }

        [TestMethod]
        public void CreateNewStory_When_AssigneeIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.AreEqual(assignee, sut.Assignee);
        }

        [TestMethod]
        public void ReturnCorrectAssignee_When_AssigneeIsChanged()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);
            sut.ChangeAssignee("newAssignee");

            //Assert
            Assert.AreEqual("newAssignee", sut.Assignee);
        }

        [TestMethod]
        public void ReturnCorrectType_When_ParametersAreValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = StoryData.ValidPriority;
            SizeType size = StoryData.ValidSize;
            string assignee = BugData.ValidAssignee;

            //Act
            var sut = new Story(id, title, description, priority, size, assignee);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Model.Story));
        }
    }
}