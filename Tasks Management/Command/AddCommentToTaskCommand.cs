using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Interface;
using Team.Model;

namespace Team.Command
{
    public class AddCommentToTaskCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;
        public AddCommentToTaskCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Comment text
            //  [1] - Task Id - where to add comment
            //  [2] - Autor name
            string commentText = CommandParameters[0];
            int taskId = ParseIntParameter(this.CommandParameters[1], "taskId");
            var task = this.Repository.FindTask(taskId);
            string memberName = CommandParameters[2];
            if (!Repository.Members.Any(m => m.Name == memberName))
            {
                throw new InvalidUserInputException($"Member with name {memberName} does not exist");
            }
            var member = Repository.Members.FirstOrDefault(m => m.Name == memberName);
            var commentToAdd = new Comment(commentText, member);
            task.AddComment(commentToAdd);
            return $"Member {memberName} added comment to task with id {taskId}.";
        }
    }
}
