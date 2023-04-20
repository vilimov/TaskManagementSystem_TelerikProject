using Team.Command.Contracts;
using Team.Core.Contracts;
using Team.Model.Interface;
using Team.Model;
using Team.Exeption;

namespace Team.Command
{
    public class ChangeStoryStatusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeStoryStatusCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);
            int currentId = ParseIntParameter(CommandParameters[0], "ID");

            // Parameters:
            // [0] - ID
            // [1] - New Status
            var currentTask = Repository.Tasks.FirstOrDefault(t => t.Id == currentId);
            string message = string.Empty;
            //ToDo I know this should be implemented as Method as it is used more than once, but...
            if (currentTask is IStory story)
            {
                var currentStatus = story.Status;
                var newStatus = CommandParameters[1];
                Core.Repository.ChangeEnumValue(story, "Status", newStatus);
                message = $"Story status changed from {currentStatus} to {newStatus}";
            }
            else
            {
                throw new InvalidUserInputException($"The task with the provided ID '{currentId}' is not of type 'Story'");
            }            
            return message;
        }
    }
}