﻿using System.Text.RegularExpressions;
using Team.Command;
using Team.Command.Contracts;
using Team.Command.Enum;
using Team.Core.Contracts;
using Team.Exeption;

namespace Team.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "<<";
        private const string CommentCloseSymbol = ">>";

        private readonly IRepository repository;
        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }
        public ICommand Create(string commandLine)
        {

            CommandType commandType = ParseCommandType(commandLine);
            List<string> commandParameters = ExtractCommandParameters(commandLine);


            switch (commandType)
            {
                case CommandType.AddMemberToTeam:
                    return new AddMemberToTeamCommand(commandParameters, repository);
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParameters, repository);
                case CommandType.CreateBug:
                    return new CreateBugCommand(commandParameters, repository);
                case CommandType.CreateFeedback:
                    return new CreateFeedbackCommand(commandParameters, repository);
                case CommandType.CreateMember:
                    return new CreateMemberCommand(commandParameters, repository);
                case CommandType.CreateStory:
                    return new CreateStoryCommand(commandParameters, repository);
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters, repository);
                case CommandType.ShowBoardsActivity:
                    return new ShowBoardsActivityCommand(commandParameters, repository);
                case CommandType.ShowMembersActivity:
                    return new ShowMembersActivityCommand(commandParameters, repository);
                case CommandType.ShowMembers:
                    //ShowMembers - lists all Created Members in the application
                    return new ShowMembersCommand(repository);
                case CommandType.ShowTeamBoards:
                    //ShowTeamBoards - lists all doards for specific Team in the application
                    return new ShowTeamBoardsCommand(commandParameters, repository);
                case CommandType.ShowTeamMembers:
                    return new ShowTeamMembersCommand(commandParameters, repository);
                case CommandType.ShowTeamsActivity:
                    return new ShowTeamsActivityCommand(commandParameters, repository);
                case CommandType.ShowTeams:
                    return new ShowTeamsCommand(repository);
                case CommandType.ChangeBugPriority:
                    return new ChangeBugPriorityCommand(commandParameters, repository);
                case CommandType.ChangeBugSeverity:
                    return new ChangeBugSeverityCommand(commandParameters, repository);
                case CommandType.ChangeBugStatus:
                    return new ChangeBugStatusCommand(commandParameters, repository);
                case CommandType.ChangeStoryPriority:
                    return new ChangeStoryPriorityCommand(commandParameters, repository);
                case CommandType.ChangeStorySize:
                    return new ChangeStorySizeCommand(commandParameters, repository);
                case CommandType.ChangeStoryStatus:
                    return new ChangeStoryStatusCommand(commandParameters, repository);
                case CommandType.ChangeFeedbackRating:
                    return new ChangeFeedbackRatingCommand(commandParameters, repository);
                case CommandType.ChangeFeedbackStatus:
                    return new ChangeFeedbackStatusCommand(commandParameters, repository);
                case CommandType.AddCommentToTask:
                    return new AddCommentToTaskCommand(commandParameters, repository);
                case CommandType.ChangeAssignee:
                    return new ChangeAssigneeCommand(commandParameters, repository);
                case CommandType.ListTasks:
                    return new ListTasksCommand(commandParameters, repository);
                case CommandType.ListBugs:
                    return new ListBugsCommand(commandParameters, repository);
                case CommandType.ListStories:
                    return new ListStoriesCommand(commandParameters, repository);
                case CommandType.ListFeedback:
                    return new ListFeedbackCommand(commandParameters, repository);
                case CommandType.ListTasksWithAssignee:
                    return new ListTasksWithAssigneeCommand(commandParameters, repository);
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");
            }

        }
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            bool isParsed = Enum.TryParse(commandName, true, out CommandType result);
            if (!isParsed)
            {
                throw new InvalidUserInputException("Invalid Command Type");
            }
            return result;
        }

        public static List<String> ExtractCommandParameters(string commandLine)
        {
            List<string> commandParameters = new List<string>();
            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            while (indexOfOpenComment > -1)
            {
                if (indexOfOpenComment >= 0)
                {
                    var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                    var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                    string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                    commandParameters.Add(commentParameter);
                    string removeThisText = CommentOpenSymbol + commentParameter + CommentCloseSymbol;
                    commandLine = commandLine.Replace(removeThisText, string.Empty);
                }
                indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
                indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            }
            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            commandParameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return commandParameters;
        }
    }
}
