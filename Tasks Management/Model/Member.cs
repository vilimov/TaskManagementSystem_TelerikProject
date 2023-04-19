using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Interface;

namespace Team.Model
{
    public class Member : IMember
    {
        private const int NameMinLength = 5;
        private const int NameMaxLength = 15;
        private const string errorMsg = "Member's name must be between {0} and {1} symbols";
        private readonly IList<ITask> tasks;
        private readonly IList<string> activityHistory;
        public Member(string name)
        {
            Validator.ValidateIntRange(name.Length, NameMinLength, NameMaxLength, String.Format(errorMsg, NameMinLength, NameMaxLength));
            Name = name;
            tasks = new List<ITask>();
            activityHistory = new List<string>();
            AddActivity($"Member {Name} created.");
        }
        public string Name { get; }

        public IList<ITask> Tasks
        {
            get
            {
                return new List<ITask>(tasks);
            }
        }

        public IList<string> ActivityHistory
        {
            get
            {
                return new List<string>(activityHistory);
            }
        }

        public void AssignTask(ITask task)
        {
            tasks.Add(task);
            AddActivity($"{Name} is assigned to task with ID {task.Id}.");
        }
        public void UnassignTask(ITask task)
        {
            tasks.Remove(task);
            AddActivity($"{Name} is unassigned from task with ID {task.Id}.");
        }
        public void AddActivity(string activity)
        {
            activityHistory.Add(activity);
        }
    }
}
