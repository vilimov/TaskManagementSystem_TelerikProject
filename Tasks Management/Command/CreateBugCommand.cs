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
        public const int ExpectedNumberOfArguments = 7;
        public CreateBugCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  ID of the task - passed by the Repository
            //  Status of new Bug is active - no need to set
            //  [0] - title of the task - validation in the constructor
            //  [1] - descriotion of the task - validation in the constructor
            //  [2] - listOfSteps of the task
            //  [3] - Board in which to be added this task
            //  [4] - priority of the task
            //  [5] - severity of the task
            //  [6] - assignee of the task
            //HACK - Please note all Strings that contain spaces must be provided with << and >> example: <<This is the titel of the bug>>
            /*HACK - All parameters that start with << must be at the first positions - example: 
                 Title gets[0]
                 description gets[1]
                 listOfSteps gets[3]
            Doesnt matter the order they are entered in the console, doesnt matter how they are used in the commands
             */
            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            string listOfSteps = this.CommandParameters[2];
            string board = this.CommandParameters[3];
            PriorityType priority = this.ParsePriorityTypeParameter(this.CommandParameters[4], "priority");
            SeverityType severity = this.ParseSeverityTypeParameter(this.CommandParameters[5], "severity");
            string assignee = this.CommandParameters[6];
            
            var bug = this.Repository.CreateBug(title, description, board, priority, severity, assignee, listOfSteps);
            return $"Bug with ID {bug.Id} was created.";
        }
    }
}
