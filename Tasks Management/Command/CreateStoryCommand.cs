using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;

namespace Team.Command
{
    public class CreateStoryCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 7;
        public CreateStoryCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }
            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            string boardName = this.CommandParameters[2];
            PriorityType priority = ParsePriorityTypeParameter(this.CommandParameters[3], "priority");
            SizeType size = ParseSizeTypeParameter(this.CommandParameters[4], "size");
            StoryStatusType status = ParseStoryStatusTypeParameter(this.CommandParameters[5], "status");
            string assignee = this.CommandParameters[6];

            var story = this.Repository.CreateStory(title, description, boardName, priority, size, status, assignee);
            return $"Story with ID {story.Id} was created.";
        }
    }
}
