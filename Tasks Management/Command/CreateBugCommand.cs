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
    public class CreateBugCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 8;
        public CreateBugCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }
            // Parameters:
            //  ID of the task - passed by the Repository
            //  Status of new Bug is active - no need to set
            //  [0] - title of the task - validation in the constructor
            //  [1] - descriotion of the task - validation in the constructor
            //  [2] - Board in which to be added this task
            //  [3] - priority of the task
            //  [4] - severity of the task
            //  [5] - assignee of the task
            //  [6] - listOfSteps of the task

            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            string board = this.CommandParameters[2];
            PriorityType priority = this.ParsePriorityTypeParameter(this.CommandParameters[3], "priority");
            SeverityType severity = this.ParseSeverityTypeParameter(this.CommandParameters[4], "severity");
            string assignee = this.CommandParameters[5];
            string listOfSteps = this.CommandParameters[6];

            var bug = this.Repository.CreateBug(title, description, board, priority, severity, assignee, listOfSteps);
            return $"Bug with ID {bug.Id} was created.";
        }
    }
}
