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
        public const int ExpectedNumberOfArguments = 6;
        public CreateStoryCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            string boardName = this.CommandParameters[2];
            PriorityType priority = ParsePriorityTypeParameter(this.CommandParameters[3], "priority");
            SizeType size = ParseSizeTypeParameter(this.CommandParameters[4], "size");            
            string assignee = this.CommandParameters[5];

            var story = this.Repository.CreateStory(title, description, boardName, priority, size, assignee);
            return $"Story with ID {story.Id} was created.";
        }
    }
}
