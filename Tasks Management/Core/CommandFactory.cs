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
                /*case CommandType.CreateBoard:
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
                    return new ShowBoardsActivityCommand(repository);
                case CommandType.ShowMembersActivity:
                    return new ShowMembersActivityCommand(repository);
                case CommandType.ShowMembers:
                    return new ShowMembersCommand(repository);
                case CommandType.ShowTeamBoards:
                    return new ShowTeamBoardsCommand(repository);
                case CommandType.ShowTeamMembers:
                    return new ShowTeamMembersCommand(repository);
                case CommandType.ShowTeamsActivity:
                    return new ShowTeamsActivityCommand(repository);
                case CommandType.ShowTeams:
                    return new ShowTeamsCommand(repository);*/
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

        //ToDo Implementation
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();
            return parameters;
        }
    }
}
