using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Tests.Helpers;

namespace Team.Tests.ModelsTests
{
    [TestClass]
    public class TeamTestsShould
    {
        [TestMethod]
        public void CreateNewMember_When_InputIdIsValid()
        {
            //Arrange
            string teamName = TeamData.ValidName;
            string classType = "Team";
            //Act
            var sut = new Model.Team(teamName);

            //Assert
            Assert.AreEqual(sut.GetType().Name, classType);
        }
        [TestMethod]
        public void ReturnCorrectNameOfTeam()
        {
            //Arrange
            string teamName = TeamData.ValidName;
            string classType = "Team";
            //Act
            var sut = new Model.Team(teamName);

            //Assert
            Assert.AreEqual(teamName, sut.Name);
        }
        [TestMethod]
        public void ReturnCopyOfListOfMembers()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            // Act
            sut.Members.Add(MemberTestInitialization.InitializeTestMember());

            // Assert
            Assert.AreEqual(0, sut.Members.Count);
        }
        [TestMethod]
        public void ReturnCopyOfListOfBoards()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            // Act
            sut.Boards.Add(BoardTestInitialization.InitializeTestBoard());

            // Assert
            Assert.AreEqual(0, sut.Boards.Count);
        }
        [TestMethod]
        public void AddBoardToListOfBoards()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            var testBoard = BoardTestInitialization.InitializeTestBoard();
            int listCount = sut.Boards.Count + 1;
            // Act
            sut.AddBoard(testBoard);

            // Assert
            Assert.AreEqual(listCount, sut.Boards.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExeption_When_SameBoardAdded()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            var testBoard = BoardTestInitialization.InitializeTestBoard();
            int listCount = sut.Boards.Count + 1;
            // Act and Assert
            sut.AddBoard(testBoard);
            sut.AddBoard(testBoard);
        }
        [TestMethod]
        public void AddMemberToListOfMembers()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            var testMember = MemberTestInitialization.InitializeTestMember();
            int listCount = sut.Members.Count + 1;
            // Act
            sut.AddMember(testMember);

            // Assert
            Assert.AreEqual(listCount, sut.Members.Count);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExeption_When_SameMemberAdded()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            var testMember = MemberTestInitialization.InitializeTestMember();
            int listCount = sut.Members.Count + 1;
            // Act and Assert
            sut.AddMember(testMember);
            sut.AddMember(testMember);
        }
        [TestMethod]
        public void RemoveMemberFromListOfMembers()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            var testMember = MemberTestInitialization.InitializeTestMember();
            sut.AddMember(testMember); 
            int listCount = sut.Members.Count - 1;
            // Act
            sut.RemoveMember(testMember);

            // Assert
            Assert.AreEqual(listCount, sut.Members.Count);
        }
        [TestMethod]
        public void RemoveBoardFromListOfBoards()
        {
            // Arrange
            string teamName = TeamData.ValidName;
            var sut = new Model.Team(teamName);
            var testBoard = BoardTestInitialization.InitializeTestBoard();
            sut.AddBoard(testBoard); 
            int listCount = sut.Boards.Count - 1;
            // Act
            sut.RemoveBoard(testBoard);

            // Assert
            Assert.AreEqual(listCount, sut.Boards.Count);
        }

    }
    
}
