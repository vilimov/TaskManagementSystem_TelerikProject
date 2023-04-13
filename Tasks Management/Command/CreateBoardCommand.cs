using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;

namespace Team.Command
{
    public class CreateBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public CreateBoardCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }
            // Parameters:
            //  [0] - Board name
            //  [1] - Team name
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];

            var board = this.Repository.CreateBoard(boardName);
            //ToDo Implementation
            return $"Board {boardName} added to team {teamName}.";
        }
    }
}
