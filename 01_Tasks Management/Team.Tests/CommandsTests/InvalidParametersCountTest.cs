using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Core;
using Team.Model;
using Team.Tests.Helpers;
using Team.Command;
using System.Runtime.ConstrainedExecution;
using Team.Exeption;

namespace Team.Tests.CommandsTests
{
    [TestClass]
    public class InvalidParametersCountTest
    {
        private IRepository repository;
        private ICommandFactory commandFactory;
        private Member member;

        [TestInitialize]
        public void InitTest()
        {
            this.repository = new Repository();
            this.commandFactory = new CommandFactory(this.repository);
            this.member = new Member(MemberData.ValidName);
        }

        [TestMethod]
        [DataRow(AddCommentToTaskCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void AddCommentToTaskCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new AddCommentToTaskCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }
        [TestMethod]
        [DataRow(AddMemberToTeamCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void AddMemberToTeamCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new AddMemberToTeamCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeAssigneeCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeAssigneeCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeAssigneeCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeBugPriorityCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeBugPriorityCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeBugPriorityCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeBugSeverityCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeBugSeverityCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeBugSeverityCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeBugStatusCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeBugStatusCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeBugStatusCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeFeedbackRatingCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeFeedbackRatingCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeFeedbackRatingCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeFeedbackStatusCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeFeedbackStatusCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeFeedbackStatusCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeStoryPriorityCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeStoryPriorityCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeStoryPriorityCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeStorySizeCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeStorySizeCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeStorySizeCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ChangeStoryStatusCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ChangeStoryStatusCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeStoryStatusCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(CreateBoardCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CreateBoardCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ChangeFeedbackStatusCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(CreateBugCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CreateBugCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new CreateBugCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(CreateFeedbackCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CreateFeedbackCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new CreateFeedbackCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(CreateMemberCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CreateMemberCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new CreateMemberCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(CreateStoryCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CreateStoryCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new CreateStoryCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(CreateTeamCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void CreateTeamCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new CreateTeamCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ShowBoardsActivityCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ShowBoardsActivityCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ShowBoardsActivityCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ShowMembersActivityCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ShowMembersActivityCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ShowMembersActivityCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ShowTeamBoardsCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ShowTeamBoardsCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ShowTeamBoardsCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ShowTeamMembersCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ShowTeamMembersCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ShowTeamMembersCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }

        [TestMethod]
        [DataRow(ShowTeamsActivityCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ShowTeamsActivityCommandExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new ShowTeamsActivityCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();
        }
    }
}
