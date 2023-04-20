using System.Text;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Command
{
    public class ListStoriesCommand : BaseCommand
    {
        public ListStoriesCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        IList<IStory> stories = new List<IStory>();
        public override string Execute()
        {
            if (CommandParameters.Count == 1 && CommandParameters[0] != "ListStories")
            {
                throw new InvalidUserInputException("Please input valid parameters for 'ListStories' command");
            }

            foreach (var obj in Repository.Tasks)
            {
                if (obj is IStory story)
                {
                    stories.Add(story);
                }
            }

            if (CommandParameters.Count == 2 || CommandParameters.Count == 3)
            {
                string action = CommandParameters[0];
                string firstProperty = CommandParameters[1];
                if (CommandParameters.Count == 3)
                {
                    if (!System.Enum.IsDefined(typeof(StoryStatusType), firstProperty))
                    {
                        throw new InvalidUserInputException($"You have entered invalid input '{firstProperty}' for second parameter. When you enter three parameters, the second one should be Valid Story Status (NotDone/InProgress/Done)!");
                    }
                    string secondProperty = CommandParameters[2];
                    if (!Repository.Members.Any(m => m.Name == secondProperty))
                    {
                        throw new InvalidUserInputException($"You have entered invalid input '{secondProperty}'. Please enter or Valid Assignee for third parameter!");
                    }
                    System.Enum.TryParse(firstProperty, out StoryStatusType statusType);
                    stories = stories.Where(s => s.Status == statusType).Where(t => t.Assignee == secondProperty).ToList();
                }

                switch (action)
                {
                    case "FilterBy":
                        if (Repository.Members.Any(m => m.Name == firstProperty))
                        {
                            stories = stories.Where(s => s.Assignee == firstProperty).ToList();
                        }
                        else
                        {
                            switch (firstProperty)
                            {
                                case "NotDone":
                                    stories = stories.Where(s => s.Status == StoryStatusType.NotDone).ToList();
                                    break;
                                case "InProgress":
                                    stories = stories.Where(s => s.Status == StoryStatusType.InProgress).ToList();
                                    break;
                                case "Done":
                                    stories = stories.Where(s => s.Status == StoryStatusType.Done).ToList();
                                    break;
                                default:
                                    throw new InvalidUserInputException("You have entered 'FilterBy' for first parameter. Please input Valid Story Status (Not Done/InProgress/Done) or Valid Assignee for second parameter!");
                            }
                        }
                        break;

                    case "SortBy":
                        switch (firstProperty)
                        {
                            case "Title":
                                stories = stories.OrderBy(s => s.Title).ToList();
                                break;
                            case "Priority":
                                stories = stories.OrderBy(s => s.Priority).ToList();
                                break;
                            case "Size":
                                stories = stories.OrderBy(s => s.Size).ToList();
                                break;
                            default:
                                throw new InvalidUserInputException("You have entered 'SortBy' for first parameter. Please input 'Title'/'Priority'/'Size' for second parameter!");
                        }
                        break;
                    default:
                        throw new InvalidUserInputException("Please provide valid input - 'FilterBy' or 'SortBy' for first parameter of the 'ListStories' command!");
                }
            }
            string result = "**No Results with the provided parameters!**";
            if (stories.Count != 0)
            {
                result = Print(stories);
            }
            return result;
        }

        private string Print(IList<IStory> stories)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (var story in stories)
            {
                sb.AppendLine($"{counter}) Story ID: {story.Id}");
                sb.AppendLine($"   Title: {story.Title}");
                sb.AppendLine($"   Description: {story.Description}");
                sb.AppendLine($"   Priority: {story.Priority}");
                sb.AppendLine($"   Severity: {story.Size}");
                sb.AppendLine($"   Status: {story.Status}");
                sb.AppendLine($"   Assignee: {story.Assignee}");
                sb.AppendLine($"   Comments: {string.Join(" / ", story.Comments)}");
                sb.AppendLine($"   History: {string.Join(" / ", story.History)}");
                counter++;
                sb.AppendLine(new string('-', 20));
            }
            return sb.ToString().ReplaceLineEndings();
        }
    }
}
