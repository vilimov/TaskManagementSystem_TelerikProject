using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    public class MemberTestsShould
    {
        [TestMethod]
        public void CreateNewMember_When_InputIdIsValid()
        {
            //Arrange
            string memberName = MemberData.ValidName;
            string classType = "Member";
            //Act
            var sut = new Model.Member(memberName);

            //Assert
            Assert.AreEqual(sut.GetType().Name, classType);
        }

        [TestMethod]
        public void ReturnCopyOfListOfTasks()
        {
            // Arrange
            string memberName = MemberData.ValidName;
            var sut = new Model.Member(memberName);

            // Act
            sut.Tasks.Add(TaskTestInitialization.InitializeTestBug());

            // Assert
            Assert.AreEqual(0, sut.Tasks.Count);
        }
        [TestMethod]
        public void ReturnCopyOfListOfActivityHistory()
        {
            // Arrange
            string memberName = MemberData.ValidName;
            var sut = new Model.Member(memberName);
            int listCount = sut.ActivityHistory.Count;
            // Act
            sut.ActivityHistory.Add("Test String");

            // Assert
            Assert.AreEqual(listCount, sut.ActivityHistory.Count);
        }
        [TestMethod]
        public void AssignTaskCorrectlty_When_ValidInput()
        {
            // Arrange
            string memberName = MemberData.ValidName;
            var sut = new Model.Member(memberName);
            int listCount = sut.Tasks.Count+1;
            // Act
            sut.AssignTask(TaskTestInitialization.InitializeTestBug());

            // Assert
            Assert.AreEqual(listCount, sut.Tasks.Count);
        }
        [TestMethod]
        public void UnassignTaskCorrectlty_When_ValidInput()
        {
            // Arrange
            string memberName = MemberData.ValidName;
            var sut = new Model.Member(memberName);
            var bug = TaskTestInitialization.InitializeTestBug();
            sut.AssignTask(bug);
            int listCount = sut.Tasks.Count - 1;
            // Act
            sut.UnassignTask(bug);

            // Assert
            Assert.AreEqual(listCount, sut.Tasks.Count);
        }
    }
}
