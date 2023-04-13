using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Command
{
    public class ShowTeamBoardsCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowTeamBoardsCommand(IList<string> commandParameters, IRepository repository) : base(repository)
        {
        }
        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException(@$"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}; \nPlease enter correct Team name");
            }
            // Parameters:
            //  [0] - Name of the Team
            string name = this.CommandParameters[0];
            return ListAllBoardsOfTeam(name);
        }

        private string ListAllBoardsOfTeam(string name)
        {
            foreach (var team in this.Repository.Teams)
            {
                if (team.Name == name)
                {
                    if (team.Boards.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"{team.Name} boards:");
                        foreach (var board in team.Boards)
                        {
                            sb.AppendLine(board.Name);
                        }
                        sb.Append("---------------");
                        return sb.ToString();
                    }
                    else
                    {
                        string text = $"Team {name} doesn't have any boards.";
                        return text;
                    }
                }
                
            }
            string message = $"No team with name - {name} exists.";
            return message;
        }
    }
}
