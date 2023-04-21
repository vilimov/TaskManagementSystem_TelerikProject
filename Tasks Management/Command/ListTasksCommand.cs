using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Model.Interface;
using Team.Model;

namespace Team.Command
{
    public class ListTasksCommand : BaseCommand
    {
        public ListTasksCommand(IList<string> commandParameters, IRepository repository)
     : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            IEnumerable<ITask> tasks = Repository.GetAllTasks();

            tasks = ApplyTitleFilter(tasks);
            tasks = ApplyTitleSort(tasks);

            return FormatTaskList(tasks);
        }

        private IEnumerable<ITask> ApplyTitleFilter(IEnumerable<ITask> tasks)
        {
            string filterByTitle = CommandParameters.FirstOrDefault(p => p.StartsWith("filter="))?.Substring("filter=".Length);
            if (!string.IsNullOrEmpty(filterByTitle))
            {
                return tasks.Where(t => t.Title.Contains(filterByTitle, StringComparison.OrdinalIgnoreCase));
            }
            return tasks;
        }

        private IEnumerable<ITask> ApplyTitleSort(IEnumerable<ITask> tasks)
        {
            bool sortByTitle = CommandParameters.Any(p => p.Equals("sortbytitle", StringComparison.OrdinalIgnoreCase));
            if (sortByTitle)
            {
                return tasks.OrderBy(t => t.Title);
            }
            return tasks;
        }

        private string FormatTaskList(IEnumerable<ITask> tasks)
        {
            StringBuilder sb = new StringBuilder();

            var feedbacks = tasks.OfType<Feedback>().ToList();
            sb.AppendLine($"Feedbacks ({feedbacks.Count}):");
            foreach (var feedback in feedbacks)
            {
                sb.AppendLine($"Feedback ID[{feedback.Id}] - Title: {feedback.Title}\n Description: {feedback.Description}");

            }

            var stories = tasks.OfType<Story>().ToList();
            sb.AppendLine($"\nStories ({stories.Count}):");
            foreach (var story in stories)
            {
                sb.AppendLine($"Story ID[{story.Id}] - Title: {story.Title}\n Descrioption : {story.Description}");
            }

            var bugs = tasks.OfType<Bug>().ToList();
            sb.AppendLine($"\nBugs ({bugs.Count}):");
            foreach (var bug in bugs)
            {
                sb.AppendLine($"Bug ID[{bug.Id}] - Title: {bug.Title}\n Description: {bug.Description}");
            }

            return sb.ToString();
        }
    }
}
