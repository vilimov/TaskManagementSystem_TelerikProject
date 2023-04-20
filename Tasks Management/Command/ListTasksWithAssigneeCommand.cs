using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;

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
            else if(firstCommand == "SortByTitle")
            {
                string title = this.CommandParameters[1];
                return SortTasksByTitle(title);
            }
            

            return "lalala";
        }

        private string FilterByStatus(string name) 
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        private string SortTasksByTitle(string name)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }
        private string SortTasksByAssignee(string name)
        {
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        private string ListAllTasksAndAssignee()
        {
            StringBuilder sb = new StringBuilder();
            var tempList = Repository.Members;
            sb.AppendLine($"__List of all members__");
            foreach (var item in tempList)
            {
                int counter = 1;
                sb.AppendLine($"    - {item.Name}'s tasks:");
                if (item.Tasks.Count == 0)
                {
                    sb.AppendLine($"      **NO Tasks for this member**");
                }
                foreach (var task in item.Tasks)
                {
                    sb.AppendLine($"      {counter++}. {task.GetType().Name} - {task.Title}");
                }
                
                sb.AppendLine($"------------------");
            }
            return sb.ToString();
        }
    }
}
