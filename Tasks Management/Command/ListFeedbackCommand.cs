using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model.Interface;

namespace Team.Command
{
    internal class ListFeedbackCommand : BaseCommand
    {
        public ListFeedbackCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        IList<IFeedback> feedback = new List<IFeedback>();
        public override string Execute()
        {
            if (CommandParameters.Count == 1 && CommandParameters[0] != "ListFeedback")
            {
                throw new InvalidUserInputException("Please input valid parameters for 'ListFeedback' command");
            }

            foreach (var obj in Repository.Tasks)
            {
                if (obj is IFeedback feed)
                {
                    feedback.Add(feed);
                }
            }

            if (CommandParameters.Count == 2)
            {
                string action = CommandParameters[0];
                string firstProperty = CommandParameters[1];

                switch (action)
                {
                    case "FilterBy":

                        switch (firstProperty)
                        {
                            case "New":
                                feedback = feedback.Where(f => f.StatusType == FeedbackStatus.New).ToList();
                                break;
                            case "Unscheduled":
                                feedback = feedback.Where(f => f.StatusType == FeedbackStatus.Unscheduled).ToList();
                                break;
                            case "Scheduled":
                                feedback = feedback.Where(f => f.StatusType == FeedbackStatus.Scheduled).ToList();
                                break;
                            case "Done":
                                feedback = feedback.Where(f => f.StatusType == FeedbackStatus.Done).ToList();
                                break;
                            default:
                                throw new InvalidUserInputException("You have entered 'FilterBy' for first parameter. Please input Valid Feedback Status (New/Unscheduled/Scheduled/Done) for second parameter!");

                        }
                        break;

                    case "SortBy":
                        switch (firstProperty)
                        {
                            case "Title":
                                feedback = feedback.OrderBy(f => f.Title).ToList();
                                break;
                            case "Rating":
                                feedback = feedback.OrderBy(f => f.Rating).ToList();
                                break;
                            default:
                                throw new InvalidUserInputException("You have entered 'SortBy' for first parameter. Please input 'Title'/'Rating' for second parameter!");
                        }
                        break;
                    default:
                        throw new InvalidUserInputException("Please provide valid input - 'FilterBy' or 'SortBy' for first parameter of the 'ListFeedback' command!");
                }
            }
            string result = "**No Results with the provided parameters!**";
            if (feedback.Count != 0)
            {
                result = Print(feedback);
            }
            return result;
        }

        private string Print(IList<IFeedback> feedback)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (var feed in feedback)
            {
                sb.AppendLine($"{counter}) Feedback ID: {feed.Id}");
                sb.AppendLine($"   Title: {feed.Title}");
                sb.AppendLine($"   Description: {feed.Description}");
                sb.AppendLine($"   Rating: {feed.Rating}");
                sb.AppendLine($"   Status: {feed.StatusType}");
                sb.AppendLine($"   Comments: {string.Join(" / ", feed.Comments)}");
                sb.AppendLine($"   History: {string.Join(" / ", feed.History)}");
                counter++;
                sb.AppendLine(new string('-', 20));
            }
            return sb.ToString().ReplaceLineEndings();
        }
    }
}
