using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Model;

namespace Team.Command
{
    public class ShowMembersCommand : BaseCommand
    {
        public ShowMembersCommand(IRepository repository) : base(repository)
        {
        }

        public override string Execute()
        {
            if (this.Repository.Members.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("All Members:");
                foreach (var member in this.Repository.Members)
                {
                    sb.AppendLine(member.Name);
                }
                sb.Append("---------------");
                return sb.ToString();
            }
            else
            {
                string message = "No members created";
                return message;
            }
        }
    }
}
