using Team.Exeption;
using Team.Model;
using Team.Model.Enum;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    public class BugConstructorShould
    {
        [TestMethod]
        public void CreateNewBug_When_IdIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

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
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

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
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

            //Assert
            Assert.AreEqual(description, sut.Description);
        }

        [TestMethod]
        public void CreateNewBug_When_PriorityIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

            //Assert
            Assert.AreEqual(priority, sut.Priority);
        }

        [TestMethod]
        public void ReturnCorrectPriority_When_PriorityIsChanged()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);
            sut.ChangePriority(PriorityType.High);

            //Assert
            Assert.AreEqual(PriorityType.High, sut.Priority);
        }

        [TestMethod]
        public void CreateNewBug_When_SeverityIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

            //Assert
            Assert.AreEqual(severity, sut.Severity);
        }

        [TestMethod]
        public void ReturnCorrectSeverity_When_SeverityIsChanged()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);
            sut.ChangeSeverity(SeverityType.Critical);

            //Assert
            Assert.AreEqual(SeverityType.Critical, sut.Severity);
        }

        [TestMethod]
        public void ReturnCorrectStatus_When_StatusIsChanged()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);
            sut.ChangeStatus(StatusType.Fixed);

            //Assert
            Assert.AreEqual(StatusType.Fixed, sut.Status);
        }

        [TestMethod]
        public void CreateNewBug_When_AssigneeIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

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
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);
            sut.ChangeAssignee("newAssignee");

            //Assert
            Assert.AreEqual("newAssignee", sut.Assignee);
        }

        [TestMethod]
        public void CreateNewBug_When_StepsAreValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

            //Assert
            Assert.AreEqual(steps, sut.ListOfSteps);
        }

        [TestMethod]
        public void ReturnCorrectSteps_When_StepsAreCalled()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);
            string bugSteps = sut.ListOfSteps.ToString();

            //Assert
            Assert.AreEqual(bugSteps, sut.ListOfSteps.ToString());
        }

        [TestMethod]
        public void ChangePriority_When_InputIsValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

            //Assert
            Assert.AreEqual(priority, sut.Priority);
        }

        [TestMethod]
        public void ReturnCorrectType_When_ParametersAreValid()
        {
            //Arrange
            int id = 1;
            string title = TaskData.ValidTitle;
            string description = TaskData.ValidDescription;
            PriorityType priority = BugData.ValidPriority;
            SeverityType severity = BugData.ValidSeverity;
            string assignee = BugData.ValidAssignee;
            string steps = BugData.ValidStepsList;

            //Act
            var sut = new Bug(id, title, description, priority, severity, assignee, steps);

            //Assert
            Assert.IsInstanceOfType(sut, typeof(Model.Bug));
        }
    }
}
