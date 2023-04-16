using Team.Command.Contracts;
using Team.Core.Contracts;

namespace Team.Command
{
    internal class ChangeStoryPriorityCommand : ICommand
    {
        public ChangeStoryPriorityCommand(List<string> commandParameters, IRepository repository)
        {
        }

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}