using System.Text;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Command
{
    public class ShowTeamsActivityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowTeamsActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Name of the Team
            string name = this.CommandParameters[0];
            if (!Repository.Teams.Any(t => t.Name == name))
            {
                throw new InvalidUserInputException($"Team with name '{name}' does not exist!");
            }
            return ListAllActivities(name);
        }

        private string ListAllActivities(string name)
        {
            var team = Repository.Teams.FirstOrDefault(t => t.Name == name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team {name} has the following activities:");
            foreach (var activity in team.ActivityHistory)
            {
                sb.AppendLine(activity);
            }
            sb.Append("---------------");
            return sb.ToString();
        }
    }
}
