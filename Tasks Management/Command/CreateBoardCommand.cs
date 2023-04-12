using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class CreateBoardCommand : BaseCommand
    {
        public CreateBoardCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public object CommandParameters { get; }
        public IRepository Repository { get; }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
