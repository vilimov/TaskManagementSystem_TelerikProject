using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Command
{
    public class CreateTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public CreateTeamCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            //Parameters:
            // [0] Team Name
            string teamName = this.CommandParameters[0];
            if (Repository.Teams.Any(t => t.Name == teamName)) 
            {
                throw new InvalidUserInputException($"Team with name {teamName} already exists.");
            }

            var team = Repository.CreateTeam(teamName);

            return $"Team {teamName} added to teams.";
        }
    }
}
