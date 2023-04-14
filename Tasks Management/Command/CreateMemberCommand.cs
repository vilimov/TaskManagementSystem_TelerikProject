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
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }


            string name = this.CommandParameters[0];

            var member = this.Repository.CreateMember(name);
            return $"Member '{member.Name}' was created.";
        }
    }
}
