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
    public class ChangeBugPriorityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public ChangeBugPriorityCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(this.CommandParameters[0], "taskId");
            PriorityType newPriority = ParsePriorityTypeParameter(this.CommandParameters[1], "priority");

            var task = this.Repository.FindTask(taskId);
            if (!(task is Bug bug))
            {
                throw new InvalidUserInputException("The provided task ID does not correspond to a Bug.");
            }

            bug.ChangePriority(newPriority);
            return $"Bug with ID {taskId} priority changed to {newPriority}.";
        }
    }
}
