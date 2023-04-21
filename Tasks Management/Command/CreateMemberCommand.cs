using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Command
{
    public class CreateMemberCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public CreateMemberCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }



        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            if (CommandParameters.Count == 1 && CommandParameters[0] == "CreateMember")
            {
                throw new InvalidUserInputException("Please input valid parameters for 'CreateMember' command");
            }

            string name = this.CommandParameters[0];

            var member = this.Repository.CreateMember(name);
            return $"Member '{member.Name}' was created.";
        }
    }
}
