using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Interface;

namespace Team.Model
{
    public class Board : IBoard
    {
        public Board(string name, ITask task, IList<string> history)
        {
            //Validate name
            Name = name;
            Task = task;
            ActivityHistory = history;

        }
        public string Name { get; }

        public ITask Task { get; }

        public IList<string> ActivityHistory { get; }
    }
}
