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
    public class ChangeFeedbackRatingCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeFeedbackRatingCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            //Parameters
            //[0] - ID of the feedback
            //[1] - New Rating
            int taskId = ParseIntParameter(this.CommandParameters[0], "taskId");
            int newRating = ParseIntParameter(this.CommandParameters[1], "rating");

            var task = this.Repository.FindTask(taskId);
            if (!(task is Feedback fb))
            {
                throw new InvalidUserInputException("The provided task ID was not found in Feedback.");
            }

            fb.ChangeRating(newRating);
            return $"Feedback with ID {taskId} rating changed to {newRating}.";
        }
    }
}
