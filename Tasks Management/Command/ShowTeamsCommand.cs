using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class ShowTeamsCommand : BaseCommand
    {
        public ShowTeamsCommand(IRepository repository) : base(repository)
        {
        }

        public override string Execute()
        {
            if (this.Repository.Teams.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("All Teams:");
                foreach (var team in this.Repository.Teams)
                {
                    sb.AppendLine(team.Name);
                }
                sb.Append("---------------");
                return sb.ToString();
            }
            else
            {
                string message = "No Teams created";
                return message;
            }
        }
    }
}
