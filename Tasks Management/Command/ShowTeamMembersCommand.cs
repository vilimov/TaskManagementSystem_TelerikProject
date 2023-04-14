using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class ShowTeamMembersCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowTeamMembersCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateInputParametersCount(CommandParameters, ExpectedNumberOfArguments);

            // Parameters:
            //  [0] - Name of the Team
            string name = this.CommandParameters[0];
            return ListAllMembersOfTeam(name);
        }

        private string ListAllMembersOfTeam(string name)
        {
            foreach (var team in this.Repository.Teams)
            {
                if (team.Name == name)
                {
                    if (team.Members.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"{team.Name} members:");
                        foreach (var member in team.Members)
                        {
                            sb.AppendLine(member.Name);
                        }
                        sb.Append("---------------");
                        return sb.ToString();
                    }
                    else
                    {
                        string text = $"Team {name} doesn't have any members.";
                        return text;
                    }
                }
            }
            string message = $"No team with name - {name} exists.";
            return message;
        }
    }
}
