using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Command
{
    public class CreateFeedbackCommand : BaseCommand 
    {
        public const int ExpectedNumberOfArguments = 4;
        public CreateFeedbackCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  ID of the task - passed by the Repository
            //  [0] - title of the task - validation in the constructor
            //  [1] - descriotion of the task - validation in the constructor
            //  [2] - rating - validation in the constructor
            //  [3] - Board in which to be added this task
            //  FeedbackStatus is set to New in the constructor
            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            int rating = ParseIntParameter(this.CommandParameters[2], "rating");
            string board = this.CommandParameters[3];
            //FeedbackStatus feedbackStatus = this.ParseFeedbackStatusParameter(this.CommandParameters[4], "feedbackStatus");

            var feedback = this.Repository.CreateFeedback(title, description, rating, board);
            return $"Feedback with ID {feedback.Id} was created.";

        }
    }
}
