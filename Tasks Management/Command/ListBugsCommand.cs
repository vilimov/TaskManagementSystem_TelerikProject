using System.Text;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Command
{
    public class ListBugsCommand : BaseCommand
    {
        public ListBugsCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        IList<IBug> bugs = new List<IBug>();
        IList<IBug> filteredBugs = new List<IBug>();
        public override string Execute()
        {
            if (CommandParameters.Count == 1 && CommandParameters[0] != "ListBugs")
            {
                throw new InvalidUserInputException("Please input valid parameters for 'ListBugs' command");
            }

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
                if (Repository.Members.Any(m => m.Name == firstProperty))
                {
                    string memberName = firstProperty;
                }

                if (CommandParameters.Count == 3)
                {
                    string validStatus = firstProperty;
                    string memberName = CommandParameters[2];
                    Repository.Members.Any(m => m.Name == firstProperty);
                }

                switch (action)
                    {
                        case "FilterBy":
                            switch (firstProperty)
                            {
                                case "Active":
                                    bugs = bugs.Where(t => t.Status == StatusType.Active).ToList();
                                    break;
                                case "Fixed":
                                    bugs = bugs.Where(t => t.Status == StatusType.Fixed).ToList();
                                    break;
                                case string memberName:
                                    bugs = bugs.Where(t => t.Assignee == memberName).ToList();
                                    break;
                                default:
                                    throw new InvalidUserInputException("You have entered 'FilterBy' for first parameter, please input Valid Bug Status (Active/Fixed) or Valid Assignee for second parameter");
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
            return Print(bugs);
        }

        private string Print(IList<IBug> bugs)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (var bug in bugs)
            {
                sb.AppendLine($"{counter}) Bug ID: {bug.Id}");
                sb.AppendLine($"   Title: {bug.Title}");
                sb.AppendLine($"   Description: {bug.Description}");
                sb.AppendLine($"   Steps To Reproduce: {bug.ListOfSteps}");
                sb.AppendLine($"   Priority: {bug.Priority}");
                sb.AppendLine($"   Severity: {bug.Severity}");
                sb.AppendLine($"   Status: {bug.Status}");
                sb.AppendLine($"   Assignee: {bug.Assignee}");
                sb.AppendLine($"   Comments: {string.Join(" / ", bug.Comments)}");
                sb.AppendLine($"   History: {string.Join(" / ", bug.History)}");
                counter++;
                sb.AppendLine(new string('-', 20));
            }
            return sb.ToString().ReplaceLineEndings();
        }
    }
}
