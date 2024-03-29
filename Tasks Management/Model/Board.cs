﻿using System;
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

        private readonly IList<ITask> tasks = new List<ITask>();
        private readonly IList<string> activityHistory = new List<string>();

        public Board(string name)
        {
            Validator.ValidateIntRange(name.Length, minLength, maxLength, string.Format(errorMsg, minLength, maxLength));
            Name = name;
            AddActivity($"Board with name {Name} created.");
        }
        public string Name { get; }

        public IList<ITask> Tasks
        {
            get
            {
                var copy = new List<ITask>(tasks);
                return copy;
            }
        }

        public IList<string> ActivityHistory
        {
            get
            {
                var copy = new List<string>(activityHistory);
                return copy;
            }         
        }

        public void AddActivity(string activity)
        {
            activityHistory.Add(activity);
        }

        public void AddTask(ITask task)
        {
            if (tasks.Any(t => t.Id == task.Id))
            {
                throw new ArgumentException("Task ID must be unique within the board's tasks.");
            }

            tasks.Add(task);
            AddActivity($"Added task with ID {task.Id} to board {Name}.");
        }

        public void RemoveTask(ITask task)
        {
            tasks.Remove(task);
            AddActivity($"Removed task with ID {task.Id} from board {Name}.");
        }
    }
}
