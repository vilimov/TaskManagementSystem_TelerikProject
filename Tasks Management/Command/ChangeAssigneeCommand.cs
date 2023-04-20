using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;

namespace Team.Command
{
    public class ChangeAssigneeCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public ChangeAssigneeCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Task ID
            //  [1] - New Assignee name
            int taskId = ParseIntParameter(this.CommandParameters[0], "taskId");
            var task = this.Repository.FindTask(taskId);
            string memberName = CommandParameters[1];
            if (!Repository.Members.Any(m => m.Name == memberName))
            {
                throw new InvalidUserInputException($"Member with name {memberName} does not exist");
            }
            var member = Repository.Members.FirstOrDefault(m => m.Name == memberName);
            if(!Repository.Teams.Any(t => t.Members.Contains(member)))
            {
                throw new InvalidUserInputException($"Member with name {memberName} is not in the team responsible for this task");
            }
            if (task is Feedback)
            {
                throw new InvalidUserInputException("Feedback doesn't have assignee");
            }
            if(task is Bug bug)
            {
                bug.ChangeAssignee(memberName);
                member.AssignTask(bug);
                var oldMember = Repository.Members.FirstOrDefault(m => m.Name != member.Name && m.Tasks.Contains(bug));
                oldMember.UnassignTask(bug);
            }
            if (task is Story story)
            {
                story.ChangeAssignee(memberName);
                member.AssignTask(story);
                var oldMember = Repository.Members.FirstOrDefault(m => m.Name != member.Name && m.Tasks.Contains(story));
                oldMember.UnassignTask(story);
            }
            return $"Task re-assigned to {memberName}";
        }
    }
}
