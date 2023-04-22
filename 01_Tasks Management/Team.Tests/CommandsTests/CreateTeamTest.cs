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
    public class CreateTeamTest
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
        [DataRow(CreateTeamCommand.ExpectedNumberOfArguments - 1)]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ExecuteShouldThrowException_When_InputIsNotValid(int testValue)
        { // Arrange
            var commandParameters = TaskData.GetListWithSize(testValue);
            var command = new CreateTeamCommand(commandParameters, repository);

            // Act & Assert
            command.Execute();            
        }
    }
}
