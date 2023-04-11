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
        public IList<string> activityHistory = new List<string>();
        public Member(string name, ITask task, IList<string> history)
        {
            Validator.ValidateIntRange(name.Length, NameMinLength, NameMaxLength, String.Format(errorMsg, NameMinLength, NameMaxLength));
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
