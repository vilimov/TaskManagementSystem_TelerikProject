using Team.Command.Contracts;
using Team.Core.Contracts;

namespace Team.Command
{
    internal class ChangeStoryStatusCommand : ICommand
    {
        public ChangeStoryStatusCommand(List<string> commandParameters, IRepository repository)
        {
        }
        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}