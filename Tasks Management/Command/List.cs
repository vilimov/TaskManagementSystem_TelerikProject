﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Core.Contracts;

namespace Team.Command
{
    public class List : BaseCommand
    {
        public List(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
