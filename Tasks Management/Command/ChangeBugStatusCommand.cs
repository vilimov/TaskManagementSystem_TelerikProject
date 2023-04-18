using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;
using Team.Exeption;
using Team.Model.Enum;
using Team.Model;

namespace Team.Command
{
    public class ChangeBugStatusCommand : BaseCommand
    {
        public ChangeBugStatusCommand(List<string> commandParameters, IRepository repository) : base (commandParameters, repository)
        {
        }
        public override string Execute()
        {            
            return $"";
        }
    }
}
