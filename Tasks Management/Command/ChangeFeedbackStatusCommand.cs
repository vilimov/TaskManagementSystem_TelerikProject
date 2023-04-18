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
    public class ChangeFeedbackStatusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeFeedbackStatusCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            //Parameters
            //[0] - ID of the feedback
            //[1] - New Status
            int taskId = ParseIntParameter(this.CommandParameters[0], "taskId");
            FeedbackStatus newFBStatus = ParseFeedbackStatusParameter(this.CommandParameters[1], "feedbackStatus");

            var task = this.Repository.FindTask(taskId);
            if (!(task is Feedback fb))
            {
                throw new InvalidUserInputException("The provided task ID was not found in Feedback");
            }
            fb.ChangeFeedbackStatus(newFBStatus);
            return $"Feedback Status changed to {newFBStatus}";
        }
    }
}
