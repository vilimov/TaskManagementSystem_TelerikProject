using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;
using Team.Model.Interface;

namespace Team.Command
{
    public class ChangeStorySizeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStorySizeCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);
            int currentId = ParseIntParameter(CommandParameters[0], "ID");

            // Parameters:
            // [0] - ID
            // [1] - New Size
            var currentTask = Repository.Tasks.FirstOrDefault(t => t.Id == currentId);
            string message = string.Empty;
            if (currentTask is IStory story)
            {
                var currentSize = story.Size;
                var newSize = CommandParameters[1];
                Core.Repository.ChangeEnumValue(story, "Size", newSize);
                message = $"Story size changed from {currentSize} to {newSize}";
            }
            else
            {
                throw new InvalidUserInputException($"The task with the provided ID '{currentId}' is not of type 'Story'");
            }
            return message;
        }
    }
}