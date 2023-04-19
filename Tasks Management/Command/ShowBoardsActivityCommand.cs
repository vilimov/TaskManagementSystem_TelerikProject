using System.Text;
using Team.Core;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;
using Team.Model.Interface;

namespace Team.Command
{
    public class ShowBoardsActivityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowBoardsActivityCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Name of the Board
            string name = this.CommandParameters[0];
            if (!Repository.Boards.Any(b => b.Name == name))
            {
                throw new InvalidUserInputException($"Board with name {name} does not exist!");
            }
            return ListAllActivities(name);
        }
        
        private string ListAllActivities(string name)
        {
            var board = Repository.Boards.Where(b => b.Name == name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Board {name} has the following activities:");            
            foreach (var activity in board)
            {
                sb.AppendLine(activity.Name);
                sb.AppendLine("------------");
                foreach (var item in activity.ActivityHistory)
                { 
                    sb.AppendLine(item);
                }
            }
            sb.Append("---------------");
            return sb.ToString();
        }
    }
}
