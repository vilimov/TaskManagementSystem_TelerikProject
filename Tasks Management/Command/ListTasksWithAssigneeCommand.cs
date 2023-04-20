using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;
using Team.Model.Interface;

namespace Team.Command
{
    public class ListTasksWithAssigneeCommand : BaseCommand
    {
        //public const int ExpectedNumberOfArguments = 1;
        public ListTasksWithAssigneeCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            //ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);
            // Parameters:
            //  [0] - Name of the Board
            //FilterByStatus stausName, FilterByAssignee assigneeName, FilterByStatusAssignee stausName assigneeName
            //SortByTitle, 
           
            string firstCommand = this.CommandParameters[0];
            if (firstCommand == "ListTasksWithAssignee") {
                return ListAllTasksAndAssignee();
            }
            else if (firstCommand == "SortByTitle")
            {
                return SortTasksByTitle();
            }
            else if (firstCommand == "FilterByAssignee")
            {
                ValidateInputParametersCount(CommandParameters, 2);

                string assignee = this.CommandParameters[1];
                return FilterByAssignee(assignee);
            }
            else if (firstCommand == "FilterByStatus")
            {
                ValidateInputParametersCount(CommandParameters, 2);
                string staus = this.CommandParameters[1];
                
                if (staus == "Fixed" || staus == "Active")
                {
                    return FilterByStatusBug(staus);
                }

               if (staus == "NotDone" || staus == "InProgress" || staus == "Done")
                {
                    return FilterByStatusStory(staus);
                }
            }
            throw new InvalidUserInputException($"Invalid Command peoperty for ListTasksWithAssignee");
        }

        private string FilterByStatusBug(string staus) 
        {
            var tempList = Repository.Tasks.Where(t => t.GetType().Name == "Bug").ToList();
            int counter = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"__List of tasks Filter by Status__");
            foreach (var task in tempList)
            {
                if (task is Bug bug)
                {
                    if (bug.Status.ToString() == staus) 
                    {
                        sb.AppendLine($"    {counter++}. Bug with status {bug.Status.ToString()} and title '{bug.Title}'");
                    }
                }
            }
            return sb.ToString();
        }
        private string FilterByStatusStory(string staus)
        {
            var tempList = Repository.Tasks.Where(t => t.GetType().Name == "Story").ToList();
            int counter = 1;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"__List of tasks Filter by Status__");
            foreach (var task in tempList)
            {
                if (task is Story story)
                {
                    if (story.Status.ToString() == staus)
                    {
                        sb.AppendLine($"    {counter++}. Story with status {story.Status.ToString()} and title '{story.Title}'");
                    }
                }

            }
            return sb.ToString();
        }
        private string FilterByAssignee(string name)
        {
            var tempList = Repository.Tasks.Where(t => t.GetType().Name != "Feedback").ToList();
            var asssigneed = Repository.Members.Where(n => n.Name == name).ToList();
            StringBuilder sb = new StringBuilder();
            if (asssigneed.Count == 0) { throw new InvalidUserInputException($"Name '{name}' doesnt exist in the app"); }
            
            sb.AppendLine($"__List of tasks Filter by Assignee__");
            int counter = 1;
            foreach (var asigned in asssigneed)
            {
                foreach (var item in asigned.Tasks)
                {
                    sb.AppendLine($"    {counter++}. {asigned.Name} has {item.GetType().Name} with title '{item.Title}'");
                }
                if (asigned.Tasks.Count == 0)
                {
                    sb.AppendLine($"    **No Tasks with Assignee {asigned.Name}**");
                }
            }
            return sb.ToString();
        }

        private string SortTasksByTitle()
        { 
            var tempList = Repository.Tasks.Where(t => t.GetType().Name != "Feedback").OrderBy(t => t.Title).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"__List of all assigned tasks Sort by title__");
            int counter = 1;
            foreach (var item in tempList)
            {
                if (tempList.Count != 0)
                {
                    var member = Repository.Members.FirstOrDefault(m => m.Tasks.Contains(item));
                    sb.AppendLine($"    {counter++}. '{item.Title}' is {item.GetType().Name} assigned to {member.Name}");
                }
                else {
                    sb.AppendLine($"    **No Tasks with Assignee**");
                }
            }
            return sb.ToString();
        }

        private string ListAllTasksAndAssignee()
        {
            var tempList = Repository.Tasks.Where(t => t.GetType().Name != "Feedback").ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"__List of all assigned tasks__");
            int counter = 1;
            foreach (var item in tempList)
            {
                if (tempList.Count != 0)
                {
                    var member = Repository.Members.FirstOrDefault(m => m.Tasks.Contains(item));
                    sb.AppendLine($"    {counter++}. '{item.Title}' is {item.GetType().Name} assigned to {member.Name}");
                }
                else
                {
                    sb.AppendLine($"    **No Tasks with Assignee**");
                }
            }
            return sb.ToString();
        }
    }
}
