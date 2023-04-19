using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Command
{
    public class ShowMembersActivityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowMembersActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {

            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Name of the Member
            string name = this.CommandParameters[0];
            if (!Repository.Members.Any(m => m.Name == name))
            {
                throw new InvalidUserInputException($"Member with name {name} does not exist!");
            }
            return ListAllActivities(name);
        }

        private string ListAllActivities(string name)
        {
            var member = Repository.Members.FirstOrDefault(m => m.Name == name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Member {name} has the following activities:");
            foreach (var activity in member.ActivityHistory)
            {
                sb.AppendLine(activity);
            }
            sb.Append("---------------");
            return sb.ToString();
        }
    }
}
