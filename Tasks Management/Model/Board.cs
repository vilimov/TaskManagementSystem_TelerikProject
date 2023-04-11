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
        private readonly IList<string> activityHistory = new List<string>();
        public Board(string name, ITask task)
        {
            //Validate name
            Name = name;
            Task = task;

        }
        public string Name { get; }

        public ITask Task { get; }

        public IList<string> ActivityHistory
        {
            get
            {
                return new List<string>(activityHistory);
            }
        }
    }
}
