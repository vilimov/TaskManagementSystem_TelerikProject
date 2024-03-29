﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Model.Interface
{
    public interface IMember
    {
        public string Name { get; }
        public IList<ITask> Tasks { get; }
        public IList<string> ActivityHistory { get; }
        void AssignTask(ITask task);
        void UnassignTask(ITask task);
        void AddActivity(string activity);
    }
}
