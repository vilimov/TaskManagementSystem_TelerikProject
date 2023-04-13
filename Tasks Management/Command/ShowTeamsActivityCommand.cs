using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class ShowTeamsActivityCommand : BaseCommand
    {
        public ShowTeamsActivityCommand(IRepository repository) : base(repository)
        {
            Repository = repository;
        }

        public IRepository Repository { get; }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
