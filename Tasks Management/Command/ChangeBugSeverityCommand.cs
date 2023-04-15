using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;
using Team.Model.Enum;

namespace Team.Command
{
    public class ChangeBugSeverityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeBugSeverityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(this.CommandParameters[0], "taskId");
            SeverityType newSeverity = ParseSeverityTypeParameter(this.CommandParameters[1], "severity");

            var task = this.Repository.FindTask(taskId);
            if (!(task is Bug bug))
            {
                throw new InvalidUserInputException("The provided task ID was not found in Bug");
            }
            bug.ChangeSeverity(newSeverity);
            return $"Bug with ID {taskId} severity changed to {newSeverity}";
        }
    }
}
