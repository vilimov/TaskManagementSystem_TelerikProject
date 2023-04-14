using Team.Core.Contracts;
using Team.Exeption;
using Team.Core;

namespace Team.Command
{
    public class AddMemberToTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public AddMemberToTeamCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }

            // Parameters:
            //  [0] - Member Name
            //  [1] - Team Name
            string memberName = CommandParameters[0];
            string teamName = CommandParameters[1];
            if (!Repository.Members.Any(m => m.Name == memberName))
            {
                throw new InvalidUserInputException($"Member with name {memberName} does not exist");
            }
            if (!Repository.Teams.Any(t => t.Name == teamName))
            {
                throw new InvalidUserInputException($"Team with name {teamName} does not exist");
            }
            var team = Repository.Teams.FirstOrDefault(t => t.Name == teamName);
            var member = Repository.Members.FirstOrDefault(m => m.Name == memberName);
            if (team.Members.Contains(member))
            {
                throw new InvalidUserInputException($"Team {teamName} already contains member with name {memberName}.");
            }
            else 
            {
                team.AddMember(member);
            }
            
            
            //ToDo Implement Add member to team
            return $"Member {memberName} added to team {teamName}.";
        }
    }
}
