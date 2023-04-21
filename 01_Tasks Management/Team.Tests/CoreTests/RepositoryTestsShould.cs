using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Command;
using Team.Core;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Tests.Helpers;
using Team.Tests.ModelsTests;

namespace Team.Tests.CoreTests
{
    [TestClass]
    public class RepositoryTestsShould
    {
        private IRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = RepossitoryTestInitialization.GetTestRepository();
        }
        [TestMethod]
        public void ReturnCopyOfListOfTeams()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var testTeam = new Model.Team(teamName);
            // Act
            repository.Teams.Add(testTeam);

            // Assert
            Assert.AreEqual(0, repository.Teams.Count);
        }
        [TestMethod]
        public void ReturnCopyOfListOfMembers()
        {
            // Arrange
            var member = MemberTestInitialization.InitializeTestMember();
            // Act
            repository.Members.Add(member);

            // Assert
            Assert.AreEqual(0, repository.Members.Count);
        }
        [TestMethod]
        public void ReturnCopyOfListOfBoards()
        {
            // Arrange
            var board = BoardTestInitialization.InitializeTestBoard();
            // Act
            repository.Boards.Add(board);

            // Assert
            Assert.AreEqual(0, repository.Boards.Count);
        }
        [TestMethod]
        public void ReturnCopyOfListOfTasks()
        {
            // Arrange
            var bug = TaskTestInitialization.InitializeTestBug();
            // Act
            repository.Tasks.Add(bug);

            // Assert
            Assert.AreEqual(0, repository.Tasks.Count);
        }
        [TestMethod]
        public void CreateTeam_When_ValidInput_AndAddteamToList()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            repository.CreateTeam(teamName);

            // Act, Assert
            Assert.AreEqual(1, repository.Teams.Count);
        }
        [TestMethod]
        public void CreateBoard_When_ValidInput_AndAddBoardToList()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var testTeam = repository.CreateTeam(teamName);
            repository.CreateBoard(BoardData.ValidName, testTeam);

            // Act, Assert
            Assert.AreEqual(1, repository.Boards.Count);
        }
        [TestMethod]
        public void CreateMember_When_ValidInput_AndAddMemberToList()
        {
            // Arrange
            string testName = MemberData.ValidName;
            repository.CreateMember(testName);

            // Act, Assert
            Assert.AreEqual(1, repository.Members.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_When_SameNameUsedForMember()
        {
            // Arrange
            string testName = MemberData.ValidName;

            // Act, Assert
            repository.CreateMember(testName);
            repository.CreateMember(testName);
        }
        [TestMethod]
        public void CreateBug_When_ValidInput_AndAddTaskToList()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            repository.CreateBug(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        BugData.ValidPriority,
                        BugData.ValidSeverity,
                        MemberData.ValidName,
                        BugData.ValidStepsList,
                        TeamData.ValidName);

            // Act, Assert
            Assert.AreEqual(1, repository.Tasks.Count);
        }
        [TestMethod]
        public void CreateFeedback_When_ValidInput_AndAddTaskToList()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            repository.CreateFeedback(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        1,
                        BoardData.ValidName,
                        TeamData.ValidName);

            // Act, Assert
            Assert.AreEqual(1, repository.Tasks.Count);
        }
        [TestMethod]
        public void CreateStory_When_ValidInput_AndAddTaskToList()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        TeamData.ValidName);

            // Act, Assert
            Assert.AreEqual(1, repository.Tasks.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ThrowInvalidUserInputException_When_CheckIfTeamDoesntExist()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);


            // Act, Assert
            repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        "InvalidName");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_When_IncorrectMemberForReturnTheMember()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);


            // Act, Assert
            repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        "InvalidName",
                        TeamData.ValidName);
        }
        [TestMethod]
        public void FindTask_When_ValidInput()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            var story = repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        TeamData.ValidName);

            // Act, Assert
            Assert.AreEqual(story, repository.FindTask(1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_When_FindTask_InValidInput()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            var story = repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        TeamData.ValidName);

            // Act, Assert
            Assert.AreEqual(story, repository.FindTask(2));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_WHEN_TitleExistsInBoard()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            var story = repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        TeamData.ValidName);
            var story2 = repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        BoardData.ValidName,
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        TeamData.ValidName);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentException_When_CheckTeamHasBoardIsValid()
        {
            // Arrange
            var testTeam = repository.CreateTeam(TeamData.ValidName);
            var testBoard = repository.CreateBoard(BoardData.ValidName, testTeam);
            var testTeam2 = repository.CreateTeam("Valid name2");
            var testBoard2 = repository.CreateBoard("Valid name2", testTeam2);
            var testMember = repository.CreateMember(MemberData.ValidName);
            testTeam.AddMember(testMember);
            var story = repository.CreateStory(
                        TaskData.ValidTitle,
                        TaskData.ValidDescription,
                        "Valid name2",
                        StoryData.ValidPriority,
                        StoryData.ValidSize,
                        MemberData.ValidName,
                        TeamData.ValidName);
        }
    }
}
