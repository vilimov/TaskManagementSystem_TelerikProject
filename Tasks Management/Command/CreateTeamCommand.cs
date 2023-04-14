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

            //ToDo Needs implementation
            return "Member {memberName} added to team {teamName}.";
        }
    }
}
