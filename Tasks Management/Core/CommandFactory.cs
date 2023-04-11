using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Command.Contracts;
using Team.Core.Contracts;

namespace Team.Core
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(string commandLine)
        {
            throw new NotImplementedException();
        }

        public string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
