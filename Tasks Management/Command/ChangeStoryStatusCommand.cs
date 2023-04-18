using Team.Command.Contracts;
using Team.Core.Contracts;
using Team.Model.Interface;
using Team.Model;

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
            ParseIntParameter(CommandParameters[0], "ID");

            // Parameters:
            // [0] - ID
            // [1] - New Status
            IStory obj = (Story)Repository.Tasks.FirstOrDefault(s => s.Id == int.Parse(CommandParameters[0]));
            var currentStatus = obj.Status;
            var newStatus = CommandParameters[1];
            Core.Repository.ChangeEnumValue(obj, "Status", newStatus);
            string message = $"Story status changed from {currentStatus} to {newStatus}";
            return message;
        }
    }
}