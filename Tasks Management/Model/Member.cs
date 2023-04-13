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
        public Member(string name)
        {
            Validator.ValidateIntRange(name.Length, NameMinLength, NameMaxLength, String.Format(errorMsg, NameMinLength, NameMaxLength));
            Name = name;
            Tasks = new List<ITask>();
            ActivityHistory = new List<string>();

        }
        public string Name { get; }

        public IList<ITask> Tasks { get; }

        public IList<string> ActivityHistory { get; }

        public void AssignTask(ITask task)
        {
            Tasks.Add(task);
            AddActivity($"{Name} is assigned to task with ID {task.Id}.");
        }
        public void UnassignTask(ITask task)
        {
            Tasks.Remove(task);
            AddActivity($"{Name} is unassigned from task with ID {task.Id}.");  
        }
        public void AddActivity(string activity)
        {
            ActivityHistory.Add(activity);
        }
    }
}
