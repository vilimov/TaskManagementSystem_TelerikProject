using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Model.Enum;

namespace Team.Model.Interface
{
    public interface IStory : ITask
    {
        public PriorityType Priority { get; }
        public SizeType Size { get; }
        public StoryStatusType Status { get; }
        public string Assignee { get; }
    }
}
