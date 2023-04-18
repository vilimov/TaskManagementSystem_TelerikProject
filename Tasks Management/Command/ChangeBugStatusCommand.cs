using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model;

namespace Team.Command
{
    public class ChangeBugStatusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public ChangeBugStatusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            int taskId = ParseIntParameter(this.CommandParameters[0], "taskId");
            StatusType newStatus = ParseStatusTypeParameter(this.CommandParameters[1], "status");

            var task = this.Repository.FindTask(taskId);
            if (!(task is Bug bug))
            {
                throw new InvalidUserInputException("The provided task ID was not found in Bug.");
            }

            bug.ChangeStatus(newStatus);
            return $"Bug with ID {taskId} status changed to {newStatus}.";
        }
    }
}
