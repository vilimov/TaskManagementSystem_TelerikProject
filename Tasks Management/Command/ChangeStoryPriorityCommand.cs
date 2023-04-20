using Team.Core.Contracts;
using Team.Model.Interface;
using Team.Model;
using Team.Exeption;

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
            int currentId = ParseIntParameter(CommandParameters[0], "ID");

            // Parameters:
            // [0] - ID
            // [1] - New Priority
            var currentTask = Repository.Tasks.FirstOrDefault(t => t.Id == currentId);
            string message = string.Empty;
            if (currentTask is IStory story)
            {
                var currentPriority = story.Priority;
                var newPriority = CommandParameters[1]; Core.Repository.ChangeEnumValue(story, "Priority", newPriority);
                message = $"Story priority changed from {currentPriority} to {newPriority}";
            }
            else
            {
                throw new InvalidUserInputException($"The task with the provided ID '{currentId}' is not of type 'Story'");
            }
            return message;
        }
    }
}