using System.Text.RegularExpressions;
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
                //Milko
                case CommandType.AddMemberToTeam:
                    return new AddMemberToTeamCommand(commandParameters, repository);
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParameters, repository);
                //Mila Done
                case CommandType.CreateBug:
                    return new CreateBugCommand(commandParameters, repository);
                case CommandType.CreateFeedback:
                    return new CreateFeedbackCommand(commandParameters, repository);
                //Koci
                case CommandType.CreateMember:
                    return new CreateMemberCommand(commandParameters, repository);
                case CommandType.CreateStory:
                    return new CreateStoryCommand(commandParameters, repository);
                //
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters, repository);
                //Milko
                case CommandType.ShowBoardsActivity:
                    return new ShowBoardsActivityCommand(commandParameters, repository);
                case CommandType.ShowMembersActivity:
                    return new ShowMembersActivityCommand(commandParameters, repository);
                //Mila
                case CommandType.ShowMembers:
                    //ShowMembers - lists all Created Members in the application
                    return new ShowMembersCommand(repository);
                case CommandType.ShowTeamBoards:
                    //ShowTeamBoards - lists all doards for specific Team in the application
                    return new ShowTeamBoardsCommand(commandParameters, repository);
                //Koci
                case CommandType.ShowTeamMembers:
                    return new ShowTeamMembersCommand(commandParameters, repository);
                case CommandType.ShowTeamsActivity:
                    return new ShowTeamsActivityCommand(commandParameters, repository);
                //
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
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");

                    //ToDo
                    //Change the Priority/Severity/Status of a bug.
                    //Change the Priority/Size/Status of a story.
                    //Change the Rating/Status of a feedback
                    //Assign/Unassign a task to a person.
                    //Add comment to a task
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

        /*private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            Enum.TryParse(commandName, true, out CommandType result);
            return result;
        }*/

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
