using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model;
using Team.Model.Interface;

namespace Team.Command
{
    public class ListBugsCommand : BaseCommand
    {
        public ListBugsCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        IList<IBug> bugs = new List<IBug>();
        public override string Execute()
        {
            foreach (var obj in Repository.Tasks)
            {
                if (obj is IBug bug)
                {
                    bugs.Add(bug);
                }
            }

            if (CommandParameters.Count == 2 || CommandParameters.Count == 3)
            {
                string action = CommandParameters[0];
                string firstProperty = CommandParameters[1];
                switch (action)
                {
                    case "FilterBy":
                        switch (firstProperty)
                        {
                            case "Active":
                                bugs.Select(x => x.Status == Model.Enum.StatusType.Active);
                                break;
                            case "":
                            default:
                                throw new InvalidUserInputException("You have entered 'FilterBy' for first parameter, please input 'Status' or 'Assignee' for second parameter");
                        }
                        break;

                    case "SortBy":
                        switch (firstProperty)
                        {
                            case "Title":
                                bugs = bugs.OrderBy(b => b.Title).ToList();
                                break;
                            case "Priority":
                                bugs = bugs.OrderBy(b => b.Priority).ToList();
                                break;
                            case "Severity":
                                bugs = bugs.OrderBy(b => b.Severity).ToList();
                                break;
                            default:
                                throw new InvalidUserInputException("You have entered 'SortBy' for first parameter, please input 'Title'/'Priority'/'Severity' for second parameter");
                        }
                        break;
                    default:
                        throw new InvalidUserInputException("Please provide valid input - 'FilterBy' or 'SortBy' for first parameter of the 'ListBugs' command");
                }
            }
            else if (CommandParameters.Count != 0)
            {
                throw new InvalidUserInputException("Please input valid parameters for 'ListBugs' command");
            }
            Console.Write(Print(bugs));
            return new string('-', 20);
        }

        private string Print(IList<IBug> bugs)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (var bug in bugs)
            {
                sb.AppendLine(new string('-', 20));
                sb.AppendLine($"{counter}) Bug ID: {bug.Id}");
                sb.AppendLine($"   Title: {bug.Title}");
                sb.AppendLine($"   Description: {bug.Description}");
                sb.AppendLine($"   Steps To Reproduce: ");
                sb.AppendLine($"   Priority: {bug.Priority}");
                sb.AppendLine($"   Severity: {bug.Severity}");
                sb.AppendLine($"   Status: {bug.Status}");
                sb.AppendLine($"   Assignee: {bug.Assignee}");
                sb.AppendLine($"   Comments: {string.Join(" / ", bug.Comments)}");
                sb.AppendLine($"   History: {string.Join(" / ", bug.History)}");
                counter++;
            }
            return sb.ToString().ReplaceLineEndings();
        }
    }
}
