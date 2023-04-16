using Team.Command.Contracts;
using Team.Core.Contracts;
using Team.Core;
using System.Text;
using Team.Core;
using Team.Model.Interface;
using Team.Model;

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


            // Parameters:
            // [0] - ID
            // [1] - New Size

            IStory obj = (Story)Repository.Tasks.FirstOrDefault(s => s.Id == int.Parse(CommandParameters[0]));
            var currentSize = obj.Size;
            Console.WriteLine(currentSize);
            string message = $"Story size changed from {currentSize} to {CommandParameters[1]}";
            Core.Repository.ChangeEnumValue(obj, "SizeType", "string");

            Console.WriteLine(currentSize);
            return message;
        }

    }
}