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
        public ListTasksCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            IEnumerable<ITask> tasks = Repository.GetAllTasks();
            return FormatTaskList(tasks);
        }

        private string FormatTaskList(IEnumerable<ITask> tasks)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Feedbacks:");
            foreach (var feedback in tasks.OfType<Feedback>())
            {
                sb.AppendLine($"Feedback with ID[{feedback.Id}] - Title: {feedback.Title}\n - Rating: {feedback.Rating}\n - Status: {feedback.StatusType}\n - Description: {feedback.Description}");
                sb.AppendLine("     -COMMENTS-     ");
                foreach (var comment in feedback.Comments)
                {
                    sb.AppendLine($"From: {comment.Author.Name}: {comment.CommentText}");
                }
                sb.AppendLine("========================================");
            }

            sb.AppendLine("\nStories:");
            foreach (var story in tasks.OfType<Story>())
            {
                sb.AppendLine($"Story with ID[{story.Id}] - Title: {story.Title}\n - Description: {story.Description}\n - Priority: {story.Priority}\n - Size: {story.Size}\n - Status: {story.Status}");
                sb.AppendLine("     -COMMENTS-     ");
                foreach (var comment in story.Comments)
                {
                    sb.AppendLine($"From {comment.Author.Name}: {comment.CommentText}");
                }
                sb.AppendLine("========================================");
            }

            sb.AppendLine("\nBugs:");
            foreach (var bug in tasks.OfType<Bug>())
            {
                sb.AppendLine($"Bug with ID[{bug.Id}] - {bug.Title}\n - Description: {bug.Description}\n - Priority: {bug.Priority}\n - Severity: {bug.Severity}\n - Status: {bug.Status}\n - Steps: {bug.ListOfSteps}");
                sb.AppendLine("     -COMMENTS-     ");
                foreach (var comment in bug.Comments)
                {
                    sb.AppendLine($"From {comment.Author.Name}: {comment.CommentText}");
                }
                sb.AppendLine("========================================");
            }

            return sb.ToString();
        }
    }
}
