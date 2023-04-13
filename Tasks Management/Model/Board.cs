using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Team.Model.Interface;

namespace Team.Model
{
    public class Board : IBoard
    {
        private const int minLength = 5;
        private const int maxLength = 15;
        private const string errorMsg = "Board name must be between {0} and {1} symbols";


        public Board(string name)
        {
            Validator.ValidateIntRange(name.Length, minLength, maxLength, errorMsg);
            Name = name;
            Tasks = new List<ITask>();
            ActivityHistory = new List<string>();

        }
        public string Name { get; }

        public IList<ITask> Tasks { get; }

        public IList<string> ActivityHistory
        {
            get
            {
                var copy = new List<string>(ActivityHistory);
                return copy;
            }
            private set { ActivityHistory = value; }
        }

        public void AddActivity(string activity)
        {
            ActivityHistory.Add(activity);
        }

        public void AddTask(ITask task)
        {
            if (Tasks.Any(t => t.Id == task.Id))
            {
                throw new ArgumentException("Task ID must be unique within the board's tasks.");
            }

            Tasks.Add(task);
            AddActivity($"Added task with ID {task.Id} to board {Name}.");
        }

        public void RemoveTask(ITask task)
        {
            Tasks.Remove(task);
            AddActivity($"Removed task with ID {task.Id} from board {Name}.");
        }
    }
}
