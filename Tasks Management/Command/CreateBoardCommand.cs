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
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Board name
            //  [1] - Team name
            string boardName = this.CommandParameters[0];
            string teamName = this.CommandParameters[1];
            if (!Repository.Teams.Any(t => t.Name == teamName))
            {
                throw new InvalidUserInputException($"Team with name {teamName} does not exist");
            }
            var team = Repository.Teams.FirstOrDefault(t => t.Name == teamName);
            if (team.Boards.Any(b => b.Name == boardName))
            {
                throw new InvalidUserInputException($"Board with name {boardName} already exists in team {teamName}.");
            }
            this.Repository.CreateBoard(boardName, team);

            return $"Board {boardName} added to team {teamName}.";
        }
    }
}
