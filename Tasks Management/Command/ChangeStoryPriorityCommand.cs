using Team.Core.Contracts;
using Team.Model.Interface;
using Team.Model;

namespace Team.Command
{
    public class ChangeStoryPriorityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStoryPriorityCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);
            ParseIntParameter(CommandParameters[0], "ID");

            // Parameters:
            // [0] - ID
            // [1] - New Priority
            IStory obj = (Story)Repository.Tasks.FirstOrDefault(s => s.Id == int.Parse(CommandParameters[0]));
            var currentPriority = obj.Priority;
            var newPriority = CommandParameters[1];
            Core.Repository.ChangeEnumValue(obj, "Priority", newPriority);
            string message = $"Story priority changed from {currentPriority} to {newPriority}";
            return message;
        }
    }
}