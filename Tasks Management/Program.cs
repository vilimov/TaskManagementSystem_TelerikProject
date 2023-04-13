using Team.Core;
using Team.Core.Contracts;

namespace Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();
        }
    }
}