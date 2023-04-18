using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class ChangeFeedbackStatusCommand : BaseCommand
    {
        public ChangeFeedbackStatusCommand(List<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            return $"";
        }
    }
}
