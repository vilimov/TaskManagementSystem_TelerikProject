using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class CreateMemberCommand
    {
        public CreateMemberCommand(object commandParameters, IRepository repository)
        {
            CommandParameters = commandParameters;
            Repository = repository;
        }

        public object CommandParameters { get; }
        public IRepository Repository { get; }
    }
}
