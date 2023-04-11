using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Command.Contracts;

namespace Team.Core.Contracts
{
    public interface ICommandFactory : ICommand
    {
        ICommand Create(string commandLine);
    }
}
